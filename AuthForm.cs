using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace vkRaid
{
    public partial class AuthForm : Form
    {
        private string AccessToken
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(accessTokenTextBox.Text))
                {
                    UnAlert(accessTokenTextBox);
                    return accessTokenTextBox.Text;
                }
                else
                {
                    Alert(accessTokenTextBox);
                    throw new Exception("Дурак, аксес токен введи");
                }
            }
        }

        private string Login
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(loginTextBox.Text))
                {
                    UnAlert(loginTextBox);
                    return loginTextBox.Text;
                }
                else
                {
                    Alert(loginTextBox);
                    throw new Exception("Дурак, логин введи");
                }
            }
        }

        private string Password
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(passwordTextBox.Text))
                {
                    UnAlert(loginTextBox);
                    return passwordTextBox.Text;
                }
                else
                {
                    Alert(passwordTextBox);
                    throw new Exception("Дурак, пароль введи");
                }
            }
        }

        string accessToken;
        public VkNet.VkApi api;
        private Point DownMouse;
        private bool isDragging;
        int stage = 0;
        Dictionary<string, Rectangle> alertedRects = new Dictionary<string, Rectangle>();

        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }

        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }

        private UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    // use IE11 mode by default
                    break;
            }

            return mode;
        }

        public AuthForm(VkNet.VkApi api)
        {
            SetBrowserFeatureControl();
            InitializeComponent();
            this.api = api;
        }

        private void AuthForm_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            DownMouse = e.Location;
        }

        private void AuthForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void AuthForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
                Location = new Point(Location.X + e.X - DownMouse.X, Location.Y + e.Y - DownMouse.Y);
        }

        private void UserAuth_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login != null && Password != null)
                {
                    accessToken = GetAccessToken();
                    Auth(accessToken);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (VkNet.Exception.CaptchaNeededException ex)
            {
                Captcha captcha = new Captcha(ex.Img);
                if (captcha.ShowDialog() == DialogResult.OK)
                {
                    Auth(accessToken, ex.Sid, captcha.CaptchaKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void UnAlert(Control control)
        {
            if (alertedRects.ContainsKey(control.Name))
                alertedRects.Remove(control.Name);
        }

        private void Alert(Control control)
        {
            alertedRects.Add(control.Name, control.Bounds);
        }

        private void Auth(string accessToken, long? captchaSid = null, string captchaKey = null)
        {
            api.Authorize(new VkNet.Model.ApiAuthParams
            {
                AccessToken = accessToken,
                CaptchaSid = captchaSid,
                CaptchaKey = captchaKey
            });
        }

        private string GetAccessToken()
        {
            webBrowser1.DocumentCompleted += DocReady;
            webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=2685278&scope=1073737727&redirect_uri=https://api.vk.com/blank.html&display=page&response_type=token&revoke=1");
            while (accessToken == null)
            {
                Application.DoEvents();
            }
            if (accessToken == "error")
                throw new Exception("Штото пошло не так во время авторизации...");
            return accessToken;
        }

        private void DocReady(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                HtmlElement form;
                HtmlElementCollection inputs;
                if ((webBrowser1.Document.Title != "ВКонтакте | Вход") && stage < 2)
                    stage = 2;
                switch (stage)
                {
                    case 0:
                        form = webBrowser1.Document.GetElementById("login_submit");
                        inputs = form.GetElementsByTagName("input");
                        var email = inputs[5];
                        var pass = inputs[6];
                        email.InnerText = Login;
                        pass.InnerText = Password;
                        form.GetElementsByTagName("button")[0].InvokeMember("click");
                        stage++;
                        break;
                    case 1:
                        form = webBrowser1.Document.GetElementsByTagName("form")[0];
                        inputs = form.GetElementsByTagName("input");
                        var code = new Code();
                        if (code.ShowDialog() == DialogResult.OK)
                        {
                            inputs[0].InnerText = code.ConfirmationCode;
                        }
                        inputs[2].InvokeMember("click");
                        stage++;
                        break;
                    case 2:
                        webBrowser1.Document.Body.GetElementsByTagName("button")[0].InvokeMember("click");
                        stage++;
                        break;
                    case 3:
                        var uri = webBrowser1.Url.AbsoluteUri;
                        var index = uri.IndexOf("access_token=") + 13;
                        var length = uri.IndexOf("&expires_in") - index;
                        accessToken = uri.Substring(index, length);
                        break;
                }
            }
            catch
            {
                accessToken = "error";
            }
        }

        private void alertControls(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red,3);
            Graphics g = e.Graphics;
            foreach(var border in alertedRects)
            {
                g.DrawRectangle(pen, border.Value);
            }
        }

        private void GroupAuth(object sender, EventArgs e)
        {
            try
            {
                Auth(AccessToken);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason != CloseReason.None)
            DialogResult = DialogResult.Abort;
        }

        private void UserAuthFocus(object sender, EventArgs e)
        {
            AcceptButton = userAuth;
        }

        private void AccessTokenTextBox_Enter(object sender, EventArgs e)
        {
            AcceptButton = groupAuth;
        }
    }
}

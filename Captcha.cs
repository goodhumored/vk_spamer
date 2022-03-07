using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace vkRaid
{
    public partial class Captcha : Form
    {
        private Point DownMouse;
        private bool isDragging;
        public string CaptchaKey => captchaKeyTextbox.Text;
        public Captcha(Uri uri)
        {
            InitializeComponent();
            try
            {
                using (WebClient wc = new WebClient())
                {
                    pictureBox1.Image = Image.FromStream(wc.OpenRead(uri));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        private void Captcha_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            DownMouse = e.Location;
        }

        private void Captcha_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
                Location = new Point(Location.X + e.X - DownMouse.X, Location.Y + e.Y - DownMouse.Y);
        }

        private void Captcha_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}

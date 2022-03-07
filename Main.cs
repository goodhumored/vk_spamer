using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VkNet;

namespace vkRaid
{
    public partial class Main : Form
    {
        private Point DownMouse;
        private bool isDragging;
        private int count;
        private bool raid;
        private bool authed;
        public long PeerId
        {
            get
            {
                if (long.TryParse(new Regex(@"\d+").Match(LinkTextBox.Text).Value, out long tmp))
                {
                    return tmp;
                }
                else
                {
                    throw new Exception("ДИБИЛ ТЫ С АЙДИ ЧАТА НАКОСЯЧИЛ!");
                }
            }
        }
        private string Message => MessageTextBox.Text;
        private uint StickerId
        {
            get
            {
                var stickerId = StickerIdPattern.Match(StickerIdBox.Text).Value;
                if (uint.TryParse(stickerId, out uint tmp))
                {
                    return tmp;
                }
                else
                {
                    throw new Exception("Ты дебил, с айди стикера накосячил! >:-(");
                }
            }
        }
        private readonly List<VkNet.Model.Attachments.MediaAttachment> atts = new List<VkNet.Model.Attachments.MediaAttachment>();
        public VkApi api = new VkApi();
        private static readonly Regex AttachmentPattern = new Regex(@"(wall_reply|wall|doc|audio|video|photo)-?\d+_\d+");
        private static readonly Regex attTypePattern = new Regex(@"^\D+[^-\d]");
        private static readonly Regex StickerIdPattern = new Regex(@"(\d{5,}|^\d{0,5})");

        public Main()
        {
            InitializeComponent();
        }

        private void AuthExitButton_Click(object sender, EventArgs e)
        {
            if (!api.IsAuthorized)
            {
                AuthForm af = new AuthForm(api);
                if (af.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        api = af.api;
                        if (api.IsAuthorized)
                        {
                            var info = api.Account.GetProfileInfo();
                            info = api.Account.GetProfileInfo();
                            NickName.Text = info.FirstName + " " + info.LastName;
                            AuthExitButton.Text = "Выйти";
                        }
                    }
                    catch (VkNet.Exception.UserAuthorizationFailException)
                    {
                        NickName.Text = "Ноунейм паблос для дэбилов";
                        AuthExitButton.Text = "Выйти";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.Source);
                    }
                }
            }
            else
            {
                api.LogOut();
                NickName.Text = "Имя Фамилия";
                AuthExitButton.Text = "Войти";
            }
        }

        private void Link_DropDown(object sender, EventArgs e)
        {
            try
            {
                LinkTextBox.Items.Clear();
                var convs = api.Messages.GetConversations(new VkNet.Model.RequestParams.GetConversationsParams {Count = 10}).Items;
                for (int i = 0; i < convs.Count; i++)
                {
                    if (convs[i].Conversation.CanWrite.Allowed)
                    {
                        var type = convs[i].Conversation.Peer.Type;
                        if (type == VkNet.Enums.SafetyEnums.ConversationPeerType.Chat)
                        {
                            LinkTextBox.Items.Add($"Чат {convs[i].Conversation.ChatSettings.Title} ({convs[i].Conversation.Peer.Id})");
                        }
                        else if (type == VkNet.Enums.SafetyEnums.ConversationPeerType.User)
                        {
                            var user = api.Users.Get(new long[] { convs[i].Conversation.Peer.Id })[0];
                            LinkTextBox.Items.Add($"Пользователь {user.FirstName} {user.LastName} ({convs[i].Conversation.Peer.Id})");
                        }
                        else if (type == VkNet.Enums.SafetyEnums.ConversationPeerType.Group)
                        {
                            var group = api.Groups.GetById(null, convs[i].Conversation.Peer.LocalId.ToString(), null)[0];
                            LinkTextBox.Items.Add($"Группа {group.Name} ({convs[i].Conversation.Peer.Id})");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void AddAtt_Click(object sender, EventArgs e)
        {
            var oldCount = AttachmentList.Items.Count;
            Link link = new Link();
            if (link.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var attLink = link.AttachmentLink;
                    var info = AttachmentPattern.Match(attLink).Value;
                    var mediaType = attTypePattern.Match(info).Value;
                    var ownerId = info.Remove(0, mediaType.Length).Split('_')[0].Replace("-", "");
                    var user = api.Users.Get(new string[] { ownerId })[0];

                    var item = AttachmentList.Items.Add(attLink);
                    item.SubItems.Add(mediaType);
                    item.SubItems.Add(user.FirstName + " " + user.LastName);
                    switch (mediaType)
                    {
                        case "photo":
                            atts.Add(new VkNet.Model.Attachments.Photo
                            {
                                OwnerId = long.Parse(ownerId),
                                Id = long.Parse(info.Remove(0, mediaType.Length).Split('_')[1])
                            });
                            break;
                        case "video":
                            atts.Add(new VkNet.Model.Attachments.Video
                            {
                                OwnerId = long.Parse(ownerId),
                                Id = long.Parse(info.Remove(0, mediaType.Length).Split('_')[1])
                            });
                            break;
                        case "doc":
                            atts.Add(new VkNet.Model.Attachments.Document
                            {
                                OwnerId = long.Parse(ownerId),
                                Id = long.Parse(info.Remove(0, mediaType.Length).Split('_')[1])
                            });
                            break;
                        case "wall":
                            atts.Add(new VkNet.Model.Attachments.Wall
                            {
                                OwnerId = long.Parse(ownerId),
                                Id = long.Parse(info.Remove(0, mediaType.Length).Split('_')[1])
                            });
                            break;
                        case "wall_reply":
                            atts.Add(new VkNet.Model.Attachments.WallReply
                            {
                                OwnerId = long.Parse(ownerId),
                                Id = long.Parse(info.Remove(0, mediaType.Length).Split('_')[1])
                            });
                            break;
                        default:
                            throw new Exception("Так блин ты меня либо за дебила держиш либо сам с ссылкой лоханулся :|");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                    if (AttachmentList.Items.Count != oldCount)
                    {
                        AttachmentList.Items.RemoveAt(AttachmentList.Items.Count - 1);
                    }
                }
            }
        }

        private void RemoveAtt_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = AttachmentList.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    atts.RemoveAt(AttachmentList.SelectedIndices[i]);
                    AttachmentList.Items.RemoveAt(AttachmentList.SelectedIndices[i]);
                }
            }
            catch
            {

            }
        }

        private void RaidButtonClick(object sender, EventArgs e)
        {
            if (!raid)
            {
                raid = true;
                StartSpamAsync();
                StartRaidButton.Text = "Стоп";
            }
            else
            {
                raid = false;
                StartRaidButton.Text = "Рейд";
            }
        }

        private async void StartSpamAsync()
        {
            long? sid = null;
            string captchaKey = null;
            while (raid)
            {
                var RandomId = new Random().Next(int.MinValue, int.MaxValue);
                try
                {
                    await api.Messages.SendAsync(new VkNet.Model.RequestParams.MessagesSendParams
                    {
                        PeerId = PeerId,
                        Message = string.IsNullOrWhiteSpace(MessageTextBox.Text) ? null : Message,
                        Attachments = atts,
                        CaptchaSid = sid,
                        CaptchaKey = captchaKey,
                        StickerId = string.IsNullOrWhiteSpace(StickerIdBox.Text) ? 0 : StickerId,
                        RandomId = RandomId
                    });
                    sid = null;
                    captchaKey = null;
                    count++;
                    label5.Text = "Кол - во отправленных сообщений:\n" + count;
                }
                catch (VkNet.Exception.CaptchaNeededException ex)
                {
                    Captcha captcha = new Captcha(ex.Img);
                    if (captcha.ShowDialog() == DialogResult.OK)
                    {
                        captchaKey = captcha.CaptchaKey;
                    }
                    sid = ex.Sid;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                    StartRaidButton.Text = "Рейд";
                    raid = false;
                    break;
                }
            }
        }

        private void AttachmentList_DragDrop(object sender, DragEventArgs e)
        {
            //MessageBox.Show(e.Data.GetFormats()[0]);
            //var url = api.Photo.GetMessagesUploadServer(PeerId).UploadUrl;
            MessageBox.Show("ПОШОЛ В ЖОПУ! Данная функция пока не поддерживается");
        }

        private void AttachmentList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) || e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            DownMouse = e.Location;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Location = new Point(Location.X + e.X - DownMouse.X, Location.Y + e.Y - DownMouse.Y);
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://vk.com/albums-67887231");
        }
    }
}
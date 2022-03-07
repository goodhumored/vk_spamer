using System.Drawing;
using System.Windows.Forms;

namespace vkRaid
{
    public partial class Link : Form
    {
        private Point DownMouse;
        private bool isDragging;
        public string AttachmentLink => LinkTextbox.Text;
        public Link()
        {
            InitializeComponent();
        }

        private void Link_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            DownMouse = e.Location;
        }

        private void Link_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
                Location = new Point(Location.X + e.X - DownMouse.X, Location.Y + e.Y - DownMouse.Y);
        }

        private void Link_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("ПОШОЛ В ЖОПУ! Данная херня в процессе создания! Work In Progress! WIP!");
            //if(ChooseAttachment.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show(ChooseAttachment.FileNames[0]);
            //    var files = ChooseAttachment.FileNames;
            //    button2.Text = "" 
            //}
        }
    }
}

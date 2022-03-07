using System.Windows.Forms;

namespace vkRaid
{
    public partial class Code : Form
    {
        public string ConfirmationCode => codeTextBox.Text;
        public Code()
        {
            InitializeComponent();
        }
    }
}

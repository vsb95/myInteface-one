using System;
using System.Windows.Forms;

namespace WindowsFormsApplication01
{
    public partial class FormAdmin : Form
    {
        private readonly Form _backForm;
        
        public FormAdmin(Form backForm)
        {
            this._backForm = backForm;
            InitializeComponent();
        }
        
        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _backForm.Show();
        }
        
        

        private void bRegister_Click_1(object sender, EventArgs e)
        {

        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

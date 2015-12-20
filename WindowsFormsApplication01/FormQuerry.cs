using System;
using System.Windows.Forms;

namespace WindowsFormsApplication01
{
    public partial class FormQuerry : Form
    {
        private readonly Form _backForm;
        public string querry;
        public FormQuerry(Form backForm)
        {
            _backForm = backForm;
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormQuerry_FormClosing(object sender, FormClosingEventArgs e)
        {
            _backForm.Show();
        }

        private void buttonQuerry1_Click(object sender, EventArgs e)
        {
            querry = "1";
            Close();
            
        }

        private void buttonQuerry2_Click(object sender, EventArgs e)
        {
            querry = "2";
            Close();
        }

        private void buttonQuerry3_Click(object sender, EventArgs e)
        {
            querry = "3";
            Close();
        }

        private void buttonQuerry4_Click(object sender, EventArgs e)
        {
            querry = "4";
            Close();
        }
    }
}

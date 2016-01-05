using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication01
{
    public partial class FormAdmin : Form
    {
        private readonly Form _backForm;
        private readonly UserService.UserService _service;
        public FormAdmin(Form backForm, UserService.UserService service)
        {
            this._backForm = backForm;
            InitializeComponent();
            cBoxRoles.DataSource = new List<string> { "Администратор", "Оператор", "Пользователь" };
            _service = service;
        }
        
        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _backForm.Show();
        }
        
        

        private void bRegister_Click_1(object sender, EventArgs e)
        {
            try
            {
                _service.InsertQuery(
                    new ArrayList { tBoxLogin.Text, tBoxPass.Text, cBoxRoles.SelectedItem.ToString() },
                    "Пользователь");
                MessageBox.Show($"Пользователь {tBoxLogin.Text} успешно зарегестрирован!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication01
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string role = "Editor";
                buttonQuerry.Visible = true;
                switch (role)
                {
                    case "Admin":
                        buttonReg.Visible = true;
                        buttonShowMagazine.Visible = true;
                        break;
                    case "Editor":
                        buttonAdd.Visible = true;
                        buttonEdit.Visible = true;
                        buttonDelete.Visible = true;
                        break;
                    case "Reader":
                        break;
                    default: throw new Exception("Чет хз кто ты");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //// выбрать табу и из нее датагрида вызвать 
            /*
            var fields = _service.Tables.FirstOrDefault(t => t.Name == listBoxTables.SelectedItem.ToString())
                .Fields.Select(field => field.Name).ToList();
            var frm = new FormEdit_Add_(_service, this, fields, listBoxTables.SelectedItem.ToString());
            frm.ShowDialog();
            Refresh();
    */
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //// выбрать табу и из нее датагрида вызвать 
            /*
            var editValuesList = new List<string>();
            for (var i = 0; i < dataGridTable.SelectedRows[0].Cells.Count; i++)
                editValuesList.Add(dataGridTable.SelectedRows[0].Cells[i].Value.ToString());
            var fields = _service.Tables.FirstOrDefault(t => t.Name == listBoxTables.SelectedItem.ToString())
                .Fields.Select(field => field.Name).ToList();

            var frm = new FormEdit_Add_(_service, this, fields, listBoxTables.SelectedItem.ToString(), editValuesList);
            frm.ShowDialog();
            Refresh();
    */
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            var frm = new FormAdmin(this);
            Hide();
            frm.ShowDialog();
        }

        private void buttonQuerry_Click(object sender, EventArgs e)
        {
            var frm = new FormQuerry(this);
            Hide();

            if (frm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            //////////////////////////////////////////// 
            /// выполнить запрос который вышел из frm.querry;
            string запрос = frm.querry; // на русском - лал

        }

        private void buttonShowMagazine_Click(object sender, EventArgs e)
        {

        }
    }
}

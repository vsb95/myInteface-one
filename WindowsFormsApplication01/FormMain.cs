using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication01
{
    public partial class FormMain : Form
    {
        private readonly UserService.UserService _service;
        private ArrayList _juornal;
        private bool _isLoginTried = false;
        public FormMain()
        {
            InitializeComponent();
            _juornal = new ArrayList();
            _service = new UserService.UserService();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            _isLoginTried = true;
            try
            {
                //                string role = "Администратор";
                string role = _service.GetCurrentRole(tBoxLogin.Text, tBoxPassword.Text);
                if (role == null) throw new Exception("Пользователь не найден");
                
                label2.Enabled = false;
                tBoxPassword.Enabled = false;
                label1.Enabled = false;
                tBoxLogin.Enabled = false;
                buttonLogIn.Visible = false;
                label1.Visible = true;
                tabControl1.Visible = true;
                buttonExit.Visible = true;
              //  cBoxRoles.DataSource = new List<string> { "Администратор", "Оператор", "Пользователь" };
                foreach (
                    var table in
                        _service.Tables.Where(table => !(table.Name == "Журнал" | table.Name == "Пользователь")))
                    tabControl1.TabPages.Add(table.Name);

                ReloadTabs();
                switch (role)
                {
                    case "Администратор":

                        buttonAdd.Visible = true;
                        buttonEdit.Visible = true;
                        buttonDelete.Visible = true;
                        buttonQuerry.Visible = true;
                        buttonReg.Visible = true;
                        buttonShowMagazine.Visible = true;
                        break;
                    case "Оператор":
                        buttonAdd.Visible = true;
                        buttonEdit.Visible = true;
                        buttonDelete.Visible = true;
                        buttonQuerry.Visible = true;
                        break;
                    case "Пользователь":
                        buttonQuerry.Visible = true;
                        break;
                    default: throw new Exception("Не удалось определить права доступа");
                }
                _juornal.Add(tBoxLogin.Text);
                _juornal.Add(DateTime.Now);
            }
            catch (Exception ex)
            {
                _juornal.Add(tBoxLogin.Text);
                _juornal.Add(DateTime.Now);
                _juornal.Add(DateTime.Now);
                _juornal.Add(false);
                _service.InsertQuery(_juornal, "Журнал");
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var fields = _service.Tables.FirstOrDefault(t => t.Name == tabControl1.SelectedTab.Text)
                    .Fields.Select(field => field.Name).ToList();
                var frm = new FormEdit_Add_(_service, this, fields, tabControl1.SelectedTab.Text);
                frm.ShowDialog();
                ReloadTabs();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var dgv = tabControl1.SelectedTab.Controls[0] as DataGridView;
                if (tabControl1.SelectedTab.Text == null) return;
                var editValuesList = new List<string>();
                for (var i = 0; i < dgv.SelectedRows[0].Cells.Count; i++)
                    editValuesList.Add(dgv.SelectedRows[0].Cells[i].Value.ToString());
                var fields = _service.Tables.FirstOrDefault(t => t.Name == tabControl1.SelectedTab.Text)
                    .Fields.Select(field => field.Name).ToList();
                var frm = new FormEdit_Add_(_service, this, fields, tabControl1.SelectedTab.Text, editValuesList);
                frm.ShowDialog();
                ReloadTabs();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            var frm = new FormAdmin(this, _service);
            Hide();
            frm.ShowDialog();
        }

        private void buttonQuerry_Click(object sender, EventArgs e)
        {
            
            var frm = new FormQuerry(this);
            if (frm.ShowDialog() != DialogResult.OK) return;
            var q = frm.Index;
            frm.Close();

            for (var i = 0; i < tabControl1.TabCount; i++)
                if (tabControl1.TabPages[i].Text == "Запрос " + q)
                {
                    tabControl1.SelectTab(i);
                    return;
                }


            tabControl1.TabPages.Add(q.ToString(), "Запрос " + q);
            tabControl1.TabPages[tabControl1.TabPages.IndexOfKey(q.ToString())].Controls.Add(new DataGridView()
            {
                DataSource = _service.SelectQuery(frm.Query),
                Width = tabControl1.TabPages[q].Width,
                Height = tabControl1.TabPages[q].Height,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader,
                MultiSelect = false
            });
            tabControl1.SelectTab(tabControl1.TabPages.IndexOfKey(q.ToString()));
        }

        private void buttonShowMagazine_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < tabControl1.TabCount; i++)
                if (tabControl1.TabPages[i].Text == "Журнал")
                {
                    tabControl1.SelectTab(i);
                    return;
                }
            tabControl1.TabPages.Add("journal", "Журнал");
            for (var i = 0; i < tabControl1.TabCount; i++)
            {
                if (tabControl1.TabPages[i].Text != "Журнал") continue;
                tabControl1.TabPages[i].Controls.Add(new DataGridView()
                {
                    DataSource = _service.SelectFromTable("Журнал"),
                    Width = tabControl1.TabPages[i].Width,
                    Height = tabControl1.TabPages[i].Height,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect = false
                });
                tabControl1.SelectTab(tabControl1.TabPages.IndexOfKey("journal"));
            }
        }

        private void ReloadTabs()
        {
            for (var i = 0; i < tabControl1.TabCount; i++)
            {
                tabControl1.TabPages[i].Controls.Clear();
                if (_service.Tables.FirstOrDefault(t => t.Name == tabControl1.TabPages[i].Text).Fields.Count <= 5)
                {
                    tabControl1.TabPages[i].Controls.Add(new DataGridView()
                    {
                        DataSource = _service.SelectFromTable(tabControl1.TabPages[i].Text),
                        Width = tabControl1.TabPages[i].Width,
                        Height = tabControl1.TabPages[i].Height,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                        MultiSelect = false
                    });
                }
                else
                {
                    tabControl1.TabPages[i].Controls.Add(new DataGridView()
                    {
                        DataSource = _service.SelectFromTable(tabControl1.TabPages[i].Text),
                        Width = tabControl1.TabPages[i].Width,
                        Height = tabControl1.TabPages[i].Height,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader,
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                        MultiSelect = false
                    });
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var dgv = tabControl1.SelectedTab.Controls[0] as DataGridView;
                _service.DeleteFromTable(tabControl1.SelectedTab.Text,
                    Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value));
                ReloadTabs();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isLoginTried) return;
            _juornal.Add(DateTime.Now);
            _juornal.Add(true);
            _service.InsertQuery(_juornal, "Журнал");
        }
    }
}

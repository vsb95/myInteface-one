using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UserService;

namespace WindowsFormsApplication01
{
    public partial class FormEdit_Add_ : Form
    {
        private readonly string _tableName;
        private readonly UserService.UserService _service;
        private readonly Form _backForm;
        private readonly List<string> _record;


        public FormEdit_Add_(UserService.UserService service, Form backForm, List<string> columns,
            string tableName, List<string> record = null)
        {
            _service = service;
            _backForm = backForm;
            _tableName = tableName;
            _record = record;



            InitializeComponent();
            dataGridView1.ColumnCount = columns.Count;
            for (var i = 0; i < columns.Count; i++)
                dataGridView1.Columns[i].Name = columns[i];
            if (record != null)
            {
                dataGridView1.Rows.Add();
                for (var i = 0; i < record.Count; i++)
                    dataGridView1.Rows[0].Cells[i].Value = record[i];
            }
            else
                dataGridView1.Rows.Add();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            var values = new ArrayList();
            for (var i = 0; i < dataGridView1.Rows[0].Cells.Count; i++)
                values.Add(dataGridView1.Rows[0].Cells[i].Value);
            try
            {
                if (_record == null)
                    _service.InsertQuery(values, _tableName);
                else
                    _service.UpdateQuery(values, _tableName, Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormEdit_Add__Load(object sender, EventArgs e)
        {

        }
    }
}
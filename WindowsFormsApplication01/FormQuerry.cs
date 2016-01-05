using System;
using System.Windows.Forms;

namespace WindowsFormsApplication01
{
    public partial class FormQuerry : Form
    {
        private readonly Form _backForm;
        public string Query;
        public int Index;
        public FormQuerry(Form backForm)
        {
            _backForm = backForm;
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormQuerry_FormClosing(object sender, FormClosingEventArgs e)
        {
            _backForm.Show();
        }

        private void buttonQuerry1_Click(object sender, EventArgs e)
        {
            Query = "SELECT        dbo.[Форма 7-твн].* "
                    + "FROM dbo.[Форма 7-твн] "
                    + "INNER JOIN "
                    + "dbo.Организация ON dbo.[Форма 7-твн].[Код организации] = dbo.Организация.[Код организации] "
                    + "WHERE(dbo.Организация.Наименование = N'Юстерн')";
            Index = 1;
            DialogResult = DialogResult.OK;
            Hide();
            
        }

        private void buttonQuerry2_Click(object sender, EventArgs e)
        {
            Query = "SELECT        dbo.[Форма 7-твн].*, dbo.Исполнитель.ФИО "
                    + "FROM dbo.Исполнитель INNER JOIN "
                    +
                    "dbo.Организация ON dbo.Исполнитель.[Код исполнителя] = dbo.Организация.[Код исполнителя] INNER JOIN "
                    +
                    "dbo.[Форма 7-твн] ON dbo.Организация.[Код организации] = dbo.[Форма 7-твн].[Код организации] "
                    + "WHERE(dbo.Исполнитель.ФИО = N'Петров П.А')";
            DialogResult = DialogResult.OK;
            Index = 2;
            Hide();
        }

        private void buttonQuerry3_Click(object sender, EventArgs e)
        {
            Query = "SELECT Sum(dbo.[Форма 7-твн].[Женщин пострадавших] + dbo.[Форма 7-твн].[Женщин погибших]) AS Количество "
                    + "FROM dbo.[Форма 7-твн] "
                    + "INNER JOIN "
                    + "dbo.Организация ON dbo.[Форма 7-твн].[Код организации] = dbo.Организация.[Код организации] "
                    + "WHERE(dbo.Организация.Наименование = N'Юстерн')";
            Index = 3;
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void buttonQuerry4_Click(object sender, EventArgs e)
        {
            Query = "SELECT        Sum([Стоимость испорченного оборудования]) AS [Стоимость испорченного оборудования] "
                    + "FROM[Форма 7-твн]";
            Index = 4;
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}

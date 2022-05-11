using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Accounting
{
    public partial class periodsFm : Form
    {
        public periodsFm()
        {
            InitializeComponent();
            periodsTableAdapter.Connection = DataModule.Connection;
            Utils.SetDoubleBuffered(periodsGrid, true);
        }

        private void periodsFm_Load(object sender, EventArgs e)
        {
            this.periodsTableAdapter.Fill(this.accountingDS.Periods);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.periodsBindingSource.AddNew();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (periodsBindingSource.Count != 0 && MessageBox.Show("Удалить период?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.periodsBindingSource.RemoveCurrent();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.periodsBindingSource.EndEdit();
        }

        private void periodsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (accountingDS.Periods[e.RowIndex].State == 1)
                e.CellStyle.BackColor = ColorTranslator.FromHtml("#b2f3b2");
        }
    }
}

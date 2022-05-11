using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Accounting
{
    public partial class nomenclatureFm : Form
    {
        private BindingSource nomenclaturesBS = new BindingSource();
        
        public nomenclatureFm()
        {
            InitializeComponent();

            SelectDate();
        }

        #region Method's

        private void SelectDate()
        {
            DataModule.AccountingDS.Tables["Nomenclatures"].Rows.Clear();            
            DataModule.DataAdapter["Nomenclatures"].Fill(DataModule.AccountingDS.Tables["Nomenclatures"]);

            nomenclaturesBS.DataSource = DataModule.AccountingDS.Tables["Nomenclatures"];
            nomenclGrid.DataSource = nomenclaturesBS;

        }

        private bool _inserting;
        private void OpenNomenclatureEditFm(bool inserting)
        {
            _inserting = inserting;

            nomenclatureEditFm nomenclatureEditFm;

            nomenclatureEditFm = new nomenclatureEditFm(_inserting, nomenclaturesBS.Position, (int)((DataRowView)nomenclaturesBS.Current)["Id"]);

            nomenclatureEditFm.ShowDialog();

            int returnNomenclatureId = nomenclatureEditFm.Return();
            
            nomenclGridView.BeginDataUpdate();
            SelectDate();
            nomenclGridView.EndDataUpdate();
            int currentRowHandle = nomenclGridView.LocateByValue("ID", returnNomenclatureId);
            nomenclGridView.FocusedRowHandle = currentRowHandle;

        }

        private void DeleteNomenclature()
        {
            if (nomenclaturesBS.Count != 0 && MessageBox.Show("Видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int rowHandle = nomenclGridView.FocusedRowHandle;

                try
                {
                    nomenclaturesBS.RemoveCurrent();
                    DataModule.DataAdapter["Nomenclatures"].Update(DataModule.AccountingDS.Tables["Nomenclatures"]);
                    nomenclGridView.BeginDataUpdate();
                    SelectDate();
                    nomenclGridView.EndDataUpdate();
                    nomenclGridView.FocusedRowHandle = (nomenclGridView.IsValidRowHandle(rowHandle - 1)) ? (rowHandle - 1) : -1;
                }
                catch (FbException Excpt)
                {
                    DataModule.AccountingDS.Tables["Nomenclatures"].RejectChanges();
                    nomenclGridView.FocusedRowHandle = rowHandle;

                    MessageBox.Show(DataModule.GetError(Excpt), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }        
        }

        #endregion

        #region Click event's

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenNomenclatureEditFm(true);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (nomenclaturesBS.Count != 0)
            {
                OpenNomenclatureEditFm(false);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (nomenclaturesBS.Count != 0)
            {
                DeleteNomenclature();
            }
        }
        
        #endregion

        private void nomenclGridView_DoubleClick(object sender, EventArgs e)
        {
            if (nomenclaturesBS.Count != 0)
            {
                OpenNomenclatureEditFm(false);
            }
        }

        private void nomenclGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && nomenclaturesBS.Count > 0)
                DeleteNomenclature();

            if (e.KeyCode == Keys.Insert)
                OpenNomenclatureEditFm(true);
        }
    }
}

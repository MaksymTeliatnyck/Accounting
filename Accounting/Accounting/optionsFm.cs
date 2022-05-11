using System;
using System.Windows.Forms;

namespace Accounting
{
    public partial class optionsFm : Form
    {
        public optionsFm()
        {
            InitializeComponent();

            //serverNameTBox.Text = Properties.Settings.Default.ServerName;
            //dataBaseTBox.Text = Properties.Settings.Default.DataBase;
            //userTBox.Text = Properties.Settings.Default.UserName;
            //passwordTBox.Text = Properties.Settings.Default.Password;

            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                keybrdLangCBox.Items.Add(lang.Culture.Name);
            keybrdLangCBox.Text = Properties.Settings.Default.KeybrdLang;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.ServerName = serverNameTBox.Text.Replace(" ", "");
            //Properties.Settings.Default.DataBase = dataBaseTBox.Text.Replace(" ", "");
            //Properties.Settings.Default.UserName = userTBox.Text.Replace(" ", "");
            //Properties.Settings.Default.Password = passwordTBox.Text.Replace(" ", "");
            Properties.Settings.Default.KeybrdLang = keybrdLangCBox.Text;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

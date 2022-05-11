using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Accounting
{
    class WindowsPanel
    {
        private FlowLayoutPanel flowPanel;
        private ContextMenuStrip contextMenu = new ContextMenuStrip();

        private Font selectedFont = new Font("Microsoft Sans Serif", 8, FontStyle.Underline);
        private Font unselectedFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        private Font hoverFont = new Font("Microsoft Sans Serif", 8);

        private bool dragEnabled;

        public WindowsPanel(FlowLayoutPanel flowPanel, Image menuImage, bool dragEnabled = true)
        {
            this.flowPanel = flowPanel;
            this.dragEnabled = dragEnabled;
            contextMenu.Items.Add("Закрыть", menuImage).Click += closeTSMenuItem_Click;
            ((Form)flowPanel.Parent).MdiChildActivate += WindowsBarButton_MdiChildActivate;

            if (dragEnabled)
            {
                this.flowPanel.AllowDrop = true;
                this.flowPanel.DragEnter += new DragEventHandler(flowPanel_DragEnter);
                this.flowPanel.DragDrop += new DragEventHandler(flowPanel_DragDrop);
            }
        }

        private int FormCount = 0;
        private void WindowsBarButton_MdiChildActivate(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count != FormCount)
            {
                IEnumerable<Form> OpenForms = Application.OpenForms.Cast<Form>().Where(c => c != (Form)flowPanel.Parent && c.Name.Length != 0);
                if (OpenForms.Count() > flowPanel.Controls.Count)
                {
                    // Open Form
                    var newForm = OpenForms.Except(flowPanel.Controls.Cast<Button>().Select(c => (Form)c.Tag)).Single();
                    OpenForm(newForm);
                }
                else
                {
                    // Close Form
                    var closedButton = flowPanel.Controls.Cast<Button>().Where(c => (Form)c.Tag == flowPanel.Controls.Cast<Button>().Select(a => (Form)a.Tag).Except(OpenForms).Single()).Single();
                    CloseForm(closedButton);
                }
                FormCount = Application.OpenForms.Count;
            }

            for (int i = 0; i < flowPanel.Controls.Count; i++)
            {
                if (((Form)flowPanel.Controls[i].Tag) == ((Form)flowPanel.Parent).ActiveMdiChild)
                {
                    flowPanel.Controls[i].Font = selectedFont;
                    flowPanel.Controls[i].BackColor = Color.AliceBlue;
                }
                else
                {
                    flowPanel.Controls[i].Font = unselectedFont;
                    flowPanel.Controls[i].BackColor = Color.LightGray;
                }
            }
        }

        private void OpenForm(Form form)
        {
            Button Btn = new Button()
            {
                FlatStyle = FlatStyle.Popup,
                Margin = new Padding(1, 1, 1, 1),
                BackColor = Color.LightGray,
                Cursor = Cursors.Hand,
                AutoSize = true,
                Text = form.Text,
                Tag = form,
                Name = form.Name,
                ContextMenuStrip = contextMenu
            };
            Btn.Click += WindowsBarButton_Click;
            Btn.MouseHover += WindowsBarButton_MouseHover;
            Btn.MouseLeave += WindowsBarButton_MouseLeave;
            Btn.MouseDown += Btn_MouseDown;

            flowPanel.Controls.Add(Btn);
        }

        private void CloseForm(Button button)
        {
            button.Tag = null;
            flowPanel.Controls.Remove(button);
            button.Dispose();
        }

        private void WindowsBarButton_Click(object sender, EventArgs e)
        {
            (((Form)((Button)sender).Tag)).WindowState = FormWindowState.Normal;
            (((Form)((Button)sender).Tag)).Select();
        }

        private void WindowsBarButton_MouseHover(object sender, EventArgs e)
        {
            if ((((Form)((Button)sender).Tag)) != ((Form)flowPanel.Parent).ActiveMdiChild)
            {
                ((Button)sender).Font = hoverFont;
                ((Button)sender).BackColor = Color.LightBlue;
            }
        }

        private void WindowsBarButton_MouseLeave(object sender, EventArgs e)
        {
            if ((((Form)((Button)sender).Tag)) != ((Form)flowPanel.Parent).ActiveMdiChild)
            {
                ((Button)sender).Font = unselectedFont;
                ((Button)sender).BackColor = Color.LightGray;
            }
        }

        private void closeTSMenuItem_Click(object sender, EventArgs e)
        {
            ((Form)((Button)contextMenu.SourceControl).Tag).Close();
            WindowsBarButton_MdiChildActivate(flowPanel, new EventArgs());
        }

        #region Drag&Drop Buttons

        private void flowPanel_DragDrop(object sender, DragEventArgs e)
        {
            List<Control> controls = new List<Control>(flowPanel.Controls.Count); //We get a copy of the controls on the FlowLayoutPanel
            foreach (Control c in flowPanel.Controls)
            {
                controls.Add(c);
            }

            for (int i = 0; i < controls.Count; i++)
            {
                Point mouse = ((Form)flowPanel.Parent).PointToClient(new Point(e.X, e.Y));
                if (controls[i].Bounds.Contains(mouse.X - flowPanel.Left, mouse.Y - flowPanel.Top))
                //If the control is dragged to another control inside the FlowLayoutPanel, move the dragged control to that place.
                {
                    string name = (string)e.Data.GetData(typeof(string));
                    Control drag = ((Form)flowPanel.Parent).Controls.Find(name, true)[0];
                    Control temp = controls[i];
                    controls.RemoveAt(getIndex(drag.Name));
                    controls.Insert(i, drag);

                    flowPanel.Controls.Clear(); //Clear the controls
                    for (int j = 0; j < controls.Count; j++)
                    {
                        flowPanel.Controls.Add(controls[j]); //Readd all the Controls in new order
                    }
                    break;
                }
            }
        }

        private int getIndex(string name)
        {
            int result = -1;
            for (int i = 0; i < flowPanel.Controls.Count; i++)
            {
                if (flowPanel.Controls[i].Name == name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        private void flowPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                (sender as Button).DoDragDrop((sender as Button).Name, DragDropEffects.Move);
                WindowsBarButton_Click(sender, new EventArgs());
            }
        }

        #endregion Drag&Drop Buttons

    }
}

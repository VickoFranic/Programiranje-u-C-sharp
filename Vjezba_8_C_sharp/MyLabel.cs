using System;
using System.Windows.Forms;
using System.Drawing;

namespace Labs
{
    /// <summary>
    /// Summary description for MyLabel.
    /// </summary>
    public class MyLabel : System.Windows.Forms.Label
    {
        private bool _isOdd;
        ContextMenu cm = new ContextMenu();

        public MyLabel(int index)
        {
            int width = 250;
            int height = 80;

            this.Text = System.Convert.ToString(index);
            this.Size = new Size(width, height);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AllowDrop = true;

            int n = index / 2;
            if ((index % 2) == 0)
            {
                _isOdd = false;
                this.Location = new Point(width, (n - 1) * height);
            }
            else
            {
                _isOdd = true;
                this.Location = new Point(0, n * height);
            }

            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyLabel_DragEnter);
            this.DragLeave += new System.EventHandler(this.MyLabel_DragLeave);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyLabel_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyLabel_MouseDown);

            /**
             * Create new menu item for context menu on label construction
             */
            MenuItem menuItem1 = new MenuItem("Show Person data");
            menuItem1.Click += new System.EventHandler(this.ShowPersonData_Click);
            cm.MenuItems.Add(menuItem1);
        }



        private void MyLabel_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            MyLabel label = (MyLabel)sender;
            ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
            Person inMovePerson = (Person)lvi.Tag;

            bool isOddInMovePerson;
            if (inMovePerson.Index % 2 == 0)
            {
                isOddInMovePerson = false;
            }
            else
            {
                isOddInMovePerson = true;
            }

            if (label.Tag == null && (isOddInMovePerson == this._isOdd))
            {
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                e.Effect = DragDropEffects.Move;
            }
        }

        private void MyLabel_DragLeave(object sender, System.EventArgs e)
        {
            MyLabel label = (MyLabel)sender;
            if (label.BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
            {
                label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            }
        }

        private void MyLabel_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
            Person dropedPerson = (Person)lvi.Tag;

            this.Text = dropedPerson.Name + " " + dropedPerson.LastName;
            this.Tag = lvi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyLabel
            // 

            this.ResumeLayout(false);

        }

        /**
         * If left click, DoDragDrop
         * If right click, show ContextMenu for label
         */
        private void MyLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewItem lvi = (ListViewItem)this.Tag;
                this.Text = ((Person)lvi.Tag).Index.ToString();

                // Start Drag and drop process
                this.DoDragDrop(this.Tag, DragDropEffects.Copy);
                this.Tag = null;
            }
            else if (e.Button == MouseButtons.Right)
            {
                cm.Show(this, new Point(e.X, e.Y));
            }
        }

        /**
         * Show person properties form on context menu item click
         */
        private void ShowPersonData_Click(object sender, System.EventArgs e)
        {
            ListViewItem lvi = (ListViewItem)this.Tag;
            Person p = (Person)lvi.Tag;

            PersonPropertiesForm ppf = new PersonPropertiesForm(p);
            ppf.ShowDialog(this);
            if (ppf.DialogResult == DialogResult.OK)
            {
                try
                {
                    p.Name = ppf.getNameTextBoxText();
                    p.LastName = ppf.getLastNameTextBoxText();
                    p.Age = System.Convert.ToInt32(ppf.getAgeTextBoxText());
                    p.City = ppf.getCityComboBoxText();

                    this.Text = p.Name + ' ' + p.LastName;
                }
                catch
                {

                }

            }
            ppf.Dispose();
        }


    }
}

using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Labs
{
	/// <summary>
	/// Summary description for MyLabel.
	/// </summary>
	public class MyLabel:System.Windows.Forms.Label
    {
        private bool _isOdd;
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip contextMenuStrip1;
        private int ind;

		public MyLabel(int index)
		{			
			int width=250;
			int height=80;
            ind = index;

			this.Text=System.Convert.ToString(index);
			this.Size=new Size(width,height);			
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

			this.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.AllowDrop=true;

			int n=index/2;
			if((index %2)==0)
			{
				_isOdd=false;
				this.Location=new Point(width,(n-1)*height);
			}
			else
			{
				_isOdd=true;				
				this.Location=new Point(0,n*height);
			}

			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyLabel_DragEnter);
			this.DragLeave += new System.EventHandler(this.MyLabel_DragLeave);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyLabel_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyLabel_MouseDown);
//            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
		}

      

		private void MyLabel_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{			
			MyLabel label =(MyLabel)sender;
			ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
			Person inMovePerson = (Person)lvi.Tag;
			
			bool isOddInMovePerson;
			if(inMovePerson.Index % 2==0)
			{
				isOddInMovePerson=false;
			}
			else 
			{
				isOddInMovePerson=true;
			}

			if(label.Tag==null && (isOddInMovePerson==this._isOdd)) 
			{
				label.BorderStyle= System.Windows.Forms.BorderStyle.FixedSingle;
				e.Effect = DragDropEffects.Move;
			}
		}

		private void MyLabel_DragLeave(object sender, System.EventArgs e)
		{
			MyLabel label =(MyLabel)sender;
			if(label.BorderStyle== System.Windows.Forms.BorderStyle.FixedSingle)
			{
				label.BorderStyle= System.Windows.Forms.BorderStyle.Fixed3D;				
			}
		}

		private void MyLabel_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{					
			ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
			Person dropedPerson = (Person)lvi.Tag;
			
			this.Text=dropedPerson.Name+" "+dropedPerson.LastName;
            this.Tag=lvi;
			this.BorderStyle= System.Windows.Forms.BorderStyle.Fixed3D;
		}

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);

            ToolStripMenuItem tsmi = new ToolStripMenuItem("Edit Person Data");
            this.contextMenuStrip1.Items.Add(tsmi);

            this.ResumeLayout(false);

        }

        private void MyLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Text = this.ind.ToString();
                DoDragDrop(this.Tag, DragDropEffects.Move);
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                CancelEventArgs cea = new CancelEventArgs(false);
                this.contextMenuStrip1_Opening(this, cea);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
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

                    lvi.SubItems[0].Text = p.Name;
                    lvi.SubItems[1].Text = p.LastName;

                    this.Text = p.Name + " " + p.LastName;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }
            ppf.Dispose();
        }

	}
}

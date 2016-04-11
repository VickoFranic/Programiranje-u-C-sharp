using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Labs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Lab2AppForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Lab2AppForm()
		{
			//
			// Required for Windows Form Designer support
			//
			
			InitializeComponent();
			DataModel dm = new DataModel();
						

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Left;
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 304);
			this.button1.TabIndex = 0;
			this.button1.Text = "Insert new shape";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(112, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(464, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "List of all inserted elements:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(112, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(464, 276);
			this.listBox1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label2.Location = new System.Drawing.Point(112, 272);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(464, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "Total area=0, Total perimeter=0";
			// 
			// Lab2AppForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(576, 304);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.listBox1,
																		  this.label1,
																		  this.button1});
			this.Name = "Lab2AppForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lab2";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Lab2AppForm());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{			
			AddShapeForm asf=new AddShapeForm();
			asf.ShowDialog(this);

			if (asf.DialogResult == DialogResult.OK)
			{
				//to do
				asf.Dispose();
			}

		}
		

	}
}

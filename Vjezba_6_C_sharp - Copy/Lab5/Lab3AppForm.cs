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
	public class Lab3AppForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private IContainer components;

		public Lab3AppForm()
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Circle");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Square");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Triangle");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Shape", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem1});
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6});
            this.menuItem5.Text = "File";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "Exit";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem4});
            this.menuItem1.Text = "Insert";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Circle";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Square";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "Triangle";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total area=0, Total perimeter=0";
            // 
            // treeView1
            // 
            this.treeView1.ContextMenu = this.contextMenu1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "";
            treeNode5.Text = "Circle";
            treeNode6.Name = "";
            treeNode6.Text = "Square";
            treeNode7.Name = "";
            treeNode7.Text = "Triangle";
            treeNode8.Name = "";
            treeNode8.Text = "Shape";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(480, 250);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenu1
            // 
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // Lab3AppForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(480, 271);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Lab3AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab3";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Lab3AppForm());
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			string tagFullName="";
			if(selectedNode.Tag!=null)
			{
                tagFullName=selectedNode.Tag.GetType().FullName;
			}


			contextMenu1.MenuItems.Clear();
			
			if(selectedNode.Text=="Circle")
			{ 
				MenuItem menuItem1 = new MenuItem("Insert circle");
				menuItem1.Click += new System.EventHandler(this.insertCircle_Click);
				contextMenu1.MenuItems.Add(menuItem1);				
			}
			else if(selectedNode.Text=="Square")
			{ 
				MenuItem menuItem1 = new MenuItem("Insert square");
				menuItem1.Click += new System.EventHandler(this.insertSquare_Click);
				contextMenu1.MenuItems.Add(menuItem1);				
			}
			else if(selectedNode.Text=="Triangle")
			{ 
				MenuItem menuItem1 = new MenuItem("Insert triangle");
				menuItem1.Click += new System.EventHandler(this.insertTriangle_Click);
				contextMenu1.MenuItems.Add(menuItem1);				
			}
			else if(tagFullName=="Labs.Circle")
			{
				MenuItem menuItem1 = new MenuItem("Show circle properties");
				menuItem1.Click += new System.EventHandler(this.showCircleData_Click);
				contextMenu1.MenuItems.Add(menuItem1);
			}
			else if(tagFullName=="Labs.Square")
			{
				MenuItem menuItem1 = new MenuItem("Show square properties");
				menuItem1.Click += new System.EventHandler(this.showSquareData_Click);
				contextMenu1.MenuItems.Add(menuItem1);
			}
			else if(tagFullName=="Labs.Triangle")
			{
				MenuItem menuItem1 = new MenuItem("Show triangle properties");
				menuItem1.Click += new System.EventHandler(this.showTriangleData_Click);
				contextMenu1.MenuItems.Add(menuItem1);
			}
		
		}

		private void insertCircle_Click(object sender, System.EventArgs e)
		{
			AddShapeForm asf=new AddShapeForm(1);
			asf.ShowDialog(this);

			if (asf.DialogResult == DialogResult.OK)
			{
				if(asf.getSelectedType()==1)
				{
					Circle circle = new Circle(asf.getTextBoxInput());
					DataModel.getAllElementsList().Add(circle);	
					TreeNode tn = new TreeNode();
					tn.Text=circle.ToString();
					tn.Tag=circle;
					treeView1.Nodes[0].Nodes[0].Nodes.Add(tn);									

				}				

				label1.Text="Total area="+DataModel.getTotalArea()+", Total perimeter="+DataModel.getTotalPerimeter();
				asf.Dispose();
			}
		}

		private void insertSquare_Click(object sender, System.EventArgs e)
		{
            AddShapeForm asf = new AddShapeForm(2);
            asf.ShowDialog(this);

            if (asf.DialogResult == DialogResult.OK)
            {
                if (asf.getSelectedType() == 2)
                {
                    Square square = new Square(asf.getTextBoxInput());
                    DataModel.getAllElementsList().Add(square);
                    TreeNode tn = new TreeNode();
                    tn.Text = square.ToString();
                    tn.Tag = square;
                    treeView1.Nodes[0].Nodes[1].Nodes.Add(tn);

                }

                label1.Text = "Total area=" + DataModel.getTotalArea() + ", Total perimeter=" + DataModel.getTotalPerimeter();
                asf.Dispose();
            }
		}

		private void insertTriangle_Click(object sender, System.EventArgs e)
		{
            AddShapeForm asf = new AddShapeForm(3);
            asf.ShowDialog(this);

            if (asf.DialogResult == DialogResult.OK)
            {
                if (asf.getSelectedType() == 3)
                {
                    Triangle triangle = new Triangle(asf.getTextBoxInput());
                    DataModel.getAllElementsList().Add(triangle);
                    TreeNode tn = new TreeNode();
                    tn.Text = triangle.ToString();
                    tn.Tag = triangle;
                    treeView1.Nodes[0].Nodes[2].Nodes.Add(tn);

                }

                label1.Text = "Total area=" + DataModel.getTotalArea() + ", Total perimeter=" + DataModel.getTotalPerimeter();
                asf.Dispose();
            }	
		}

		private void showCircleData_Click(object sender, System.EventArgs e)
		{			
			TreeNode tn= treeView1.SelectedNode;
			Circle circle =(Circle)tn.Tag;
			string message = "";
			message+="Radius="+circle.getRadius();
			message+="\nX pos="+circle.getXPos();
			message+="\nY pos="+circle.getYPos();
								
			string caption = "Circle properties";
			MessageBoxButtons buttons = MessageBoxButtons.OK;					
		
			MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);			

		}

		private void showSquareData_Click(object sender, System.EventArgs e)
		{
            TreeNode tn = treeView1.SelectedNode;
            Square square = (Square)tn.Tag;
            string message = "";
            message += "Radius=" + square.getSide();
            message += "\nX pos=" + square.getXPos();
            message += "\nY pos=" + square.getYPos();

            string caption = "Square properties";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);			
		}

		private void showTriangleData_Click(object sender, System.EventArgs e)
		{
            TreeNode tn = treeView1.SelectedNode;
            Triangle triangle = (Triangle)tn.Tag;
            string message = "";
            message += "Radius=" + triangle.getSide();
            message += "\nX pos=" + triangle.getXPos();
            message += "\nY pos=" + triangle.getYPos();

            string caption = "Triangle properties";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);	
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.insertCircle_Click(sender, e);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            this.insertSquare_Click(sender, e);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            this.insertTriangle_Click(sender, e);
        }	

		
	}
}

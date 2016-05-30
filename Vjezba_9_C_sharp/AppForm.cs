using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Labs
{
	/// <summary>
	/// Summary description for AppForm.
	/// </summary>
	public class AppForm : System.Windows.Forms.Form
	{
		private static AppForm APP_FORM;
		private CommandProcessor _cmdProcessor;
		public static TreeNode PERSONS_ROOT_NODE;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton _undoToolBarButton;
		private System.Windows.Forms.ToolBarButton _redoToolBarButton;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.ComponentModel.IContainer components;

		public AppForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			APP_FORM=this;

			PERSONS_ROOT_NODE=new TreeNode("Persons");
			treeView1.Nodes.Add(PERSONS_ROOT_NODE);

			_cmdProcessor=new CommandProcessor();
			_cmdProcessor.setUnReButtonState();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AppForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this._undoToolBarButton = new System.Windows.Forms.ToolBarButton();
			this._redoToolBarButton = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "New Person";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// treeView1
			// 
			this.treeView1.ContextMenu = this.contextMenu1;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(0, 28);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(504, 299);
			this.treeView1.Sorted = true;
			this.treeView1.TabIndex = 0;
			this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
			// 
			// contextMenu1
			// 
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this._undoToolBarButton,
																						this._redoToolBarButton});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(504, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// _undoToolBarButton
			// 
			this._undoToolBarButton.ImageIndex = 0;
			// 
			// _redoToolBarButton
			// 
			this._redoToolBarButton.ImageIndex = 1;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// AppForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 327);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.toolBar1);
			this.Menu = this.mainMenu1;
			this.Name = "AppForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Undo/Redo Lab";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new AppForm());
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			PersonPropertiesForm ppf=new PersonPropertiesForm();
			ppf.ShowDialog(this);
			if(ppf.DialogResult==DialogResult.OK)
			{
				try
				{
					string name=ppf.getNameTextBoxText();
					string lastName=ppf.getLastNameTextBoxText();
					int age=System.Convert.ToInt32(ppf.getAgeTextBoxText());
					string city=ppf.getCityComboBoxText();
					
					Person p=new Person(name,lastName,age,city);

					AddPersonCmd apc=new AddPersonCmd(p);
					_cmdProcessor.doCmd(apc);

				}
				catch
				{
					
				}

			}

			ppf.Dispose();
		
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			contextMenu1.MenuItems.Clear();
			
			if(selectedNode.GetType().FullName=="Labs.Person") 			
			{ 
				MenuItem menuItem1 = new MenuItem("Show person data");
				menuItem1.Click += new System.EventHandler(showData_Click);
				contextMenu1.MenuItems.Add(menuItem1);
				contextMenu1.MenuItems.Add(new MenuItem("-"));

				MenuItem menuItem2 = new MenuItem("Delete person");
				menuItem2.Click += new System.EventHandler(delPerson_Click);
				contextMenu1.MenuItems.Add(menuItem2);				
			} 
		}

		private void tv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TreeView tv = (TreeView)sender;
			TreeNode tn = tv.GetNodeAt(e.X,e.Y);
			if(tn!=null) tv.SelectedNode=tn;
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button==_undoToolBarButton)
			{
				_cmdProcessor.undoLastCmd();
				
			}
			else if(e.Button==_redoToolBarButton)
			{
				_cmdProcessor.redoLastUndone();
			}

		}

		public static AppForm getAppForm()
		{
			return APP_FORM;
		}

		public ToolBarButton getUndoToolBarButton()
		{
			return _undoToolBarButton;
		}
		
		public ToolBarButton getRedoToolBarButton()
		{
			return _redoToolBarButton;
		}

		private void showData_Click(object sender, System.EventArgs e)
		{	
			Person p =(Person)treeView1.SelectedNode;

			PersonPropertiesForm ppf=new PersonPropertiesForm(p);
            
            ChangePersonDataCmd cpdc = new ChangePersonDataCmd(p);
            _cmdProcessor.doCmd(cpdc);

			ppf.ShowDialog(this);
			if(ppf.DialogResult==DialogResult.OK)
			{
				try
				{
					string newName=ppf.getNameTextBoxText();
					string newLastName=ppf.getLastNameTextBoxText();
					int newAge=System.Convert.ToInt32(ppf.getAgeTextBoxText());
					string newCity=ppf.getCityComboBoxText();

					if(p.Name!=newName || p.LastName!=newLastName || p.Age!=newAge || p.City!=newCity)
					{
						p.Name=newName;
						p.LastName=newLastName;
						p.Age=newAge;
						p.City=newCity;

						p.updateTreeText();
					}					
				}
				catch
				{
					
				}
			}

			ppf.Dispose();

		}

		private void delPerson_Click(object sender, System.EventArgs e)
		{	
			Person p =(Person)treeView1.SelectedNode;
			DeletePersonCmd dpc=new DeletePersonCmd(p);
			_cmdProcessor.doCmd(dpc);
		}

		public TreeView MyTreeView
		{
			get
			{
				return treeView1;
			}

		}

		
	}
}

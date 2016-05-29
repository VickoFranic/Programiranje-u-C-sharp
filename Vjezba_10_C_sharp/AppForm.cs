using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

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
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton _undoToolBarButton;
		private System.Windows.Forms.ToolBarButton _redoToolBarButton;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem _newPersonMenuItem;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem _saveBinaryMenuItem;
		private System.Windows.Forms.MenuItem _openBinaryMenuItem;
		private System.Windows.Forms.MenuItem _openTextMenuItem;
		private System.Windows.Forms.MenuItem _saveTextMenuItem;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem _saveSOAPMenuItem;
		private System.Windows.Forms.MenuItem _openSOAPMenuItem;
		private System.ComponentModel.IContainer components;

		public AppForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			APP_FORM=this;

            setFormProperties();

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

        public void setFormProperties()
        {
            string formInfo = File.ReadAllText(@"./files/formInfo.json");
            FormInfo fi = JsonConvert.DeserializeObject<FormInfo>(formInfo);

            APP_FORM.Width = fi.width;
            APP_FORM.Height = fi.height;
            APP_FORM.Location = new Point(fi.xPos, fi.yPos);
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this._saveTextMenuItem = new System.Windows.Forms.MenuItem();
            this._openTextMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this._saveBinaryMenuItem = new System.Windows.Forms.MenuItem();
            this._openBinaryMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this._saveSOAPMenuItem = new System.Windows.Forms.MenuItem();
            this._openSOAPMenuItem = new System.Windows.Forms.MenuItem();
            this._newPersonMenuItem = new System.Windows.Forms.MenuItem();
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
            this.menuItem2,
            this._newPersonMenuItem});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._saveTextMenuItem,
            this._openTextMenuItem,
            this.menuItem4,
            this._saveBinaryMenuItem,
            this._openBinaryMenuItem,
            this.menuItem1,
            this._saveSOAPMenuItem,
            this._openSOAPMenuItem});
            this.menuItem2.Text = "File";
            // 
            // _saveTextMenuItem
            // 
            this._saveTextMenuItem.Index = 0;
            this._saveTextMenuItem.Text = "Save Text";
            this._saveTextMenuItem.Click += new System.EventHandler(this._saveTextMenuItem_Click);
            // 
            // _openTextMenuItem
            // 
            this._openTextMenuItem.Index = 1;
            this._openTextMenuItem.Text = "Open Text";
            this._openTextMenuItem.Click += new System.EventHandler(this._openTextMenuItem_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // _saveBinaryMenuItem
            // 
            this._saveBinaryMenuItem.Index = 3;
            this._saveBinaryMenuItem.Text = "Save Binary";
            this._saveBinaryMenuItem.Click += new System.EventHandler(this._saveBinaryMenuItem_Click);
            // 
            // _openBinaryMenuItem
            // 
            this._openBinaryMenuItem.Index = 4;
            this._openBinaryMenuItem.Text = "Open Binary";
            this._openBinaryMenuItem.Click += new System.EventHandler(this._openBinaryMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 5;
            this.menuItem1.Text = "-";
            // 
            // _saveSOAPMenuItem
            // 
            this._saveSOAPMenuItem.Index = 6;
            this._saveSOAPMenuItem.Text = "Save SOAP";
            this._saveSOAPMenuItem.Click += new System.EventHandler(this._saveSOAPMenuItem_Click);
            // 
            // _openSOAPMenuItem
            // 
            this._openSOAPMenuItem.Index = 7;
            this._openSOAPMenuItem.Text = "Open SOAP";
            this._openSOAPMenuItem.Click += new System.EventHandler(this._openSOAPMenuItem_Click);
            // 
            // _newPersonMenuItem
            // 
            this._newPersonMenuItem.Index = 1;
            this._newPersonMenuItem.Text = "New Person";
            this._newPersonMenuItem.Click += new System.EventHandler(this._newPersonMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.ContextMenu = this.contextMenu1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(503, 298);
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
            this.toolBar1.Size = new System.Drawing.Size(503, 28);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // _undoToolBarButton
            // 
            this._undoToolBarButton.ImageIndex = 0;
            this._undoToolBarButton.Name = "_undoToolBarButton";
            // 
            // _redoToolBarButton
            // 
            this._redoToolBarButton.ImageIndex = 1;
            this._redoToolBarButton.Name = "_redoToolBarButton";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // AppForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(503, 326);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolBar1);
            this.Menu = this.mainMenu1;
            this.Name = "AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "I/O & Serialization Lab";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

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

		private void _newPersonMenuItem_Click(object sender, System.EventArgs e)
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

						ChangePersonDataCmd cpdc=new ChangePersonDataCmd(p,newName,newLastName,newAge,newCity);
						_cmdProcessor.doCmd(cpdc);

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

		private void _saveBinaryMenuItem_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter="Person files (*.per)|*.per";
			saveFileDialog.InitialDirectory = "." ;
			
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Stream myStream = null;
				if((myStream=saveFileDialog.OpenFile())!=null)
				{
					BinaryFormatter myBinaryFormat = new BinaryFormatter();					
					myBinaryFormat.Serialize(myStream,PERSONS_ROOT_NODE);

					myStream.Close();
				}				
			}

			saveFileDialog.Dispose();
		
		}

		private void _openBinaryMenuItem_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog myOpenFileDialog = new OpenFileDialog();
			myOpenFileDialog.InitialDirectory=".";
			myOpenFileDialog.Filter="Person files (*.per)|*.per";
			if(myOpenFileDialog.ShowDialog()==DialogResult.OK)
			{
				Stream myStream = null;
				if((myStream=myOpenFileDialog.OpenFile())!=null)
				{
					
					BinaryFormatter myBinaryFormat = new BinaryFormatter();					
					PERSONS_ROOT_NODE=(TreeNode)myBinaryFormat.Deserialize(myStream);
					myStream.Close();		
			
					treeView1.Nodes.Clear();
					treeView1.Nodes.Add(PERSONS_ROOT_NODE);

					PERSONS_ROOT_NODE.Expand();

					_cmdProcessor.clearStacks();
					_cmdProcessor.setUnReButtonState();
					
				}


			}


			


		
		}

		private void _saveTextMenuItem_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter="Text files (*.txt)|*.txt";
			saveFileDialog.InitialDirectory = "." ;
			
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileInfo f= new FileInfo(saveFileDialog.FileName);
				StreamWriter writer = f.CreateText();
				foreach(Person p in PERSONS_ROOT_NODE.Nodes)
				{
					writer.WriteLine(p.Name+","+p.LastName+","+p.Age+","+p.City);
				}

				writer.Close();
			}

			saveFileDialog.Dispose();		
		
		}

		private void _openTextMenuItem_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog myOpenFileDialog = new OpenFileDialog();
			myOpenFileDialog.InitialDirectory=".";
			myOpenFileDialog.Filter="Text files (*.txt)|*.txt";
			if(myOpenFileDialog.ShowDialog()==DialogResult.OK)
			{
				PERSONS_ROOT_NODE.Nodes.Clear();
				StreamReader sr= System.IO.File.OpenText(myOpenFileDialog.FileName);
				string input=null;
				char[] delimiter=new char[1]{','};
				while((input=sr.ReadLine())!=null)
				{
					string [] allData = input.Split(delimiter,4);
					Person p = new Person(allData[0],allData[1],System.Convert.ToInt32(allData[2]),allData[3]);
					PERSONS_ROOT_NODE.Nodes.Add(p);                    
				}
				sr.Close();
				PERSONS_ROOT_NODE.Expand();

				_cmdProcessor.clearStacks();
				_cmdProcessor.setUnReButtonState();
			}

			myOpenFileDialog.Dispose();
		
		}

		private void _saveSOAPMenuItem_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter="SOAP files (*.xml)|*.xml";
			saveFileDialog.InitialDirectory = "." ;
			
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Stream myStream = null;
				if((myStream=saveFileDialog.OpenFile())!=null)
				{					
					SoapFormatter mySoapFormat = new SoapFormatter();
					mySoapFormat.Serialize(myStream,PERSONS_ROOT_NODE);

					myStream.Close();
				}				
			}

			saveFileDialog.Dispose();

		
		}

		private void _openSOAPMenuItem_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog myOpenFileDialog = new OpenFileDialog();
			myOpenFileDialog.InitialDirectory=".";
			myOpenFileDialog.Filter="SOAP files (*.xml)|*.xml";
			if(myOpenFileDialog.ShowDialog()==DialogResult.OK)
			{
				Stream myStream = null;
				if((myStream=myOpenFileDialog.OpenFile())!=null)
				{					
					SoapFormatter mySoapFormat = new SoapFormatter();
					PERSONS_ROOT_NODE=(TreeNode)mySoapFormat.Deserialize(myStream);
					
					myStream.Close();		
			
					treeView1.Nodes.Clear();
					treeView1.Nodes.Add(PERSONS_ROOT_NODE);

					PERSONS_ROOT_NODE.Expand();

					_cmdProcessor.clearStacks();
					_cmdProcessor.setUnReButtonState();
					
				}

			}

			myOpenFileDialog.Dispose();		
		}		
		
		public TreeView MyTreeView
		{
			get
			{
				return treeView1;
			}

		}

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /**
             * Create new FormInfo object with form data to be serialized and written to file
             */
            FormInfo form = new FormInfo(APP_FORM.Width, APP_FORM.Height, APP_FORM.Location.X, APP_FORM.Location.Y);
            form.serialize();
        }
		
	}
}

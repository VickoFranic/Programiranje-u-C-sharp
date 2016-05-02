using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Vjezba_5
{
    public partial class PersonsListForm : Form
    {
        public PersonsListForm()
        {
            InitializeComponent();
        }

        private void newPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonAddOrEditForm addOrEditForm = new PersonAddOrEditForm();
            addOrEditForm.ShowDialog(this);
            
            if (addOrEditForm.DialogResult == DialogResult.OK)
            {
                // Get Person model for ListView
                Person p = addOrEditForm.newPerson;

                // Save new person to repository
                PersonRepository.savePerson(p);

                // Create ListView item to append
                ListViewItem item = new ListViewItem(new []{ p.Name, p.LastName });
                listView1.Items.Add(item);

                addOrEditForm.Dispose();
            }
        }

    }
}

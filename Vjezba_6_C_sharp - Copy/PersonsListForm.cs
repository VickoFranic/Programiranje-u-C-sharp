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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            int index = item.Index;

            Person p = PersonRepository.getAllPersons()[index];

            PersonAddOrEditForm editPerson = new PersonAddOrEditForm(p);

            editPerson.ShowDialog(this);

            if (editPerson.DialogResult == DialogResult.OK)
            {
                // Get Person model for ListView
                Person pr = editPerson.newPerson;

                // Save new person to repository
                PersonRepository.getAllPersons()[index] = pr;

                // Create ListView item to append
                ListViewItem listItem = new ListViewItem(new[] { pr.Name, pr.LastName });
                listView1.Items.RemoveAt(index);
                listView1.Items.Insert(index, listItem);


                editPerson.Dispose();
            }
            
        }

    }
}

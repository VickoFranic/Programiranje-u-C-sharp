using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vjezba_5
{
    public partial class PersonAddOrEditForm : Form
    {
        public Person newPerson = new Person();

        public PersonAddOrEditForm(Person p)
        {
            InitializeComponent();

            newPerson = p;
            textBox1.Text = p.Name;
            textBox2.Text = p.LastName;
            textBox3.Text = p.Age.ToString();
        }

        public PersonAddOrEditForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Person person = new Person(textBox1.Text, textBox2.Text, comboBox1.Text, int.Parse(textBox3.Text));
                newPerson = person;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

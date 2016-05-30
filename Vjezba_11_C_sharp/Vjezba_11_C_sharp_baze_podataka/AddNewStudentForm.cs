using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vjezba_11_C_sharp_baze_podataka
{
    public partial class AddNewStudentForm : Form
    {
        StudentiEntities DB;

        public AddNewStudentForm()
        {
            DB = new StudentiEntities();

            InitializeComponent();

            populateListBoxWithCourses();
        }

        /**
         * Choose courses for student - checkedListBox
         */
        private void populateListBoxWithCourses()
        { 
            var allCourses = from course in DB.Predmeti
                             select course;

            foreach (Predmeti course in allCourses)
            {
                checkedListBox1.Items.Add(course.Naziv);
            }
            

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        /**
         * Save new student to database
         */
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string lastName = textBox2.Text;

                Studenti newStudent = new Studenti();
                newStudent.Ime = name;
                newStudent.Prezime = lastName;

                foreach (object checkedItem in checkedListBox1.CheckedItems)
                {
                    var courseQuery = from course in DB.Predmeti
                                      where course.Naziv == checkedItem.ToString()
                                      select course;

                    newStudent.Predmeti.
                    newStudent.Predmeti.Add((Predmeti)courseQuery);
                }

                DB.Studenti.AddObject(newStudent);
                DB.SaveChanges();

                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}

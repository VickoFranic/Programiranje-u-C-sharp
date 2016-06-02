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
    public partial class AppForm : Form
    {
        public static StudentiEntities DB;
   
        public AppForm()
        {
            DB = new StudentiEntities();

            InitializeComponent();

            populateForm();
        }

        /**
         * Fetch data from DB and populate List View of Students and Courses
         */
        private void populateForm()
        {
      
            var allStudents = from student in DB.Studenti
                           select student;

            foreach (Studenti student in allStudents)
            {
                ListViewItem lvi = new ListViewItem(student.Id.ToString());
                lvi.SubItems.Add(student.Ime);
                lvi.SubItems.Add(student.Prezime);
                lvi.Tag = student;

                listView1.Items.Add(lvi);
            }

            var allCourses = (from course in DB.Predmeti
                             select course).Distinct();

            foreach (Predmeti course in allCourses)
            {
                ListViewItem lvi = new ListViewItem(course.Id.ToString());
                lvi.SubItems.Add(course.Naziv);
                listView2.Items.Add(lvi);
            }
        }

        /**
         * Double click on ID of student - show student form
         */
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StudentForm sf;
            Studenti student = listView1.SelectedItems[0].Tag as Studenti;

            if (student != null)
            {
                sf = new StudentForm(student);

                sf.ShowDialog();

                if (sf.DialogResult == System.Windows.Forms.DialogResult.OK || sf.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    sf.Dispose();
                }
            }

        }

        /**
         * Add new student form
         * TO DO 
         */
        private void button1_Click(object sender, EventArgs e)
        {
            // Add new student form
            AddNewStudentForm ansf = new AddNewStudentForm();

            ansf.ShowDialog();

            if (ansf.DialogResult == System.Windows.Forms.DialogResult.OK)
            { 
                // Refresh student list
            }

            if (ansf.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                ansf.Dispose();
            }
            
        }

    }
}

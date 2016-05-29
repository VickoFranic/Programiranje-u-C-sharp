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
    public partial class StudentForm : Form
    {
        StudentiEntities DB;
        private Studenti _student;

        public StudentForm(Studenti student)
        {
            DB = new StudentiEntities();
            _student = student;

            InitializeComponent();

            populateStudentData();
            populateCoursesForStudent();
        }

        /**
         * Populate form with student data - name and last name
         */
        private void populateStudentData()
        {
            textBox1.Text = _student.Ime;
            textBox2.Text = _student.Prezime;
        }

        /**
         * Populate List View of courses for student
         */
        private void populateCoursesForStudent()
        {
            var query = from student in DB.Studenti
                               where student.Id == _student.Id
                               select student.Predmeti;


            foreach (var entities in query)
            {
                foreach (Predmeti course in entities)
                {
                    ListViewItem lvi = new ListViewItem(((Predmeti)course).Id.ToString());
                    lvi.SubItems.Add(course.Naziv);

                    listView1.Items.Add(lvi);   
                }
            }
        }

        /**
         * Delete student from database
         */
        private void button1_Click(object sender, EventArgs e)
        {
            // Delete student
        }


    }
}

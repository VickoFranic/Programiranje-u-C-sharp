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
   
        public AppForm()
        {
            InitializeComponent();

            populateForm();
        }

        protected void populateForm()
        {
            StudentiEntities DB = new StudentiEntities();

            var allStudents = from student in DB.Studenti
                           select student;

            foreach (Studenti student in allStudents)
            {
                ListViewItem lvi = new ListViewItem(student.Id.ToString());
                lvi.SubItems.Add(student.Ime);
                lvi.SubItems.Add(student.Prezime);

                listView1.Items.Add(lvi);
            }

            var allCourses = from course in DB.Predmeti
                             select course;

            foreach (Predmeti course in allCourses)
            {
                ListViewItem lvi = new ListViewItem(course.Id.ToString());
                lvi.SubItems.Add(course.Naziv);

                listView2.Items.Add(lvi);
            }
        }

    }
}

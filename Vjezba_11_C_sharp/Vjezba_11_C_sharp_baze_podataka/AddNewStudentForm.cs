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
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zh3_gyak.Models;

namespace zh3_gyak
{
    public partial class UserControl1 : UserControl
    {
        StudiesContext studiesContext = new StudiesContext();
        public UserControl1()
        {
            InitializeComponent();

            FillDataSource();
            listBox1.DisplayMember = "Name";

        }
        private void FillDataSource()
        {
            listBox1.DataSource = (from i in studiesContext.Instructors
                                   where i.Name.StartsWith(textBox1.Text)
                                   select i).ToList();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillDataSource();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Instructor selectedInstructor = listBox1.SelectedItem as Instructor;

            var lessons = from l in studiesContext.Lessons
                          where l.InstructorFk == selectedInstructor.InstructorSk
                          select new
                          {
                              Kurzus = l.CourseFkNavigation.Name,
                              Day = l.DayFkNavigation.Name,
                              Sáv = l.TimeFkNavigation.Name
                          };
            dataGridView1.DataSource = lessons.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

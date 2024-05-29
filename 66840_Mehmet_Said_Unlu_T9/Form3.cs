using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _66840_Mehmet_Said_Unlu_T9
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadClasses();
            LoadDataFromFile();
        }
        private void LoadDataFromFile()
        {
            Student.LoadFromFile("Students.txt");
        }

        private void LoadClasses()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All");

            foreach (var className in Student.StudentsDictionary.Keys)
            {
                comboBox1.Items.Add(className);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string selectedClass = comboBox1.SelectedItem.ToString();

            if (selectedClass == "All")
            {
                foreach (var studentList in Student.StudentsDictionary.Values)
                {
                    foreach (var student in studentList)
                    {
                        listBox1.Items.Add(student.StudentID);
                    }
                }
            }
            else
            {
                foreach (var student in Student.StudentsDictionary[selectedClass])
                {
                    listBox1.Items.Add(student.StudentID);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            string selectedID = listBox1.SelectedItem.ToString();

            foreach (var studentList in Student.StudentsDictionary.Values)
            {
                foreach (var student in studentList)
                {
                    if (student.StudentID == selectedID)
                    {
                        labelName.Text = student.Name;
                        labelLN.Text = student.LastName;
                        labelID.Text = student.StudentID;
                        labelClass.Text = student.StudentClass;
                        return;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }
    }

}

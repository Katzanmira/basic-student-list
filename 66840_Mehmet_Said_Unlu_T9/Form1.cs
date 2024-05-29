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
    public partial class Form1 : Form
    {
        private const string FileName = "Students.txt";

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void LoadData()
        {
            Student.LoadFromFile(FileName);
        }

        private void SaveData()
        {
            Student.SaveToFile(FileName);
        }
    }
}

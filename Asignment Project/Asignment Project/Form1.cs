using System.Diagnostics;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Asignment_Project
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {//to add the student
            string name = textBox1.Text;
            students.Add(new Student(name));
            listBox1.Items.Add(name);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //to display the selected item
            listBox2.Items.Clear();

            if (listBox1.SelectedIndex != -1)
            {
                Student selectedStudent = students[listBox1.SelectedIndex];
                foreach (var activity in selectedStudent.Activities)
                {
                    listBox2.Items.Add(activity);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //to add the activity
            string activity = textBox2.Text;
            int score = int.Parse(textBox3.Text);

            if (listBox1.SelectedIndex != -1)
            {
                Student selectedStudent = students[listBox1.SelectedIndex];
                selectedStudent.AddActivity(activity, score);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //to make the average of the seleced item
            if (listBox1.SelectedIndex != -1)
            {
                Student selectedStudent = students[listBox1.SelectedIndex];
                double averageScore = selectedStudent.AverageScore;
                MessageBox.Show($"Average Score: {averageScore}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //to reomove the selected item

            if (listBox1.SelectedIndex != -1)
            {
                students.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }
    }

    public class Student
    {
        public string Name { get; }
        public List<Activity> Activities { get; } = new List<Activity>();

        public Student(string name)
        {
            Name = name;
        }

        public void AddActivity(string name, int score)
        {
            Activities.Add(new Activity(name, score));
        }

        public double AverageScore
        {
            get
            {
                int totalScore = 0;
                foreach (var activity in Activities)
                {
                    totalScore += activity.Score;
                }
                return (double)totalScore / Activities.Count;
            }
        }
    }

    public class Activity
    {
        public string Name { get; }
        public int Score { get; }

        public Activity(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return $"{Name} - Score: {Score}";
        }
    }
}

   

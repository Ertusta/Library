using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.IO;
using Newtonsoft.Json;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //emty classes
        Book[] classList = new Book[250];
        Book[] disPlayList = new Book[250];
        Book[] disPlayList2 = new Book[250];



        string fileSource = Path.Combine(Environment.CurrentDirectory, "source.json");

        // string fileSource = @"C:\Users\ertug\OneDrive\Masaüstü\Ertusta\Abinin Yazılım Macerası\c#\project\Library\source\source.json";



        // class value
        public int BookNumber = 0;



        private void button1_Click(object sender, EventArgs e)
        {
            //constructer input
            string title = textBox1.Text;
            string writer = textBox2.Text;
            Int64 ısbn = Convert.ToInt64(textBox3.Text);
            bool Control = false;

            

            for (int i = 0; i != BookNumber; i += 1)
            {
               if( classList[i].Title==title && classList[i].Writer == writer)
                {
                    classList[i].NumberOfCopies +=1 ;
                    Control = true;
                }
            }

            //constructer
            if (Control == false)
            {
                classList[BookNumber] = new Book(title, writer, ısbn, 1, 0);
                BookNumber += 1;

               string jsondata = JsonConvert.SerializeObject(classList);
                File.WriteAllText(fileSource, jsondata);
            }


            label5.Text = "Successfull" + "(" + BookNumber + ")";


            //new class value
            

            resetList1();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void resetList1()
        {

            dataGridView1.Rows.Clear();
            int temp = 0;


            if ("" != textBox4.Text)
            {
                for (int i = 0; i != BookNumber; i += 1)
                {


                    if (classList[i].Title == textBox4.Text)
                    {

                        disPlayList[temp] = classList[i];
                        temp += 1;
                    }
                }
            }
            else if (("" != textBox5.Text))
            {
                for (int i = 0; i != BookNumber; i += 1)
                {
                    if (classList[i].Writer == textBox5.Text)
                    {
                        disPlayList[temp] = classList[i];
                        temp += 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i != BookNumber; i += 1)
                {
                    disPlayList[temp] = classList[i];
                    temp += 1;
                }
            }

            for (int i = 0; i != temp; i += 1)
            {
                dataGridView1.Rows.Add(disPlayList[i].Title, disPlayList[i].Writer, disPlayList[i].Isbn, disPlayList[i].NumberOfCopies, disPlayList[i].BorrowedBook);
            }
        }

        private void resetList2()
        {
            dataGridView2.Rows.Clear();
            int temp = 0;

            for (int i = 0; i != BookNumber; i += 1)
            {
                if (classList[i].BorrowedBook > 0)
                {
                    disPlayList2[temp] = classList[i];
                    temp += 1;

                }
            }
            for (int i = 0; i != temp; i += 1)
            {
                dataGridView2.Rows.Add(disPlayList2[i].Title, disPlayList2[i].Writer, disPlayList2[i].Isbn, disPlayList2[i].NumberOfCopies, disPlayList2[i].BorrowedBook);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetList1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetList2();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (disPlayList[e.RowIndex].NumberOfCopies != 0)
            {
                disPlayList[e.RowIndex].NumberOfCopies -= 1;
                disPlayList[e.RowIndex].BorrowedBook += 1;
            }

            resetList1();
            resetList2();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (disPlayList2[e.RowIndex].BorrowedBook != 0)
            {
                disPlayList2[e.RowIndex].NumberOfCopies += 1;
                disPlayList2[e.RowIndex].BorrowedBook -= 1;
            }
            resetList1();
            resetList2();
        }











        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
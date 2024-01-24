using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;



namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            readData();
            resetList1();
            resetList2();
            resetList3();
        }

        //emty classes
        List<Book> classList = new List<Book>();
        List<Book> disPlayList = new List<Book>();
        List<Book> disPlayList2 = new List<Book>();
        List<Book> disPlayList3 = new List<Book>();



        private void readData()
        {
            string jsonDataa = File.ReadAllText("source.json");
            classList = JsonConvert.DeserializeObject<List<Book>>(jsonDataa);

            
        }

        private void setData() 
        {
            string jsondata = JsonConvert.SerializeObject(classList);
            File.WriteAllText("source.json", jsondata);
        }
        
        


        private void button1_Click(object sender, EventArgs e)
        {

            
            
            //constructer input
            string title = textBox1.Text;
            string writer = textBox2.Text;
            Int64 isbn=1;
            bool control = false;

            label5.Text = "succecfull";

            try
            {
                isbn = Convert.ToInt64(textBox3.Text);
            }
            catch (Exception ex)
            {
                label5.Text = "Unvalid ISBN";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";


            }



            foreach (Book book in classList)
            {
               if (book.Title == title && book.Writer == writer)
                {
                    book.NumberOfCopies += 1;
                    control = true;
                    setData();
                }
            }

            //constructer
            if (control == false)
            {
                DateTime time = DateTime.Now.Date;
                classList.Add(new Book(title, writer, isbn, 1, 0, time.AddDays(15)));

                setData();
            }


           


            resetList1();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetList1();
        }

       


        private void resetList1()
        {

            dataGridView1.Rows.Clear();
            disPlayList.Clear();



            if ("" != textBox4.Text)
            {
                foreach (Book book in classList)
                {


                    if (book.Title == textBox4.Text)
                    {

                        disPlayList.Add(book);
                        

                    }
                }
            }
            else if (("" != textBox5.Text))
            {
                foreach (Book book in classList)
                {
                    if (book.Writer == textBox5.Text)
                    {
                        disPlayList.Add(book);
                    }
                }
            }
            else
            {
                foreach (Book book in classList)
                {
                    disPlayList.Add(book);
                }
            }

            



            foreach (Book book in disPlayList)
            {
                dataGridView1.Rows.Add(book.Title, book.Writer, book.Isbn, book.NumberOfCopies, book.BorrowedBook);
            }
        }

        private void resetList2()
        {
            dataGridView2.Rows.Clear();
            disPlayList2.Clear();


           foreach (Book book in classList)
            {
                if (book.BorrowedBook > 0)
                {
                    disPlayList2.Add(book);
                }
            }
            foreach (Book book in disPlayList2)
            {

                dataGridView2.Rows.Add(book.Title, book.Writer, book.Isbn, book.NumberOfCopies, book.BorrowedBook,book.ExpirationDate);
            }
        }

        private void resetList3()
        {
            dataGridView3.Rows.Clear();
            disPlayList3.Clear();
            foreach (Book book in classList)
            {
                DateTime today = DateTime.Now;
                if(book.ExpirationDate < today)
                {
                    disPlayList3.Add(book);
                }
            }

            foreach (Book book in disPlayList3)
            {
                dataGridView3.Rows.Add(book.Title, book.Writer, book.Isbn, book.NumberOfCopies, book.BorrowedBook);
            }
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (disPlayList[e.RowIndex].NumberOfCopies != 0)
            {
                disPlayList[e.RowIndex].NumberOfCopies -= 1;
                disPlayList[e.RowIndex].BorrowedBook += 1;

                setData();
            }

            resetList1();
            resetList2();
            resetList3();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (disPlayList2[e.RowIndex].BorrowedBook != 0)
            {
                disPlayList2[e.RowIndex].NumberOfCopies += 1;
                disPlayList2[e.RowIndex].BorrowedBook -= 1;
                setData();
            }
            resetList1();
            resetList2();
            resetList3();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       
    }
}
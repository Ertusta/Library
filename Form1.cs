using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;



namespace Library
{
    //başlangıç
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //veri kalıcılığı
            readData();

            //listeleri yenilemek
            resetList1();
            resetList2();
            resetList3();
        }

        //boş listeler
        List<Book> classList = new List<Book>();
        List<Book> disPlayList = new List<Book>();
        List<Book> disPlayList2 = new List<Book>();
        List<Book> disPlayList3 = new List<Book>();


        //verileri okuma
        private void readData()
        {
            string jsonDataa = File.ReadAllText("source.json");
            classList = JsonConvert.DeserializeObject<List<Book>>(jsonDataa);

            
        }

        //verileri yazma
        private void setData() 
        {
            string jsondata = JsonConvert.SerializeObject(classList);
            File.WriteAllText("source.json", jsondata);
        }
        
        

        //kitap yada koypa eklemek
        private void button1_Click(object sender, EventArgs e)
        {

            
            
            //kitap veri almak
            string title = textBox1.Text;
            string writer = textBox2.Text;
            Int64 isbn=1;//13 basamaklı olduğu için

            //hata yoksa mesaj
            label5.Text = "succecfull";

            //hata işleme
            try
            {
                //harf girilirse
                isbn = Convert.ToInt64(textBox3.Text);
            }
            catch (Exception ex)
            {
                label5.Text = "Unvalid ISBN";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }

            bool control = false;

            //kopya ekleme
            foreach (Book book in classList)
            {
               if (book.Title == title && book.Writer == writer)
                {
                    book.NumberOfCopies += 1;
                    control = true;
                    setData();
                }
            }

            //yeni kitap ekleme
            if (control == false)
            {
                
                classList.Add(new Book(title, writer, isbn, 1, 0,DateTime.Now.AddDays(1500)));

                setData();
            }
            
            resetList1();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        //spesifik kitap ararken
        private void button2_Click(object sender, EventArgs e)
        {
            resetList1();
        }

       

        //tüm kitaplar tablosunu tekrar yazmak
        private void resetList1()
        {
            //herşeyi sıfırla
            dataGridView1.Rows.Clear();
            disPlayList.Clear();


            //isimden tarama
            if ("" != textBox4.Text)
            {
                foreach (Book book in classList)
                {

                    if (book.Title == textBox4.Text)
                    {
                        disPlayList.Add(book);
                    }
                }
            }//yazardan tanıma
            else if (("" != textBox5.Text))
            {
                foreach (Book book in classList)
                {
                    if (book.Writer == textBox5.Text)
                    {
                        disPlayList.Add(book);
                    }
                }
            }//tüm kitaplar
            else
            {
                foreach (Book book in classList)
                {
                    disPlayList.Add(book);
                }
            }
            //seçilen kitapları ilk listeye ekleme           
            foreach (Book book in disPlayList)
            {
                dataGridView1.Rows.Add(book.Title, book.Writer, book.Isbn, book.NumberOfCopies, book.BorrowedBook);
            }
        }

        //ödünç verilmiş kitaplar tablosunu yazmak
        private void resetList2()
        {
            //herşeyi sıfırla
            dataGridView2.Rows.Clear();
            disPlayList2.Clear();

            //borç verilmiş kitapları listele
           foreach (Book book in classList)
            {
                if (book.BorrowedBook > 0)
                {
                    disPlayList2.Add(book);
                }
            }//listeyi tablo 2 ye aktar
            foreach (Book book in disPlayList2)
            {

                dataGridView2.Rows.Add(book.Title, book.Writer, book.Isbn, book.NumberOfCopies, book.BorrowedBook,book.ExpirationDate);
            }
        }

        //tarihi geçmiş kitaplar tablosunu yazmak
        private void resetList3()
        {
            //herşeyi sıfırla
            dataGridView3.Rows.Clear();
            disPlayList3.Clear();

            //tarihleri kıyasla
            foreach (Book book in classList)
            {
                DateTime today = DateTime.Now.Date;
                if(book.ExpirationDate < today)
                {
                    disPlayList3.Add(book);
                }
            }
            //üçüncü tabloya aktar
            foreach (Book book in disPlayList3)
            {
                dataGridView3.Rows.Add(book.Title, book.Writer, book.Isbn, book.NumberOfCopies, book.BorrowedBook);
            }
        }

        //kitapları ödünç vermek ve tarih vermek
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (disPlayList[e.RowIndex].NumberOfCopies != 0)
            {
                disPlayList[e.RowIndex].NumberOfCopies -= 1;
                disPlayList[e.RowIndex].BorrowedBook += 1;
                disPlayList[e.RowIndex].ExpirationDate = DateTime.Now.Date.AddDays(15);
                setData();
            }

            resetList1();
            resetList2();
            resetList3();
        }

        //kitapları iade almak
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (disPlayList2[e.RowIndex].BorrowedBook != 0)
            {
                disPlayList2[e.RowIndex].NumberOfCopies += 1;
                disPlayList2[e.RowIndex].BorrowedBook -= 1;
                disPlayList2[e.RowIndex].ExpirationDate=DateTime.Now.Date.AddDays(1500);
                setData();
            }
            resetList1();
            resetList2();
            resetList3();
        }









        //burdan sonrası gereksiz ama silince hata veriyor

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
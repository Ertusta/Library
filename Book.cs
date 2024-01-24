using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Book
    {
        //field
        string title;
        string writer;
        Int64 isbn;
        int numberOfCopies;
        int borrowedBook;
        DateTime expirationDate;

        //constructor
        public Book(string title, string writer , Int64 isbn, int numberOfCopies, int borrowedBook, DateTime expirationDate)
        {
            this.title = title;
            this.writer = writer;
            this.isbn = isbn;
            this.numberOfCopies = numberOfCopies;
            this.borrowedBook = borrowedBook;
            this.expirationDate = expirationDate;   
        }

        //access
        public string Title
        {
            get { return title; }
        }

        public string Writer
        {
            get { return writer; }
        }

        public Int64 Isbn
        {
            get { return isbn; }
        }

        public int NumberOfCopies
        {
             get { return numberOfCopies; }
            set { numberOfCopies = value; }
             
        }

        public int BorrowedBook
        {
            get { return borrowedBook; }
            set { borrowedBook = value; }

        }

       public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }



    }
}

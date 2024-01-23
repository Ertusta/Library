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
        Int64 ısbn;
        int numberOfCopies;
        int borrowedBook;

        //constructor
        public Book(string title, string writer, Int64 ısbn, int numberOfCopies, int borrowedBook)
        {
            this.title = title;
            this.writer = writer;
            this.ısbn = ısbn;
            this.numberOfCopies = numberOfCopies;
            this.borrowedBook = borrowedBook;
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
            get { return ısbn; }
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


    }
}

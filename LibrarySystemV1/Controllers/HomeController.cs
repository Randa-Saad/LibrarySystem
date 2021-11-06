using LibrarySystemV1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystemV1.Controllers
{
    public class HomeController : Controller
    {
        LibraryDBContext Db;
        public HomeController()
        {
            Db = new LibraryDBContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Books()
        {
           
            var bookslist = Db.Books.ToList();
            return View(bookslist);

            //second way
            //string mainConnection = ConfigurationManager.ConnectionStrings["LibraryDBContext"].ConnectionString;
            //SqlConnection sqlcon = new SqlConnection(mainConnection);
            //string sqlquery = "select * from [dbo].[Books]";
            //SqlCommand sqlCom = new SqlCommand(sqlquery, sqlcon);
            //sqlcon.Open();
            //SqlDataAdapter adaptr = new SqlDataAdapter(sqlCom);
            //DataSet ds = new DataSet();
            //adaptr.Fill(ds);
            //List<Book> bookslist = new List<Book>();

            //foreach(DataRow DR in ds.Tables[0].Rows)
            //{
            //    bookslist.Add(new Book
            //        {
            //        BookId=Convert.ToInt32(DR["BookId"]),
            //        BookName = Convert.ToString(DR["BookName"]),
            //        NoOfCopies = Convert.ToInt32(DR["NoOfCopies"]),
            //        NoOfExistingCopies = Convert.ToInt32(DR["NoOfExistingCopies"])

            //        });
            //}
            //sqlcon.Close();
            //return View(bookslist);
        }

        public ActionResult Borrowers()
        {

            var borrowerslist = Db.Borrowers.ToList();
            return View(borrowerslist);

            //second way
            //string mainConnection = ConfigurationManager.ConnectionStrings["LibraryDBContext"].ConnectionString;
            //SqlConnection sqlcon = new SqlConnection(mainConnection);
            //string sqlquery = "select * from [dbo].[Borrowers]";
            //SqlCommand sqlCom = new SqlCommand(sqlquery, sqlcon);
            //sqlcon.Open();
            //SqlDataAdapter adaptr = new SqlDataAdapter(sqlCom);
            //DataSet ds = new DataSet();
            //adaptr.Fill(ds);
            //List<Borrower> borrowerslist = new List<Borrower>();

            //foreach (DataRow DR in ds.Tables[0].Rows)
            //{
            //    borrowerslist.Add(new Borrower
            //    {
            //        BorrowerId = Convert.ToInt32(DR["BorrowerId"]),
            //        BorrowerName = Convert.ToString(DR["BorrowerName"])

            //    });
            //}
            //sqlcon.Close();
            //return View(borrowerslist);

        }

     


    }
}
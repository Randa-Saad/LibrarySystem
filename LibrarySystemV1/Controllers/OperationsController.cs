using LibrarySystemV1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystemV1.Controllers
{
    public class OperationsController : Controller
    {
        LibraryDBContext Db;
        public OperationsController()
        {
            Db = new LibraryDBContext();
        }
        // GET: Operations
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult RevertPage()
        {
            //go to revert Form
            return View();
        }
        public ActionResult BorrowPage()
        {
            //go to Borrow Form
            return View();
        }
        public ActionResult CheckBorrow(int? BookId,string BorrowerName)
        {
            var checkedBook = Db.Books.Find(BookId);
            if (checkedBook != null)
            {
                if (checkedBook.NoOfExistingCopies != 0 )
                {
                    var decreaseCopies = (checkedBook.NoOfExistingCopies) - 1;
                    checkedBook.NoOfExistingCopies = decreaseCopies;
                    string mainConnection = ConfigurationManager.ConnectionStrings["LibraryDBContext"].ConnectionString;
                    SqlConnection connect = new SqlConnection(mainConnection);
                   
                    string query3 = "Insert Into Borrowers (BorrowerName,BookId) Values(@BorrowerName,@BookId)";
                    SqlCommand command = new SqlCommand(query3, connect); 
                    command.CommandText = query3;
                    command.Parameters.AddWithValue("BorrowerName", BorrowerName);
                    command.Parameters.AddWithValue("@BookId", BookId);
                    connect.Open();
                    command.ExecuteNonQuery();
                    connect.Close();
                    Db.SaveChanges();

                   
                    return View();
                }
                else
                {

                    return RedirectToAction("BorrowerError");
                }
            }
            return RedirectToAction("WrongData");
          
            
           
        }
        public ActionResult CheckRevert(int? BookId,string BookName)
        {
            var checkedBook = Db.Books.Find(BookId);
            
            if (checkedBook != null)
            {
                if (checkedBook.BookName.ToLower()==BookName.ToLower() && checkedBook.BookId == BookId)
               {
                   if (checkedBook.NoOfExistingCopies < checkedBook.NoOfCopies)
                   {
                    var IncreaseCopies = (checkedBook.NoOfExistingCopies) + 1;
                    checkedBook.NoOfExistingCopies = IncreaseCopies;
                    Db.SaveChanges();
                    return View();
                   }
                  else
                   {
                    return RedirectToAction("RevertError");
                   }
               }
              else
              {
                return RedirectToAction("WrongData");
               }
            }
            return RedirectToAction("WrongData");
           
        }

        public ActionResult BorrowerError()
        {
            return View();
        }

        public ActionResult RevertError()
        {
            return View();
        }
        public ActionResult WrongData()
        {
            return View();
        }
    }
}
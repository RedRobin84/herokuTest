using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankOfSimba.Models;

namespace BankOfSimba.Controllers
{
    public class HomeController : Controller
    {
        private static List<BankAccount> bankAccountList = new List<BankAccount>
        {
            new BankAccount("Dacan The King", 5000, "monkey"),
            new BankAccount("Duncan", 2000, "lizard"),
            new BankAccount("Ulrich", 10000, "bird"),
            new BankAccount("Elizabeth", 200, "bacteria")
        };


        public IActionResult Index()
        {
            return View();
        }
        [Route("Show")]
        public IActionResult Show()
        {
            var bankAccount = new BankAccount("Simba", 2000, "lion");
            return View(bankAccount);
        }
        [Route("ShowAll")]
        public IActionResult ShowAll()
        {
            return View(bankAccountList);
        }
        [Route("RaiseFunds")]
        public IActionResult RaiseFunds(int index)
        {
            bankAccountList[index].Balance += 
               bankAccountList[index].IsKing() == "No" ? 10 : 100;
            return View("ShowAll", bankAccountList);
        }
        [Route("CreateAccount")]
        public IActionResult CreateAccount(string name, int balance, string animaltype)
        {
            bankAccountList.Add(new BankAccount(name, balance, animaltype));
            return View("ShowAll", bankAccountList);
        }
    }
}
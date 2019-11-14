using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfSimba.Models
{
    public class BankAccount
    {
        private double balance;
        private string animalType;

        public string Name { get; set; }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public string AnimalType
        {
            get { return animalType; }
            set { animalType = value; }
        }

        public BankAccount(string name, double balance, string animalType)
        {
            this.Name = name;
            this.Balance = balance;
            this.AnimalType = animalType;
        }
        public string IsKing()
        {
            return this.Name.IndexOf("King") != -1 ? "Yes" : "No";
        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Models
{
    public class Fox
    {
        private string name;
        private string food;
        private string drink;
        private List<string> listOfTricks;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Food
        {
            get { return food; }
            set { food = value; }
        }
        public string Drink
        {
            get { return drink; }
            set { drink = value; }
        }
        public List<string> ListOfTricks
        {
            get { return listOfTricks; }
            set { listOfTricks = value; }
        }

        public Fox (string name = "defaultname")
        {
            this.Name = name;
            this.ListOfTricks = new List<string>();
            this.Food = "defaultfood";
            this.Drink = "defaultdrink";
        }

        public Fox(string name, List<string> listOfTricks, string food = "defaultfood", string drink = "defaultdrink")
        {
            this.Name = name;
            this.ListOfTricks = listOfTricks == null ? new List<string>() : ListOfTricks;
            this.Food = food;
            this.Drink = drink;
        }

        public bool HasTrick(string trick)
        {
            return ListOfTricks.Contains(trick);
        }

    }
}

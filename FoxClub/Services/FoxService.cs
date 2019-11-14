using FoxClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Services
{
    public class FoxService
    {
        private List<Fox> listOfFoxes;
        private List<string> listOfFoods;
        private List<string> listOfDrinks;
        private List<string> listOfTricks;

        public List<Fox> ListOfFoxes
        {
            get { return listOfFoxes; }
            set { listOfFoxes = value; }
        }

        public List<string> ListOfFoods { get => listOfFoods; set => listOfFoods = value; }
        public List<string> ListOfDrinks { get => listOfDrinks; set => listOfDrinks = value; }
        public List<string> ListOfTricks { get => listOfTricks; set => listOfTricks = value; }

        public FoxService()
        {
            ListOfFoxes = new List<Fox>();
            ListOfFoods = new List<string> { "bread", "cheese", "apple", "meat"};
            ListOfDrinks = new List<string> { "cola", "tea", "rum", "water", "juice" };
            ListOfTricks = new List<string> { "dance", "salto", "sing", "go through the walls", "play the piano" };
        }

        public void CreateIfNotExist(string name)
        {
            if (!listOfFoxes.Exists(f => f.Name == name))
            {
                listOfFoxes.Add(new Fox(name));
            }
        }
        public Fox FindFoxByName(string name)
        {
            return ListOfFoxes[ListOfFoxes.FindIndex(f => f.Name == name)];
        }
        public bool IsFoxValid(string name)
        {
            return ListOfFoxes.Exists(f => f.Name == name);
        }
        public bool IsLogged(string name)
        {
            return (name != null && IsFoxValid(name));
        }

    }
}

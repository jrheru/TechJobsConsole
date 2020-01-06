using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant
{

    public class Menu
    {
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<MenuItem> Items { get; set; }

        public Menu(string name, DateTime update, List<MenuItem> items)
        {
            Name = name;
            if (items == null)
            {
                this.Items = new List<MenuItem>();
            }
            else
            {
                this.Items = items;
            }
            LastUpdate = update;



        }
        // AddMenuItem is a method to Menu gives functionality to add new items to the menu
        public void AddMenuItem(MenuItem item)
        {
            DateTime now = DateTime.Now;
            if (item == null)
            {
                return;
            }
            Items.Add(item);
            LastUpdate = now;
            item.DateAdded = now;
        }

        //This method is to remove an item from the menu
        public void RemoveMenuItem(MenuItem item)
        {
            int index;

            if (item == null)
            {
                return;
            }

            Items.Remove(item);
            LastUpdate = DateTime.Now;
        }

        public override string ToString()
        {
            string str = "";

            str += Name + "Menu\n" +
                String.Join("\n---\n", Items);// "\n = new line
            return str;
        }

        public override bool Equals(object obj)
        {
            Menu menuObj;

            if (obj == null || (obj.GetType() != this.GetType()))
            {
                return false;
            }

            menuObj = obj as Menu;

            return menuObj.Name == this.Name &&
                menuObj.Items.SequenceEqual(this.Items);//checking if incoming name matches my name and menu item names matches my items
        }

        ////This 
        //public bool IsNew(DateTime fromWhen)
        //{

        //}






        // Class
        public class MenuItem
        {
            //properties
            public double Price { get; set; }
            public string Description { get; set; }
            public List<string> Categories { get; set; }
            public string Name { get; set; }
            public DateTime DateAdded { get; set; }

            //constuctor
            public MenuItem(string name, string description, double price, List<string> categories, DateTime added)
            {
                Name = name;
                Description = description;
                Price = price;
                Categories = categories;
                DateAdded = added;
            }


            //This method tells if the menu item is new
            public bool IsNew(DateTime fromWhen)
            {
               
                if (DateTime.Compare(fromWhen, DateAdded) < 0)
                {
                    return true;
                }else
                {
                    return false;
                }

            }

            //ToString is the string format that is returned when you call the properties of a class
            public override string ToString()
            {
                string str = "";

                str += Name + "-" + Description +
                    "\n$" + Price +
                    "\n" + String.Join(",", Categories);

                return str;
            }

            //This method is to tell if two items on the menu is equal by name
            public override bool Equals(object obj)
            {
                MenuItem itemObj;

                if (obj == null || (obj.GetType() != this.GetType()))
                {
                    return false;
                }

                itemObj = obj as MenuItem;
                return itemObj.Name == this.Name;
            }
        }















        // Main class
        class MainClass
        {
            public static void Main(string[] args)
            {
                MenuItem burger = new MenuItem("Burger", "100% pure beef", 8.99, new List<string>() { "entry", "lunch" }, new DateTime());
                MenuItem peachcobbler = new MenuItem("Mama's peachcobbler", "best in the world", 4.99, new List<string>() { "dessert"}, new DateTime());

                Menu resMenu = new Menu("The Shack", new DateTime(), new List<MenuItem>() { burger, peachcobbler });

                Console.WriteLine("Restaurant name: " + resMenu.Name);

                Console.WriteLine(peachcobbler.Name + " " + peachcobbler.Price);

                resMenu.Items[1].Price = 8.99;

                Console.WriteLine(peachcobbler.Name + " " + peachcobbler.Price);
                Console.WriteLine(resMenu.Items[1].Name + " " + resMenu.Items[1].Price);
                Console.WriteLine(peachcobbler);//This is to test and run the ToString method
                Console.WriteLine(peachcobbler.Equals(burger));// This is to test and run the Equals method

                Console.WriteLine(resMenu);// This is to test the ToString method in the Menu class
                
            }
        }
    }
}

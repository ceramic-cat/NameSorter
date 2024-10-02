using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace NameSorter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> menuOptions = new Dictionary<string, string>()
            {
                {"A", "Create new empty current list and add new name." },
                {"B", "Make a list with preselected names" },
                {"C", "Add name to list" },
                {"D", "Remove name from list"},
                {"E", "Search name in list" },
                {"F", "Display list" },
                {"G", "Sort list: Alphabetical order" },
                {"H", "Sort list: Reverse alphabetical order" },
                {"X", "Exit program" }
            };


            bool keepRunning = true;
            string userInput = "start";

            List<string> standardNames = new List<string>()
            {
                "Celeste",
                "Tengil",
                "Aron",
                "Liqorice"
            };

            NameList userNameList = new NameList();

            bool nameListExists = false;

            {

                // Helper method that prints out the contents of the menu.
                PrintMenu();

                // VerifyMenuInput returns a bool. True while it matches something in the menu.
                // GetUserInput gets a readline from the user.
                if (VerifyMenuInput(GetUserInput()))
                {
                    // do things with the NameList-class.
                    switch (userInput)
                    {
                        // Empty list, add new name
                        case "A":
                            userNameList.Clear();
                            Console.WriteLine("Please enter a name: ");
                            userNameList.Add(GetName());

                            break;


                        // List with standard names
                        case "B":
                            userNameList = new NameList(standardNames);
                            Console.WriteLine("The standard names have replaced any previous list.");
                            break;


                            // Add name
                        case "C":
                            if (userNameList.Count <= 0)
                            {
                                PrintWarning();
                                break;
                            }
                            Console.WriteLine("Please enter a name: ");
                            userNameList.Add(GetName());
                            break;

                        // Remove name
                        case "D":
                            if (userNameList.Count <= 0)
                            {
                                PrintWarning();
                                break;
                            }
                            else
                            {
                                userNameList.Remove(GetName());
                            }
                            break;
                            // Search for name
                        case "E":
                            if (userNameList.Count <= 0)
                            {
                                PrintWarning();
                                break;
                            }
                            Console.WriteLine("E");
                            //Console.WriteLine("\nEnter name to search:");
                            //string searchName = Console.ReadLine();

                            //if (names.Contains(searchName))
                            //{
                            //    Console.WriteLine($"{searchName} is in the list.");
                            //}
                            //else
                            //{
                            //    Console.WriteLine($"{searchName} is not in the list.");
                            //}


                            break;
                            // Display list
                        case "F":
                            if (userNameList.Count <= 0)
                            {
                                PrintWarning();
                                break;
                            }
                            Console.WriteLine("Your NameList: ");
                            userNameList.PrintList();
                            break;
                            // Sort list in alpha order
                        case "G":
                            if (userNameList.Count <= 0)
                            {
                                PrintWarning();
                                break;
                            }

                            userNameList.Sort();
                            Console.WriteLine("Your sorted list: ");
                            userNameList.PrintList();
                            break;
                            // Sort list in reverse alpha order
                        case "H":
                            if (userNameList.Count <= 0)
                            {
                                PrintWarning();
                                break;
                            }
                            userNameList.Sort();
                            userNameList.Reverse();
                            userNameList.PrintList();
                            break;
                            // Exit program
                        case "X":
                            keepRunning = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();



            }

            void PrintWarning()
            {
                Console.WriteLine("Invalid Option, you need to create a NameList first.");
            }

            bool VerifyMenuInput(string input)
            {
                input = input.ToUpper();
                if (input != null)
                {
                    if (menuOptions.Keys.Contains(input))
                    {
                        userInput = input;
                        return true;
                    }
                }
                return false;
            }

            string GetUserInput()
            {
                Console.WriteLine("Please enter an option:");
                return Console.ReadLine();
            }

            string GetName()
            {
                Console.WriteLine("Please enter a name: ");
                return Console.ReadLine();
            }

            void PrintMenu()
            {
                Console.WriteLine("Welcome to NameSorter!");
                Console.WriteLine("What would you like to do?");

                foreach (var option in menuOptions)
                {
                    {
                        // Always print A, B and X options. The rest only prints if there is a list instantiated. 
                        // NOT (ABX) gets printed 2times. fix!
                        if (option.Key.Equals("A") || (option.Key.Equals("B")) || (option.Key.Equals("X")))
                        {
                            Console.WriteLine($"[{option.Key}]\t {option.Value}");
                        }
                        else
                        {
                            if (userNameList.Count > 0)
                            {
                                Console.WriteLine($"[{option.Key}]\t {option.Value}");
                            }
                        }
                    }
                }
            }


            //List<string> names = new List<string> { "Anna", "John", "Alice", "Beatrice" };
            //Console.WriteLine("Original list:");
            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}

            //names.Sort(); // Sort the names alphabetically
            //Console.WriteLine("\nSorted list:");
            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}

            //Console.WriteLine("\nEnter name to search:");
            //string searchName = Console.ReadLine();

            //if (names.Contains(searchName))
            //{
            //    Console.WriteLine($"{searchName} is in the list.");
            //}
            //else
            //{
            //    Console.WriteLine($"{searchName} is not in the list.");
            //}
            //Console.ReadKey();
        }
    }
}


class NameList : List<string>
{
    //private static bool _isThereList;
    public List<string> Names { get; private set; }
    //public static bool IsThereList { get; private set; } = false;


    // Constructor with list.
    public NameList(List<string> nameList)
    {
        Names = nameList;
        //IsThereList = true;

    }
    // Constructor with name.
    public NameList()
    {
        Names = new List<string>();
        //IsThereList = true;

    }
    public void PrintList()
    {
         
        foreach (var name in this.Names)
        {
            Console.WriteLine(name);
        }
    }



}



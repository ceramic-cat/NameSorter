using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
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

            // Names for a list input
            List<string> standardNames = new List<string>()
            {
                "Celeste",
                "Tengil",
                "Aron",
                "Liqorice"
            };

            // userNameList is the NameList for this program.
            NameList userNameList = new NameList();

            while (keepRunning)
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
                            //Console.WriteLine("Please enter a name: ");
                            userNameList.Add(GetName());

                            break;


                        // List with standard names
                        case "B":
                            userNameList.Clear();
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
                                string nameToRemove = GetName();
                                if (userNameList.Contains(nameToRemove))
                                {
                                    userNameList.Remove(GetName());
                                    Console.WriteLine($"{nameToRemove} has been removed from the list.");
                                }
                                else Console.WriteLine($"{nameToRemove} is not included in the list.");
                            }
                            break;
                        // Search for name
                        case "E":
                            if (userNameList.Count <= 0)
                            {
                                PrintWarning();
                                break;
                            }
                            Console.WriteLine("Enter a name for searching: ");
                            string searchName = Console.ReadLine();
                            if (userNameList.Contains(searchName))
                                Console.WriteLine($"{searchName} is in the list.");
                            else Console.WriteLine($"{searchName} is not in the list.");
                            break;
                        // Display list
                        case "F":
                            if (userNameList.Count <= 0)
                            {
                                PrintWarning();
                                break;
                            }
                            Console.WriteLine("Your NameList: ");
                            userNameList.PrintList(userNameList);
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
                            userNameList.PrintList(userNameList);
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
                            Console.WriteLine("Your sorted list: ");
                            userNameList.PrintList(userNameList);
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
            // method for printing common warning
            void PrintWarning()
            {
                Console.WriteLine("Invalid Option, you need to create a NameList first.");
            }

            // method for checking that the input is valid for the menu options. Allows for lower case.
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
                        // Always print A, B and X options. The rest only prints if there's a NameList that has at least 1 value in it.
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
        }
    }
}

// NameList is based on the List class, so a lot of methods we get for free (such as .Add()).
class NameList : List<string>
{
    public List<string> Names { get; private set; }


    // Constructor with list.
    public NameList(List<string> nameList) : base(nameList)
    {
        Names = nameList;

    }
    // Constructor with name.
    public NameList() : base()
    {
        Names = new List<string>();

    }
    public void PrintList(NameList names)
    {

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}



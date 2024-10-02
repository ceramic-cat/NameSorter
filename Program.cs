using System.Collections.Generic;
using System.Xml.Linq;

namespace NameSorter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> menuOptions = new Dictionary<string, string>()
            {
                {"A", "Make an empty list of names" },
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


            while (keepRunning)
            {

                // Helper method that prints out the contents of the menu.
                PrintMenu();

                // VerifyMenuInput returns a bool. True while it matches something in the menu.
                // GetUserInput gets a readline from the user.
                while (VerifyMenuInput(GetUserInput()))
                {
                    // do things with the NameList-class.




                }




            }

            bool VerifyMenuInput(string input)
            {
                if (input != null)
                {
                    if (menuOptions.Keys.Contains(input))
                    {
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

            void PrintMenu()
            {
                Console.WriteLine("Welcome to NameSorter!");
                Console.WriteLine("What would you like to do?");

                foreach (var option in menuOptions)
                {
                    {
                        // Always print A, B and X options. The rest only prints if there is a list instantiated. 
                        if (!option.Key.Equals("A") && !option.Key.Equals("B") && !option.Key.Equals("X"))
                            if (NameList.IsThereList)
                            {
                                Console.WriteLine($"[{option.Key}]\t {option.Value}");

                            }
                            else
                            {
                                continue;
                            }
                        Console.WriteLine($"[{option.Key}]\t {option.Value}");



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
    private static bool _isThereList;
    public List<string> Names { get; private set; }
    public static bool IsThereList { get; private set; } = false;


    // Constructor with list.
    public NameList(List<string> nameList)
    {
        Names = nameList;
        _isThereList = true;

    }
    // Constructor without list, creates new list.
    public NameList()
    {
        Names = new List<string>();
        _isThereList = true;

    }
    public void PrintList(NameList friend)
    {
        foreach (var name in friend.Names)
        {
            Console.WriteLine(name);
        }
    }



}



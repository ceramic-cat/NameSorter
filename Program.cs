using System.Xml.Linq;

namespace NameSorter
{
    internal class Program
    {
        static void Main(string[] args)
        {

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


            void PrintMenu()
                { }



            bool VerifyMenuInput(string input)
            {

            }

            string GetUserInput()
            {

            }




            List<string> names = new List<string> { "Anna", "John", "Alice", "Beatrice" };
            Console.WriteLine("Original list:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            names.Sort(); // Sort the names alphabetically
            Console.WriteLine("\nSorted list:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nEnter name to search:");
            string searchName = Console.ReadLine();

            if (names.Contains(searchName))
            {
                Console.WriteLine($"{searchName} is in the list.");
            }
            else
            {
                Console.WriteLine($"{searchName} is not in the list.");
            }
            Console.ReadKey();
        }
    }


    class NameList
    {
        public List<string> Names { get; private set; }
        // Constructor with list.
        public NameList(List<string> nameList)
        {
            Names = nameList;
        }
        // Constructor without list, creates new list.
        public NameList()
        {
            Names = new List<string>();
        }

        public void AddName(string name)
        {
            Names.Add(name);
        }

        public void RemoveName(string name)
        {
            Names.Remove(name);
        }

        public void SortNameList()
        { Names.Sort(); }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
   internal class Menu
    {
        string[] _menuOptions;

        public Menu(string[] menuOptions)
        {
            _menuOptions = menuOptions;
        }
        public int GetMenuChoice()
        {
            int menuChoice = 0;
            Console.WriteLine(_menuOptions[0]);
            do
            {
                for (int i = 1; i < _menuOptions.Length; i++)
                    Console.WriteLine($"{i} . {_menuOptions[i]}");

                Console.WriteLine("Enter Choice:");
                while (!int.TryParse(Console.ReadLine(), out menuChoice))
                {
                    Console.WriteLine($"Please enter a number between 1 and {_menuOptions.Length}:");
                }

                if ((menuChoice > _menuOptions.Length) || (menuChoice < 1))
                {
                    Console.WriteLine($"Please enter a number between 1 and {_menuOptions.Length}:");
                }

            }
            while ((menuChoice > _menuOptions.Length) || (menuChoice < 1));
            return menuChoice;
        }
    }
}

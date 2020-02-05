using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace SimpleScanning
{
    class Program
    {
        static void Main(string[] args)
        {
            EditConsole();
            OnLoad();
            ShowMenu();
            MainMenu();
        }

        public static void EditConsole()
        {
            Console.SetWindowSize(150, 45);
            Console.Title = "SIMPLE SCANNING! press <ctrl+c> to exit at any time";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public static void OnLoad()
        {
            string welcome1 = "Welcome to Simple Scanning!\r\n";
            string welcome2 = "Press any key to continue...\r\n";
            CenterText(welcome1);
            CenterText(welcome2);
            Console.CursorVisible = false;
        }

        public static void MainMenu()
        {
            bool programRun = true;
            ConsoleKey choice;
            LinkedList<string> taskItems =
                new LinkedList<string>();
            int currentSelection = 0;
            int Page = 1;
            do
            {
                Console.Clear();
                OnLoad();
                ShowMenu();
                int n = taskItems.Count;
                PntFst(taskItems);
                
                choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.A: // Add
                        CenterText("Enter new task: ");
                        var input = Console.ReadLine();
                        taskItems.AddLast(input);
                        continue;
                    case ConsoleKey.R: // Reenter
                        taskItems.AddLast(selected);
                        continue;
                    case ConsoleKey.DownArrow:
                        if (currentSelection >= 0 || currentSelection < 20)
                        {
                            currentSelection++;
                        }
                        if (currentSelection == 20)
                        {
                            Page++;
                            currentSelection++;
                        }
                        if (currentSelection )
                        {

                        }
                        continue;
                    default:
                        break;
                }
                
            } while (programRun);
        }

        public static void ShowMenu()
        {

            var text1 = "============================================================";
            var text2 = "DownArrow = Next : " +
                        "S = Skip : " +
                        "A = Add : " +
                        "R = Renter : ";
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 5;
            CenterText(text1);
            CenterText(text2);
            // Restore previous position
            Console.SetCursorPosition(x, y);
        }

        public static string CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," 
            + ((Console.WindowWidth / 2) 
            + (text.Length / 2)) + "}", text));
            return text;
        }

        public static void PntFst(LinkedList<string> first)
        {
            foreach (string s in first)
            {
                CenterText(s);
            }
            CenterText(" ");
        }

        // Move Cursor
        //Index -> color
        //    select = 0
       //     down key if 0 then add 1, if 20, change page 1 to page 2, move to 21, repeat, if end move to 0


           
        // Count += 1;
        // Count %= list.Count;


    }
}

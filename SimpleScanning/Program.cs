using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
            EditColor();
            Console.Clear();
        }

        public static void EditColor() // For Terminal Default
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void OnLoad()
        {
            string welcome1 = "Welcome to Simple Scanning!\r\n";
            string welcome2 = "Press any key to continue...\r\n";
            CenterText(welcome1);
            CenterText(welcome2);
            Console.CursorVisible = false;
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

        public static void MainMenu() // Currently Working On
        {
            bool programRun = true;
            ConsoleKey choice;
            ArrayList taskItems =
                new ArrayList();
            int selected = 0;
            int Page = 1;
            var (text, size) = ObjStr(taskItems, selected);

            do
            {
                Console.Clear();
                OnLoad();
                ShowMenu();
                int n = taskItems.Count;
                PntFst(taskItems, selected);
                (text, size) = ObjStr(taskItems, selected);

                choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.A: // Add
                        CenterText("Enter new task: ");
                        Console.CursorVisible = true;
                        var input = Console.ReadLine();
                        taskItems.Add(input);
                        continue;
                    case ConsoleKey.S: // Skip
                        // chagne color to red
                        SelectColor(text, size, 2);
                        continue;
                    case ConsoleKey.R: // Reenter
                        taskItems.Add(taskItems[selected]);
                        continue;
                    case ConsoleKey.DownArrow:
                        if (selected >= 0 && selected <= taskItems.Count || 
                            selected < 20 && selected <= taskItems.Count)
                        {
                            selected++;
                        }
                        if (selected == 20)
                        {
                            Page++;
                            
                            selected++;
                        }
                        if (selected == taskItems.Count)
                        {
                            
                        }
                        continue;
                    default:
                        break;
                }
                
            } while (programRun);
        }


        public static string CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," 
            + ((Console.WindowWidth / 2) 
            + (text.Length / 2)) + "}", text));
            return text;
        }

        public static void PntFst(ArrayList taskItems, int selected)
        {
            if (taskItems.Count == 0)
            {
                CenterText("No Tasks");
            }
            else
            {
                var (text, size) = ObjStr(taskItems, selected);

                if (selected == 0)
                {
                    SelectColor(text, size, 1);
                    if (taskItems.Count > 1)
                    {
                        for (int i = selected + 1; i < taskItems.Count; i++)
                        {
                            CenterText(taskItems[i].ToString());
                        }
                    }
                
                }
                else if(selected > 0)
                {
                    
                    for (int i = 0; i < selected; i++)
                    {
                        CenterText(taskItems[i].ToString());
                    }
                    SelectColor(text, size, 1);
                    for (int i = selected + 1; i < taskItems.Count; i++)
                    {
                        CenterText(taskItems[i].ToString());
                    }

                }
                CenterText(" ");
            }
        }

        public static (string, int) ObjStr(ArrayList taskItems, int selected)
        {
            string text = taskItems[selected].ToString();
            int size = text.Length + 4;
            return (text, size);
        }
        public static void SelectColor(string text, int size, int ID) // For Selected Text
        {
            // Sets variables, saves cursor location
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            text += " ";
            CenterText(text);
            CleanUp(size);
            Console.SetCursorPosition(x, y + 1);
            EditColor();
        }

        public static void CleanUp(int size)
        {
            int y = Console.CursorTop;
            Console.SetCursorPosition(0, y);
            string spaces = "  ";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(String.Format("{0,"
                + (((Console.WindowWidth - size) / 2)
                + (spaces.Length / 3)) + "}", spaces));
        }

        //public static void Selected(ArrayList taskList, int selected)
        //{
        //    string text = taskList[selected].ToString();
       //     int length = text.Length + 4;
       //     Console.CursorVisible = true;
       // }


       // public static int HighlightLength(LinkedList<string> taskList)
       // {

        //    var temp = taskList.ElementAt(n);
       // }
        // Move Cursor
        //Index -> color
        //    select = 0
       //     down key if 0 then add 1, if 20, change page 1 to page 2, move to 21, repeat, if end move to 0


           
        // Count += 1;
        // Count %= list.Count;

        //for (int i = firstOfPage(currentPage);
        //  (i C Is.Count)&&(i<FirstOfPage(currentPage + 1));
        //  ++i
    }
}

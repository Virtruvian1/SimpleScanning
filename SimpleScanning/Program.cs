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
        // ID 001
        static void Main(string[] args) 
        {
            DefaultConsole(); 
            OnLoad();
            ShowMenu();
            DisplayList();
        }

        public static void OnLoad() // Menu On Load 
        // ID 002
        {
            string welcome1 = "Welcome to Simple Scanning!\r\n";
            string welcome2 = "Press any key to continue...\r\n";
            CenterText(welcome1);
            CenterText(welcome2);
            Console.CursorVisible = false;
            Console.Read();
            Console.Clear(); // Clears text after keyboard press
        }

        public static void DisplayList() 
        // ID 003
        {
            // establish variables
            bool programRun = true;
            bool turnPage = false;
            int pageNum = 1;
            int selectedIndex = 0;
            ArrayList taskItems = new ArrayList();

            do 
        // ID 003.001
            {
                Console.Clear(); // Clear Console on loop
                ShowMenu(); // Bottom display of avalible key pressess
                Console.SetCursorPosition(0, 4);
                PrintList(taskItems, selectedIndex, pageNum); // Prints current list
                ConsoleKey keyPress = Console.ReadKey(true).Key;

                switch (keyPress) 
        // ID 003.001.001
                {

                    case ConsoleKey.A: // Add 
        // ID 003.001.001.001
                        KeyEvent(taskItems, 1, selectedIndex, pageNum);
                        continue;

                    case ConsoleKey.F: // Finish 
        // ID 003.001.001.002
                        KeyEvent(taskItems, 2, selectedIndex, pageNum);
                        continue;

                    case ConsoleKey.R: // Reenter
        // ID 003.001.001.003
                        KeyEvent(taskItems, 3, selectedIndex, pageNum);
                        continue;

                    case ConsoleKey.S: // Skip 
        // ID 003.001.001.004
                        KeyEvent(taskItems, 4, selectedIndex, pageNum);
                        continue;

                    case ConsoleKey.DownArrow: 
        // ID 003.001.001.005
                        turnPage = KeyEvent(taskItems, 5, selectedIndex, pageNum);
                        if (turnPage)
                        {
                            pageNum++;
                        }
                        continue;

                    default: 
        // ID 003.001.001.006
                        break;
                }
            } while (programRun);
        }

        public static void PrintList(ArrayList taskItems, int selectedIndex, int pageNum) 
        // ID 004
        {
            int maxNum = pageNum * 20 - 1;

            if (taskItems.Count == 0) // If list is empty 
        // ID 004.001
            {
                CenterText("-- No Tasks --");
            }

            else if (pageNum == 1) 
        // ID 004.002
            {
                var (indexOutput, indexLength) = ObjectToString(taskItems, selectedIndex);

                if (selectedIndex == 0) // If selectedIndex is [0] 
        // ID 004.002.001
                {
                    SelectProcess(indexOutput, indexLength); // Chagnes color of selectedIndex

                    if (taskItems.Count > 1) // Prints all list items regularly after [i]
        // ID 004.002.001.001
                    {

                        for (int i = selectedIndex; i <= maxNum; i++) 
        // ID 004.002.001.001.001
                        {
                            var (internalOutput, _) = ObjectToString(taskItems, selectedIndex);
                            CenterText(internalOutput);
                        }
                    }
                }

                else if(selectedIndex > 0) // If selectedIndex [i] > 0 
        // ID 004.002.002
                {

                    for (int i = 0; i < selectedIndex + 1; i++) // Prints all list items regularly before [i]
        // ID 004.002.002.001
                    {
                        CenterText(taskItems[i].ToString());
                    }
                    SelectProcess(indexOutput, indexLength);  // Chagnes color of selectedIndex

                    for (int i = selectedIndex + 1; i <= 20; i++) // Prints all list items regularly after [i] 
        // ID 004.002.002.002
                    {
                        CenterText(taskItems[i].ToString());
                    }
                }

                else 
        // ID 004.002.003
                {
                    CenterText(" ");
                }
            }

            else // Handles Page Flip 
        // ID 004.003
            {
                var (indexOutput, indexLength) = ObjectToString(taskItems, selectedIndex);

                for (int i = 0; i < selectedIndex; i++) // Prints all list items regularly before [i]
        // ID 004.003.001
                {
                    CenterText(taskItems[i].ToString());
                }
                SelectProcess(indexOutput, indexLength);  // Chagnes color of selectedIndex

                for (int i = selectedIndex + 1; i < taskItems.Count; i++) // Prints all list items regularly after [i]
        // ID 004.003.002
                {
                    CenterText(taskItems[i].ToString());
                }
            }
        }

        public static bool KeyEvent(ArrayList taskItems, int ID, int selectedIndex, int pageNum) 
        // ID 005
        {
            bool turnPage = false;
            int pageCondition = selectedIndex % 20;
            int maxNum = pageNum * 20 - 1;
            int i = maxNum - 20;

            if (ID == 1) // Add
        // ID 005.001
            {
                CenterText("Enter new task: ");
                Console.CursorVisible = true;
                var input = Console.ReadLine();
                taskItems.Add(input);
            }

            else if (ID == 2) // Finish
        // ID 005.002
            {

            }

            else if (ID == 3) // ReEnter
        // ID 005.003
            {
                taskItems.Add(taskItems[selectedIndex]);
            }

            else if (ID == 4) // Skip
        // ID 005.004
            {
                //SelectColor(text, size, 2);
            }

            else if (ID == 5) // Down Arrow
        // ID 005.005
            {
                
                if (selectedIndex >= 0 || selectedIndex <= 19)
        // ID 005.005.001
                {
                    selectedIndex++;
                }

                else if (pageCondition == 0) // If pageNum %20, print new page
        // ID 005.005.002
                {
                    selectedIndex++;
                    turnPage = true;
                    return turnPage;
                }
                return turnPage;
            }
            return turnPage;
        }

        public static void DefaultConsole() // Changes Console Default 
        // ID 006
        {
            Console.SetWindowSize(150, 45);
            Console.Title = "SIMPLE SCANNING! press <ctrl+c> to exit at any time";
            EditColor(1);
            Console.Clear();
        }

        public static void EditColor(int ID) // For Color Changes 
        // ID 007
        {

            if (ID == 1) // Default Color
        // ID 007.001
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            else if (ID == 2) // Selected Color
        // ID 007.002
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }

            else // Cleans Up Selected Color; pass indexLength as ID
        // ID 007.003
            {
                int y = Console.CursorTop;
                Console.SetCursorPosition(0, y);
                string spaces = "  ";
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine(String.Format("{0," + (((Console.WindowWidth - ID) / 2) + (spaces.Length / 3)) + "}", spaces));
            }
        }

        public static void SelectProcess(string indexOutput, int indexLength) 
        // ID 008
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            EditColor(2);
            CenterText(indexOutput += " ");
            EditColor(indexLength);
            Console.SetCursorPosition(x, y + 1);
            EditColor(1);
        }

        public static void ShowMenu() // Always show keyboard shortcuts at bottom
        // ID 009
        {

            var text1 = "============================================================";
            var text2 = "DownArrow = Next : " +
                        "S = Skip : " +
                        "A = Add : " +
                        "R = Renter : " +
                        "F = Finsih ";
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 5;
            CenterText(text1);
            CenterText(text2);
            // Restore previous position
            Console.SetCursorPosition(x, y);
        }

        public static string CenterText(string text) // Console.WriteLine(Center) 
        // ID 010
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
            return text;
        }

        public static (string, int) ObjectToString(ArrayList taskItems, int desiredIndex) 
        // ID 011
        {
            string indexOutput = taskItems[desiredIndex].ToString();
            int indexLength = indexOutput.Length + 4;
            return (indexOutput, indexLength);
        }

        //--------------------------------------------------------------------------------------------------------
        //                                       Version 1 Snippets Removed
        //--------------------------------------------------------------------------------------------------------

        //public static void SelectColor(string text, int size, int ID) // For Selected Text
        //{

        //}


        //--------------------------------------------------------------------------------------------------------
        //                                   UnNeeded
        //--------------------------------------------------------------------------------------------------------

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

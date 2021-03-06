﻿using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Version 1.1
namespace SimpleScanning
{
    class Program
    {
        // ID 001
        static void Main(string[] args) 
        {
            DefaultConsole(); //-> 006
            OnLoad(); //-> 002
            ShowMenu(); //-> 009
            DisplayList(); //-> 003
        }

        public static void OnLoad() // Menu On Load 
        // ID 002
        {
            string welcome1 = "Welcome to Simple Scanning!\r\n";
            string welcome2 = "Press any key to continue...\r\n";
            CenterText(welcome1); //-> 010
            CenterText(welcome2); //-> 010
            Console.CursorVisible = false;
            Console.ReadKey();
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
                ShowMenu(); //-> 009
                Console.SetCursorPosition(0, 2);
                PrintList(taskItems, selectedIndex, pageNum); //-> 004
                ConsoleKey keyPress = Console.ReadKey(true).Key;

                switch (keyPress) 
                // ID 003.001.001
                {

                    case ConsoleKey.A: // Add 
                    // ID 003.001.001.001
                        KeyEvent(taskItems, 1, selectedIndex, pageNum); //-> 005.001
                        continue;

                    case ConsoleKey.F: // Finish 
                    // ID 003.001.001.002
                        KeyEvent(taskItems, 2, selectedIndex, pageNum); //-> 005.002
                        continue;

                    case ConsoleKey.R: // Reenter
                    // ID 003.001.001.003
                        KeyEvent(taskItems, 3, selectedIndex, pageNum); //-> 005.003
                        continue;

                    case ConsoleKey.S: // Skip 
                    // ID 003.001.001.004
                        KeyEvent(taskItems, 4, selectedIndex, pageNum); //-> 005.004
                        continue;

                    case ConsoleKey.DownArrow: 
                    // ID 003.001.001.005
                        (turnPage, _) = KeyEvent(taskItems, 5, selectedIndex, pageNum); //-> 005.005
                        (_, selectedIndex) = KeyEvent(taskItems, 5, selectedIndex, pageNum); //-> 005.005
                        selectedIndex++;
                        // ID 003.001.001.005.001
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
                CenterText("-- No Tasks --"); //-> 010
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

                        for (int i = selectedIndex; i < taskItems.Count; i++) 
                        // ID 004.002.001.001.001
                        {
                            var (internalOutput, _) = ObjectToString(taskItems, i); //-> 011
                            CenterText(internalOutput); //-> 010
                        }
                    }
                }

                else if(selectedIndex > 0) // If selectedIndex [i] > 0 
                // ID 004.002.002
                {

                    for (int i = 0; i < selectedIndex + 1; i++) // Prints all list items regularly before [i]
                    // ID 004.002.002.001
                    {
                        var (internalOutput, _) = ObjectToString(taskItems, i); //-> 011
                        CenterText(internalOutput); //-> 010
                    }
                    SelectProcess(indexOutput, indexLength);  //-> 008

                    for (int i = selectedIndex + 1; i <= 20; i++) // Prints all list items regularly after [i] 
                    // ID 004.002.002.002
                    {
                        var (internalOutput, _) = ObjectToString(taskItems, i); //-> 011
                        CenterText(internalOutput); //-> 010
                    }
                }

                else 
                // ID 004.002.003
                {
                    CenterText(" "); //-> 010
                }
            }

            else // Handles Page Flip 
            // ID 004.003
            {
                var (indexOutput, indexLength) = ObjectToString(taskItems, selectedIndex); //-> 011
                for (int i = 0; i < selectedIndex; i++) // Prints all list items regularly before [i]
                // ID 004.003.001
                {
                    var (internalOutput, _) = ObjectToString(taskItems, i); //-> 011
                    CenterText(internalOutput); //-> 010
                }
                SelectProcess(indexOutput, indexLength);  //-> 008

                for (int i = selectedIndex + 1; i < taskItems.Count; i++) // Prints all list items regularly after [i]
                // ID 004.003.002
                {
                    var (internalOutput, _) = ObjectToString(taskItems, i); //-> 011
                    CenterText(internalOutput); //-> 010
                }
            }
        }

        public static (bool, int) KeyEvent(ArrayList taskItems, int ID, int selectedIndex, int pageNum) 
        // ID 005
        {
            bool turnPage = false;
            int pageCondition = selectedIndex % 20;
            int maxNum = pageNum * 20 - 1;
            // int i = maxNum - 20;

            if (ID == 1) // Add
            // ID 005.001
            {
                Console.WriteLine("Enter new task: ");
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
                    return (turnPage, selectedIndex++);
                }

                else if (pageCondition == 0) // If pageNum %20, print new page
                // ID 005.005.002
                {
                    turnPage = true;
                    return (turnPage, selectedIndex++);
                }
                return (turnPage, selectedIndex++);
            }
            return (turnPage, selectedIndex++);
        }

        public static void DefaultConsole() // Changes Console Default 
        // ID 006
        {
            Console.SetWindowSize(150, 45);
            Console.Title = "SIMPLE SCANNING! press <ctrl+c> to exit at any time";
            EditColor(1); // -> 007
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

            else // Pass indexLength to avoid top statements and enter here
            // ID 007.003
            {
                int y = Console.CursorTop;
                string spaces = "  ";
                Console.WriteLine(String.Format("{0," + (((Console.WindowWidth - ID) / 2) + (spaces.Length / 3)) + "}", spaces));
                Console.SetCursorPosition(0, y);
                EditColor(1); //-> 007.001
            }
        }

        public static void SelectProcess(string indexOutput, int indexLength) 
        // ID 008
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            EditColor(2); //-> 007.003
            CenterText(indexOutput + " "); //-> 010
            EditColor(indexLength); //-> 007
            EditColor(1); //-> 007
            Console.SetCursorPosition(x, y + 1);
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
            CenterText(text1); //-> 010
            CenterText(text2); //-> 010
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
            int indexLength = indexOutput.Length;
            return (indexOutput, indexLength);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        //                                                                Version 1.1 Bug List
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        //  Bug 001 : Id 002 : On Run (System.Collections.ArrayList & System.ArgumentOutOfRangeException) Line 319, 129, 51, 20
        //      Resolved : Id 002 : Changed Console.Read() to Console.ReadKey(), which fixed ID 005.001
        //  Bug 002 : ID 008 : Highlight colors entire line
        //      Unresolved 
        //  Bug 003 : ID 005.001 : When called the second time, writes the task then multiplies it and prints it until System.ArgumentOutOfRangeException
        //      Resolved : // ID 004.002.001.001.001 : Fixed the looping max from 19 to taskItems.Count limiting the loop to the size of the list
        //
        //
        //

        //--------------------------------------------------------------------------------------------------------
        //                                       Version 1 Snippets Removed
        //--------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------
        //                                   UnNeeded
        //--------------------------------------------------------------------------------------------------------

        // public static void Selected(ArrayList taskList, int selected)
        // {
        //    string text = taskList[selected].ToString();
        //    int length = text.Length + 4;
        //    Console.CursorVisible = true;
        // }


        // public static int HighlightLength(LinkedList<string> taskList)
        // {

        // var temp = taskList.ElementAt(n);
        // }
        // Move Cursor
        // Index -> color
        // select = 0
        // down key if 0 then add 1, if 20, change page 1 to page 2, move to 21, repeat, if end move to 0



        // Count += 1;
        // Count %= list.Count;

        // for (int i = firstOfPage(currentPage);
        // (i C Is.Count)&&(i<FirstOfPage(currentPage + 1));
        // ++i
    }
}

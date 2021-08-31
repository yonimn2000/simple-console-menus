﻿using System;
using System.Collections.Generic;

namespace YonatanMankovich.SimpleConsoleMenus
{
    public abstract class ConsoleMenu
    {
        public string Title { get; set; }
        public int SelectedIndex { get; set; }
        internal IList<string> menuItems;

        public ConsoleMenu(string title)
        {
            Title = title;
            menuItems = new List<string>();
            SelectedIndex = 0;
        }

        public void Show()
        {
            Console.CursorVisible = false;
            int linesToSkipFromTop = Console.CursorTop;

            if (!string.IsNullOrWhiteSpace(Title))
                Console.WriteLine(Title);
            else
                linesToSkipFromTop--;

            do // Loop until user confirms selection.
            {
                // Draw the menu on the same line every time (skip title line).
                Console.CursorTop = linesToSkipFromTop + 1;
                Console.CursorLeft = 0;
                for (int i = 0; i < menuItems.Count; i++)
                {
                    string text = "  " + menuItems[i];
                    if (SelectedIndex == i)
                        WriteInNegativeColor(text);
                    else
                        Console.WriteLine(text);
                }
            } while (!WasEnterPressed());
            Console.CursorVisible = true;
        }

        private bool WasEnterPressed()
        {
            bool correctKey;

            do // Loop until Up, Down, or Enter keys are pressed.
            {
                correctKey = true;
                Console.CursorLeft = 0;
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Enter: return true;
                    case ConsoleKey.DownArrow:
                        if (SelectedIndex < menuItems.Count - 1)
                            SelectedIndex++;
                        else
                            SelectedIndex = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectedIndex > 0)
                            SelectedIndex--;
                        else
                            SelectedIndex = menuItems.Count - 1;
                        break;
                    default: correctKey = false; break;
                }
            } while (!correctKey);
            return false;
        }

        public void WriteInNegativeColor(string text)
        {
            ConsoleColor tempColor = Console.BackgroundColor;
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = tempColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public string GetSelectedItemName() => menuItems[SelectedIndex].ToString();
    }
}
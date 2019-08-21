using System;
using System.Collections.Generic;

namespace YonatanMankovich.SimpleConsoleMenus
{
    public abstract class ConsoleMenu
    {
        public string Title { get; set; }
        public int SelectedIndex { get; set; }
        internal IList<string> menuItems;
        internal int linesToSkipFromTop = -1;

        public ConsoleMenu(string title)
        {
            Title = title;
            menuItems = new List<string>();
            SelectedIndex = 0;
        }

        public void Show()
        {
            if (linesToSkipFromTop < 0)
                linesToSkipFromTop = Console.CursorTop;
            if (!string.IsNullOrWhiteSpace(Title))
                Console.WriteLine(Title);
            else
                linesToSkipFromTop--;
            // Loop until user selection confirmation.
            do
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
        }

        private bool WasEnterPressed()
        {
            bool correctKey;
            // Loop until Up, Down, or Enter keys are pressed.
            do
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
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectedIndex > 0)
                            SelectedIndex--;
                        break;
                    default: correctKey = false; break;
                }
            } while (!correctKey);
            return false;
        }

        public int ShowAndGetSelectedIndex()
        {
            Show();
            return SelectedIndex;
        }

        public string ShowAndGetSelectedItemName()
        {
            Show();
            return GetSelectedItemName();
        }

        public void WriteInNegativeColor(string text)
        {
            ConsoleColor tempColor = Console.BackgroundColor;
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = tempColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public string GetSelectedItemName()
        {
            return menuItems[SelectedIndex].ToString();
        }
    }
}
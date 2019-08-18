using System.Collections.Generic;

namespace YonatanMankovich.SimpleConsoleMenus
{
    public class SimpleConsoleMenu : ConsoleMenu
    {
        public SimpleConsoleMenu(string title) : base(title)
        {
            Title = title;
            menuItems = new List<string>();
            SelectedIndex = 0;
        }

        public void AddOption(string optionName)
        {
            menuItems.Add(optionName);
        }

        public void RemoveOption(string optionName)
        {
            menuItems.Remove(optionName);
        }

        public void RemoveOptionAt(int index)
        {
            menuItems.RemoveAt(index);
        }

        public void ClearOptions()
        {
            menuItems.Clear();
        }
    }
}
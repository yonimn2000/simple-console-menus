using System.Collections.Generic;

namespace YonatanMankovich.SimpleConsoleMenus
{
    public class SimpleConsoleMenu : ConsoleMenu
    {
        public SimpleConsoleMenu(string title) : base(title) { }

        public SimpleConsoleMenu(string title, params string[] options) : base(title)
        {
            AddOptionsRange(options);
        }

        public SimpleConsoleMenu(string title, IEnumerable<string> options) : base(title)
        {
            AddOptionsRange(options);
        }

        public SimpleConsoleMenu() : this(null) { }

        public void AddOption(string optionName)
        {
            menuItems.Add(optionName);
        }

        public void AddOptionsRange(IEnumerable<string> options)
        {
            foreach (string option in options)
                AddOption(option);
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
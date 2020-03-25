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

        public void AddOption(string optionText)
        {
            menuItems.Add(optionText);
        }

        public void AddOptionsRange(IEnumerable<string> optionTexts)
        {
            foreach (string optionText in optionTexts)
                AddOption(optionText);
        }

        public void RemoveOption(string optionText)
        {
            menuItems.Remove(optionText);
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
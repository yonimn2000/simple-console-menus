
namespace YonatanMankovich.SimpleConsoleMenus
{
    public class SimpleConsoleMenu : ConsoleMenu
    {
        public SimpleConsoleMenu(string title) : base(title) { }

        public SimpleConsoleMenu() : this(null) { }

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
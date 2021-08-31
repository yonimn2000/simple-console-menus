using System;
using System.Collections.Generic;

namespace YonatanMankovich.SimpleConsoleMenus
{
    public class SimpleActionConsoleMenu : ConsoleMenu
    {
        private readonly IList<Action> actions;
        public SimpleActionConsoleMenu(string title) : base(title)
        {
            actions = new List<Action>();
        }

        public SimpleActionConsoleMenu() : this(null) { }

        public void AddOption(string optionText, Action action)
        {
            menuItems.Add(optionText);
            actions.Add(action);
        }

        public void RemoveOption(string optionText)
        {
            RemoveOptionAt(menuItems.IndexOf(optionText));
        }

        public void RemoveOptionAt(int index)
        {
            menuItems.RemoveAt(index);
            actions.RemoveAt(index);
        }

        public void ClearOptions()
        {
            menuItems.Clear();
            actions.Clear();
        }

        public void DoAction()
        {
            actions[SelectedIndex]();
        }

        public void ShowAndDoAction()
        {
            Show();
            DoAction();
        }

        public void ShowHideAndDoAction()
        {
            Show();
            Hide();
            DoAction();
        }
    }
}
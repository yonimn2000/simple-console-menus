using System;
using System.Collections.Generic;

namespace YonatanMankovich.SimpleConsoleMenu
{
    public class SimpleActionConsoleMenu : ConsoleMenu
    {
        private readonly IList<Action> actions;
        public SimpleActionConsoleMenu(string title) : base(title)
        {
            actions = new List<Action>();
        }

        public void AddOption(string optionName, Action action)
        {
            menuItems.Add(optionName);
            actions.Add(action);
        }

        public void RemoveOption(string optionName)
        {
            RemoveOptionAt(menuItems.IndexOf(optionName));
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
    }
}
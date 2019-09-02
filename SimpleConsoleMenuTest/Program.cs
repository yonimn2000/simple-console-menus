using System;
using System.Collections.Generic;

namespace YonatanMankovich.SimpleConsoleMenus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSimpleConsoleMenu1();
            TestSimpleConsoleMenu2();
            TestSimpleConsoleMenu3();
            TestSimpleConsoleMenuNoTitle();
            TestSimpleActionConsoleMenu();
            Console.ReadLine();
        }

        private static void TestSimpleConsoleMenu1()
        {
            SimpleConsoleMenu menu = new SimpleConsoleMenu("Choose an option:");
            menu.AddOption("Option 1");
            menu.AddOption("Option 2");
            menu.AddOption("Option 3");
            menu.Show();
            Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
        }

        private static void TestSimpleConsoleMenu2()
        {
            SimpleConsoleMenu menu = new SimpleConsoleMenu("Choose an option:", "Option 1", "Option 2", "Option 3");
            menu.Show();
            Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
        }

        private static void TestSimpleConsoleMenu3()
        {
            IEnumerable<string> options = new List<string>() { "Option 1", "Option 2", "Option 3" };
            SimpleConsoleMenu menu = new SimpleConsoleMenu("Choose an option:", options);
            menu.Show();
            Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
        }

        private static void TestSimpleActionConsoleMenu()
        {
            SimpleActionConsoleMenu menu = new SimpleActionConsoleMenu("Choose an option with an action:");
            menu.AddOption("Write 'Hello!'", () => Console.WriteLine("Hello!"));
            menu.AddOption("Show another menu", TestSimpleConsoleMenu1);
            menu.AddOption("Exit", () => Environment.Exit(0));
            menu.ShowAndDoAction();
        }

        private static void TestSimpleConsoleMenuNoTitle()
        {
            SimpleConsoleMenu menu = new SimpleConsoleMenu();
            menu.AddOption("Option 1");
            menu.AddOption("Option 2");
            menu.AddOption("Option 3");
            menu.Show();
            Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
        }
    }
}
using System;

namespace YonatanMankovich.SimpleConsoleMenus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSimpleConsoleMenu();
            TestSimpleActionConsoleMenu();
            Console.ReadLine();
        }

        private static void TestSimpleConsoleMenu()
        {
            SimpleConsoleMenu menu = new SimpleConsoleMenus("Choose an option:");
            menu.AddOption("Option 1");
            menu.AddOption("Option 2");
            menu.AddOption("Option 3");
            menu.Show();
            Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
        }

        private static void TestSimpleActionConsoleMenu()
        {
            SimpleActionConsoleMenu menu = new SimpleActionConsoleMenu("Choose an option with an action:");
            menu.AddOption("Write 'Hello!'", () => Console.WriteLine("Hello!"));
            menu.AddOption("Show another menu", TestSimpleConsoleMenu);
            menu.AddOption("Exit", () => Environment.Exit(0));
            menu.ShowAndDoAction();
        }
    }
}
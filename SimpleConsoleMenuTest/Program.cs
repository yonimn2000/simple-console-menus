using YonatanMankovich.SimpleConsoleMenus;

TestSimpleConsoleMenu1();
TestSimpleConsoleMenuHide();
TestSimpleConsoleMenu3();
TestSimpleConsoleMenuNoTitle();
TestSimpleActionConsoleMenu();
TestSimpleActionConsoleMenuHide();

Console.WriteLine("Press ENTER to exit . . .");
Console.ReadLine();

static void TestSimpleConsoleMenu1()
{
    SimpleConsoleMenu menu = new SimpleConsoleMenu("Choose an option:");
    menu.AddOption("Option 1").AddOption("Option 2").AddOption("Option 3").Show();
    Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
}

static void TestSimpleConsoleMenuHide()
{
    SimpleConsoleMenu menu = new SimpleConsoleMenu("Choose an option:", "Option 1", "Option 2", "Option 3");
    menu.Show();
    Thread.Sleep(1000); // Sleep to show change.
    menu.Hide();
    Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
}

static void TestSimpleConsoleMenu3()
{
    IEnumerable<string> options = new List<string>() { "Option 1", "Option 2", "Option 3" };
    SimpleConsoleMenu menu = new SimpleConsoleMenu("Choose an option:", options);
    menu.Show();
    Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
}

static void TestSimpleActionConsoleMenu()
{
    SimpleActionConsoleMenu menu = new SimpleActionConsoleMenu("Choose an option with an action:");
    menu.AddOption("Write 'Hello!'", () => Console.WriteLine("Hello!"))
        .AddOption("Show another menu", TestSimpleConsoleMenu1)
        .AddOption("Exit", () => Environment.Exit(0))
        .ShowAndDoAction();
}

static void TestSimpleActionConsoleMenuHide()
{
    SimpleActionConsoleMenu menu = new SimpleActionConsoleMenu("Choose an option with an action:");
    menu.AddOption("Write 'Hello!'", () => Console.WriteLine("Hello!"))
        .AddOption("Show another menu", TestSimpleConsoleMenu1)
        .AddOption("Exit", () => Environment.Exit(0))
        .ShowHideAndDoAction();
}

static void TestSimpleConsoleMenuNoTitle()
{
    SimpleConsoleMenu menu = new SimpleConsoleMenu();
    menu.AddOption("Option 1").AddOption("Option 2").AddOption("Option 3").Show();
    Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
}
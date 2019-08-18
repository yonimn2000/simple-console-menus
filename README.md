# Simple Console Menu

Use up and down arrow keys to navigate and ENTER key to select.

## Simple Console Menu Example

```cs
SimpleConsoleMenu menu = new SimpleConsoleMenu("Choose an option:");
menu.AddOption("Option 1");
menu.AddOption("Option 2");
menu.AddOption("Option 3");
menu.Show();
Console.WriteLine($"You selected index {menu.SelectedIndex} which is '{menu.GetSelectedItemName()}'");
```

![](media/SimpleExampleScreenshot.png)

---
## Simple *Action* Console Menu Example

```cs
SimpleActionConsoleMenu menu = new SimpleActionConsoleMenu("Choose an option with an action:");
menu.AddOption("Write 'Hello!'", () => Console.WriteLine("Hello!"));
menu.AddOption("Show another menu", TestSimpleConsoleMenu);
menu.AddOption("Exit", () => Environment.Exit(0));
menu.ShowAndDoAction();
```

![](media/ActionExampleScreenshot.png)
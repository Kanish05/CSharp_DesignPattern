using System;

// ----- Abstract Product Interfaces -----
public interface IButton
{
    void Render();
}

public interface ITextBox
{
    void Render();
}

// ----- Concrete Products: Light Theme -----
public class LightThemeButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Light Theme Button");
    }
}

public class LightThemeTextBox : ITextBox
{
    public void Render()
    {
        Console.WriteLine("Rendering Light Theme TextBox");
    }
}

// ----- Concrete Products: Dark Theme -----
public class DarkThemeButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Dark Theme Button");
    }
}

public class DarkThemeTextBox : ITextBox
{
    public void Render()
    {
        Console.WriteLine("Rendering Dark Theme TextBox");
    }
}

// ----- Abstract Factory -----
public interface IUIFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}

// ----- Concrete Factories -----
public class LightThemeFactory : IUIFactory
{
    public IButton CreateButton() => new LightThemeButton();
    public ITextBox CreateTextBox() => new LightThemeTextBox();
}

public class DarkThemeFactory : IUIFactory
{
    public IButton CreateButton() => new DarkThemeButton();
    public ITextBox CreateTextBox() => new DarkThemeTextBox();
}

// ----- Client -----
public class Application
{
    private readonly IButton _button;
    private readonly ITextBox _textBox;

    public Application(IUIFactory factory)
    {
        _button = factory.CreateButton();
        _textBox = factory.CreateTextBox();
    }

    public void RenderUI()
    {
        _button.Render();
        _textBox.Render();
    }
}

// ----- Usage -----
public class Program
{
    public static void Main()
    {
        // Switch here for different look-and-feel
        IUIFactory factory = new LightThemeFactory();
        Application app = new Application(factory);
        app.RenderUI();

        Console.WriteLine();

        factory = new DarkThemeFactory();
        app = new Application(factory);
        app.RenderUI();
    }
}

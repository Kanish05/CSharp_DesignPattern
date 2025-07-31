// Abstract Factory Pattern - Explained Step by Step

using System;

// ===== STEP 1: THE PROBLEM =====
// Imagine you're building a program that needs to create UI components
// But these components should look different on Windows vs Mac
// You don't want to write "if Windows do this, if Mac do that" everywhere

// ===== STEP 2: DEFINE WHAT EACH COMPONENT CAN DO =====
// This is like a contract - every button must be able to show itself
public interface IButton
{
    void Show();
}

// Every checkbox must be able to show itself
public interface ICheckbox
{
    void Show();
}

// ===== STEP 3: CREATE WINDOWS VERSION OF COMPONENTS =====
public class WindowsButton : IButton
{
    public void Show()
    {
        Console.WriteLine("Showing a WINDOWS button (blue, rectangular)");
    }
}

public class WindowsCheckbox : ICheckbox
{
    public void Show()
    {
        Console.WriteLine("Showing a WINDOWS checkbox (square shaped)");
    }
}

// ===== STEP 4: CREATE MAC VERSION OF COMPONENTS =====
public class MacButton : IButton
{
    public void Show()
    {
        Console.WriteLine("Showing a MAC button (gray, rounded corners)");
    }
}

public class MacCheckbox : ICheckbox
{
    public void Show()
    {
        Console.WriteLine("Showing a MAC checkbox (circular shaped)");
    }
}

// ===== STEP 5: CREATE A FACTORY CONTRACT =====
// This says: "Any factory must be able to make buttons and checkboxes"
public interface IUIFactory
{
    IButton MakeButton();
    ICheckbox MakeCheckbox();
}

// ===== STEP 6: CREATE WINDOWS FACTORY =====
// This factory knows how to make ONLY Windows components
public class WindowsFactory : IUIFactory
{
    public IButton MakeButton()
    {
        Console.WriteLine("Windows Factory: Creating a Windows button...");
        return new WindowsButton();
    }

    public ICheckbox MakeCheckbox()
    {
        Console.WriteLine("Windows Factory: Creating a Windows checkbox...");
        return new WindowsCheckbox();
    }
}

// ===== STEP 7: CREATE MAC FACTORY =====
// This factory knows how to make ONLY Mac components
public class MacFactory : IUIFactory
{
    public IButton MakeButton()
    {
        Console.WriteLine("Mac Factory: Creating a Mac button...");
        return new MacButton();
    }

    public ICheckbox MakeCheckbox()
    {
        Console.WriteLine("Mac Factory: Creating a Mac checkbox...");
        return new MacCheckbox();
    }
}

// ===== STEP 8: CREATE THE MAIN PROGRAM =====
// This program doesn't know if it's using Windows or Mac components
// It just asks the factory "make me a button" and "make me a checkbox"
public class MyProgram
{
    private IUIFactory factory;
    private IButton myButton;
    private ICheckbox myCheckbox;

    // Constructor: Give me any factory, I don't care which one
    public MyProgram(IUIFactory factory)
    {
        this.factory = factory;
        Console.WriteLine("Program created with a factory");
    }

    // Create the UI components using whatever factory I have
    public void BuildUI()
    {
        Console.WriteLine("\n--- Building UI Components ---");
        myButton = factory.MakeButton();      // Factory decides: Windows or Mac button?
        myCheckbox = factory.MakeCheckbox();  // Factory decides: Windows or Mac checkbox?
    }

    // Display the components
    public void ShowUI()
    {
        Console.WriteLine("\n--- Displaying UI Components ---");
        myButton.Show();
        myCheckbox.Show();
    }
}

// ===== STEP 9: RUN THE PROGRAM =====
class Program
{
    static void Main()
    {
        Console.WriteLine("ABSTRACT FACTORY PATTERN DEMO");
        Console.WriteLine("=====================================");

        // Scenario 1: User is on Windows
        Console.WriteLine("\n🖥️  SCENARIO 1: User is on Windows");
        Console.WriteLine("Creating Windows factory...");
        IUIFactory windowsFactory = new WindowsFactory();
        
        Console.WriteLine("Creating program with Windows factory...");
        MyProgram windowsProgram = new MyProgram(windowsFactory);
        windowsProgram.BuildUI();
        windowsProgram.ShowUI();

        // Scenario 2: User is on Mac
        Console.WriteLine("\n\n🍎 SCENARIO 2: User is on Mac");
        Console.WriteLine("Creating Mac factory...");
        IUIFactory macFactory = new MacFactory();
        
        Console.WriteLine("Creating program with Mac factory...");
        MyProgram macProgram = new MyProgram(macFactory);
        macProgram.BuildUI();
        macProgram.ShowUI();

        // The KEY POINT: Same program code, different results!
        Console.WriteLine("\n\n✨ THE MAGIC:");
        Console.WriteLine("- Same MyProgram class was used both times");
        Console.WriteLine("- But we got different UI components");
        Console.WriteLine("- Just by changing which factory we passed in!");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
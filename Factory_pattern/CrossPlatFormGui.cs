using System;
// Imagine this scenario: You're building a cross-platform application that needs to create different
//  types of UI buttons for Windows, Mac, and Linux

// Abstract Creator
public abstract class Dialog 
{
    // This is the "template method" - it defines the algorithm
    public void RenderWindow() 
    {
        IButton button = CreateButton(); // 👈 This is the factory method call
        button.Render();
    }
    
    // This is the "factory method" - subclasses will implement this
    public abstract IButton CreateButton();
}

/* Let's break this down:
 Dialog is abstract: You can't create a Dialog object directly
 RenderWindow(): This is the main method that does the work. It's the same for all dialogs
 CreateButton(): This is the factory method. It's abstract because each subclass will create a different type of button
 The magic: RenderWindow() calls CreateButton(), but doesn't know what type of button it will get! */
 
 // Concrete Creator 1
public class WindowsDialog : Dialog 
{
    public override IButton CreateButton() 
    {
        return new WindowsButton(); //  Creates Windows-specific button
    }
}

// Concrete Creator 2  
public class MacDialog : Dialog 
{
    public override IButton CreateButton() 
    {
        return new MacButton(); //  Creates Mac-specific button
    }
}
// What's happening here:
// WindowsDialog extends Dialog: It inherits the RenderWindow() method
// It implements CreateButton(): This is where it decides to create a WindowsButton
// MacDialog does the same: But creates a MacButton instead
// Both inherit RenderWindow(): Same process, different buttons!


// Product interface - defines what all buttons can do
public interface IButton 
{
    void Render();
}

// Concrete Product 1
public class WindowsButton : IButton 
{
    public void Render() 
    { 
        Console.WriteLine("Rendering Windows button with flat design"); 
    }
    

}

// Concrete Product 2
public class MacButton : IButton 
{
    public void Render() 
    { 
        Console.WriteLine("Rendering Mac button with rounded corners"); 
    }
    

}
// The Product hierarchy:
// IButton interface: Defines what all buttons must be able to do
// WindowsButton & MacButton: Implement the interface differently
// Same interface, different behavior: Both can Render() and OnClick(), but they do it differently
// Dialog doesn't care: The Dialog class can work with any IButton implementation

// Usage example
public class Application 
{
    public static void Main(string[] args) 
    {
        // Create different types of dialogs
        Dialog windowsDialog = new WindowsDialog();
        Dialog macDialog = new MacDialog();
        
        // Same method call, different results!
        Console.WriteLine("=== Windows Dialog ===");
        windowsDialog.RenderWindow(); // Creates WindowsButton
        
        Console.WriteLine("\n=== Mac Dialog ===");
        macDialog.RenderWindow(); // Creates MacButton
    }
}

// The execution flow:
// windowsDialog.RenderWindow() is called
// Inside RenderWindow(), CreateButton() is called
// Since it's a WindowsDialog, CreateButton() returns a WindowsButton
// The WindowsButton's OnClick() and Render() methods are called
// Same process for MacDialog, but it creates a MacButton instead!

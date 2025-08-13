/*
IPrototype → Interface that declares the Clone() method.

Employee → Implements the clone logic using MemberwiseClone() (built-in shallow copy method in C#).

Cloning → Instead of creating a new Employee and setting all properties again, we just copy an existing one and modify what’s needed.
*/
using System;

public interface IPrototype
{
    IPrototype Clone();
}

public class Employee : IPrototype
{
    public string Name { get; set; }
    public string Department { get; set; }

    public Employee(string name, string department)
    {
        Name = name;
        Department = department;
    }

    // Clone method to create a shallow copy
    public IPrototype Clone()
    {
        return (IPrototype)this.MemberwiseClone();
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Name: {Name}, Department: {Department}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Original object
        Employee emp1 = new Employee("Alice", "IT");
        emp1.ShowDetails();

        // Clone of the original object
        Employee emp2 = (Employee)emp1.Clone();
        emp2.Name = "Bob"; // Change only the name
        emp2.ShowDetails();

        // Original remains unchanged
        emp1.ShowDetails();
    }
}

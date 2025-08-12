/*
The Composite pattern is a structural design pattern used when you have a tree-like structure of objects, where individual objects (leaves) and groups of objects (composites) should be treated the same way.

Think of:

Leaf nodes → individual items (cannot contain others)

Composite nodes → collections of leaves or other composites

Main idea: Client code doesn’t care whether it’s dealing with a single object or a group — they all follow the same interface.

Example Scenario
Let’s build a Company Organization Chart:

Employee (interface) → defines operations

Developer & Designer (Leaf nodes)

Manager (Composite node) → can have employees (both leaves and composites)

IEmployee (Component)

Common interface so that both Developer, Designer, and Manager can be treated the same.

Developer & Designer (Leaf)

Implement the interface but cannot contain other employees.

Manager (Composite)

Stores a list of IEmployee objects (can be both leaves and other composites).

Calls ShowDetails() on each subordinate recursively.

Client Code

Treats single objects (Developer, Designer) and composite objects (Manager) the same.

Why Use It?
Uniformity: Treat individual and group objects uniformly.

Scalability: Add new employee types without changing existing code.

Tree Structures: Perfect for hierarchical data (file systems, menus, org charts).
*/
using System;
using System.Collections.Generic;

// 1. Component Interface
public interface IEmployee
{
    void ShowDetails();
}

// 2. Leaf - Developer
public class Developer : IEmployee
{
    private string _name;
    private string _position;

    public Developer(string name, string position)
    {
        _name = name;
        _position = position;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Developer: {_name}, Position: {_position}");
    }
}

// 3. Leaf - Designer
public class Designer : IEmployee
{
    private string _name;
    private string _position;

    public Designer(string name, string position)
    {
        _name = name;
        _position = position;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Designer: {_name}, Position: {_position}");
    }
}

// 4. Composite - Manager
public class Manager : IEmployee
{
    private string _name;
    private string _position;
    private List<IEmployee> _subordinates = new List<IEmployee>();

    public Manager(string name, string position)
    {
        _name = name;
        _position = position;
    }

    public void AddEmployee(IEmployee employee)
    {
        _subordinates.Add(employee);
    }

    public void RemoveEmployee(IEmployee employee)
    {
        _subordinates.Remove(employee);
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Manager: {_name}, Position: {_position}");
        foreach (var emp in _subordinates)
        {
            emp.ShowDetails(); // Recursive call
        }
    }
}

// 5. Client Code
class Program
{
    static void Main()
    {
        // Leaf objects
        IEmployee dev1 = new Developer("Alice", "Backend Developer");
        IEmployee dev2 = new Developer("Bob", "Frontend Developer");
        IEmployee designer1 = new Designer("Charlie", "UI/UX Designer");

        // Composite object (Manager)
        Manager manager1 = new Manager("David", "Project Manager");
        manager1.AddEmployee(dev1);
        manager1.AddEmployee(designer1);

        // Another composite (Manager) with nested structure
        Manager generalManager = new Manager("Eve", "General Manager");
        generalManager.AddEmployee(manager1); // Manager under manager
        generalManager.AddEmployee(dev2);     // Direct report

        // Display structure
        generalManager.ShowDetails();
    }
}

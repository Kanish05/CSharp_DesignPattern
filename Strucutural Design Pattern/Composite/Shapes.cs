/*
Graphic — common interface for all shapes and drawings.

Circle & Rectangle — leaf nodes, can’t contain anything else.

Drawing — composite node, holds multiple IGraphic objects (which can be leaves or composites).

Client — just calls Draw() on any IGraphic, not caring if it’s a single shape or a group.

This is the classic use case in graphics editors — group and ungroup objects while keeping operations uniform.
The composite pattern makes Draw() calls recursive so you don’t need to manually iterate over shapes.
*/

using System;
using System.Collections.Generic;

// Component
public interface IGraphic
{
    void Draw();
}

// Leaf - Circle
public class Circle : IGraphic
{
    private string Color;
    public Circle(string color)
    {
        Color = color;
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing a {Color} Circle");
    }
}

// Leaf - Rectangle
public class Rectangle : IGraphic
{
    private string Color;
    public Rectangle(string color)
    {
        Color = color;
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing a {Color} Rectangle");
    }
}

// Composite
public class Drawing : IGraphic
{
    private List<IGraphic> _graphics = new List<IGraphic>();

    public void Add(IGraphic graphic)
    {
        _graphics.Add(graphic);
    }

    public void Remove(IGraphic graphic)
    {
        _graphics.Remove(graphic);
    }

    public void Draw()
    {
        foreach (var graphic in _graphics)
        {
            graphic.Draw();
        }
    }
}

// Client
class Program
{
    static void Main(string[] args)
    {
        // Create individual shapes
        IGraphic circle1 = new Circle("Red");
        IGraphic circle2 = new Circle("Blue");
        IGraphic rectangle1 = new Rectangle("Green");

        // Create a composite drawing
        Drawing drawing1 = new Drawing();
        drawing1.Add(circle1);
        drawing1.Add(rectangle1);

        // Another composite drawing
        Drawing drawing2 = new Drawing();
        drawing2.Add(circle2);
        drawing2.Add(drawing1); // Add a drawing inside another drawing

        // Draw everything
        Console.WriteLine("Drawing2 contains:");
        drawing2.Draw();
    }
}

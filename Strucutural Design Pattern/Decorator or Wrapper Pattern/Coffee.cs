/*
Think of a coffee shop:
You buy a basic coffee ☕, and then you can decorate it with milk 🥛, sugar 🍬, or whipped cream 🍦.

The coffee stays the same, but you enhance it with extra features

🔧 Intent of Decorator Pattern:
Add additional behavior to objects at runtime.

Avoid subclassing explosion (i.e., CoffeeWithMilkAndSugar, CoffeeWithMilkOnly, etc.).

Maintain flexibility in extending behavior.

📦 Components:
Component (Interface/Abstract Class): Defines the base behavior.

ConcreteComponent: The original object to be decorated.

Decorator: Abstract class that implements Component and holds a reference to a Component.

ConcreteDecorator: Adds new
*/
using System;

public interface ICoffee{
    string GetDescription();
    int GetCost();
}

public class SimpleCoffee : ICoffee{
    public string GetDescription(){
        return "Simple Coffee";
    }
    public int GetCost(){
        return 5;
    }
}

public abstract class CoffeeDecorator : ICoffee{
    
    protected ICoffee _coffee;
    
    public CoffeeDecorator( ICoffee coffee){
        _coffee = coffee;
    }
    
    public virtual string GetDescription(){
        return _coffee.GetDescription();
    }
    public virtual int GetCost(){
        return _coffee.GetCost();
    }
}

public class MilkDecorator : CoffeeDecorator {
    
    public MilkDecorator(ICoffee _coffee) : base(_coffee) {}
    
    public override string GetDescription(){
        return _coffee.GetDescription() + " Milk";
    }
    public override int GetCost(){
        return _coffee.GetCost() + 5;
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Sugar";
    }

    public override int GetCost()
    {
        return _coffee.GetCost() + 9;
    }
}

class Program{
    public static void Main(string[] args){
        ICoffee coffee = new SimpleCoffee();
        
        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);
        
        Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}" );
        
    }
}

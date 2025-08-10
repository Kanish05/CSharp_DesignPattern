using System;

public interface IPizza {
    string GetDescription();
    double GetCost();
}

public class PlainPizza : IPizza {
    public string GetDescription(){
        return "Dough with Tomato Sauce";
    }
    public double GetCost(){
        return 100.0;
    }
}

public abstract class PizzaDecorator : IPizza {
    protected IPizza _pizza ;
    
    public PizzaDecorator(IPizza pizza){
        _pizza = pizza;
    }
    
    public virtual string GetDescription(){
        return _pizza.GetDescription();
    }
    
    public virtual double GetCost(){
       return _pizza.GetCost();
    }
}

public class CheeseTopping : PizzaDecorator{
    public CheeseTopping(IPizza _pizza) : base(_pizza){}
    
    public override string GetDescription(){
       return _pizza.GetDescription() + ", Cheese";
    }
    
    public override double GetCost(){
       return _pizza.GetCost() + 30.0;
    }
}

public class OliveTopping : PizzaDecorator{
    public OliveTopping (IPizza _pizza) : base(_pizza){}
    
    public override string GetDescription(){
       return _pizza.GetDescription() + ", Olives";
    }
    
    public override double GetCost(){
        return _pizza.GetCost() + 20.0;
    }
}

public class MushroomTopping : PizzaDecorator{
    public MushroomTopping(IPizza _pizza) : base(_pizza){}
    
    public override string GetDescription(){
       return _pizza.GetDescription() + ", Mushrooms";
    }
    
    public override double GetCost(){
       return _pizza.GetCost() + 25.0;
    }
}

class Program{
    public static void Main(string[] args){
        IPizza pizza = new CheeseTopping(new MushroomTopping(new PlainPizza()));
        Console.WriteLine(pizza.GetDescription());
        Console.WriteLine(pizza.GetCost());
    }
}
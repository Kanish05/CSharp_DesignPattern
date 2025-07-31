using System;
//Prodcuts
public interface ICar{
    void StartEngine();
}

public interface IMotorcycle{
    void StartEngine();
}
//Concrete Prodcuts
public class ToyotaCar : ICar{
    public void StartEngine(){
        Console.WriteLine("Toyota Camry engine started with smooth sound");
    }
}

public class ToyotaMotorcycle : IMotorcycle{
    public void StartEngine(){
        Console.WriteLine("Toyota motorcycle engine started with quiet hum");
    }
}

public class HondaCar : ICar{
    public void StartEngine(){
        Console.WriteLine("Honda Civic engine started with sporty sound");
    }
}

public class HondaMotorcycle : IMotorcycle{
    public void StartEngine(){
        Console.WriteLine("Honda CBR engine started with loud roar");
    }
}

public interface IVehicleFactory{
    ICar BuildCars();
    IMotorcycle BuildMotorcycle();
}

public class ToyotaFactory : IVehicleFactory{
    public ICar BuildCars(){
        return new ToyotaCar();
    }
    public IMotorcycle BuildMotorcycle(){
        return new ToyotaMotorcycle();
    }
}

public class HondaFactory : IVehicleFactory{
    public ICar BuildCars(){
        return new HondaCar();
    }
    public IMotorcycle BuildMotorcycle(){
        return new HondaMotorcycle();
    }
}

public class VehicleShowroom{
    private IVehicleFactory factory;
    private IMotorcycle motorcycle;
    private ICar car;
    
    public VehicleShowroom(IVehicleFactory factory){
        this.factory = factory;
    }
    
    public void create(){
        motorcycle = factory.BuildMotorcycle();
        car = factory.BuildCars();
    }
    
    public void display(){
        motorcycle.StartEngine();
        car.StartEngine();
    }
}

class Program{
    public static void Main(string[] args){
        Console.WriteLine("=== Toyota Showroom ===");
        IVehicleFactory toyo = new ToyotaFactory();
        VehicleShowroom vst = new VehicleShowroom(toyo);
        vst.create();
        vst.display();
        Console.WriteLine("\n=== Honda Showroom ===");
        IVehicleFactory hond = new HondaFactory();
        VehicleShowroom vsh = new VehicleShowroom(hond);
        vsh.create();
        vsh.display();
    }
}

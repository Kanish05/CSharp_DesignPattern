using System;

public class Car{
    public int Seats {get;set;}
    public string Engine { get; set; }
    public bool TripComputer { get; set; }
    public bool GPS { get; set; }
    
    public override string ToString(){
        return $"Car[Seats={Seats},Engine= {Engine}, TripComputer = {TripComputer} , GPS = {GPS}]";
    }
} 

public class Mannual{
    public string content{get;set;} = "";
    public void AddContent(string section){
        content += section;
    }
    public override string ToString(){
        return "Mannual:\n" + content;
    }
}

public interface IBuilder{
    void Reset();
    void SetSeats(int num);
    void SetEngine(string type);
    void SetTripComputer(bool hasTrip);
    void SetGPS(bool hasgps);
}

public class CarBuilder : IBuilder{
    private Car car;
    public CarBuilder(){
        Reset();
    }
    
    public void Reset(){
        car = new Car();
    }
    
    public void SetSeats(int num){
        car.Seats = num;
    }
    
    public void SetEngine(string type){
        car.Engine = type;
    }
    
    public void SetTripComputer(bool hasTrip){
        car.TripComputer = hasTrip;
    }
    public void SetGPS(bool hasGPS){
        car.GPS = hasGPS;
    }
    
    public Car GetProduct(){
        Car product = car;
        Reset();
        return product;
    }
}
public class CarMannualBuilder : IBuilder{
    private Mannual mann;
    
    public CarMannualBuilder(){
        Reset();
    }
    
    public void Reset(){
        mann = new Mannual();
    }
    
     public void SetSeats(int num){
        mann.AddContent($"Number of Seats = {num}");
    }
    
    public void SetEngine(string type){
        mann.AddContent($"Engine Type = {type}");
    }
    
    public void SetTripComputer(bool hasTrip){
        mann.AddContent($"Has Dashboard = {hasTrip}");
    }
    public void SetGPS(bool hasGPS){
        mann.AddContent($"Has Gps in Dashboard = {hasGPS}");
    }
    
    public Mannual GetProduct(){
        Mannual mannual = mann;
        Reset();
        return mannual;
    }
}

public class Director{
    public void BuildSports(IBuilder builder){
        builder.Reset();
        builder.SetSeats(2);
        builder.SetEngine("SportEngine");
        builder.SetTripComputer(true);
        builder.SetGPS(true);
    }
    public void BuildSUV(IBuilder builder){
        builder.Reset();
        builder.SetSeats(7);
        builder.SetEngine("DieselEngine");
        builder.SetTripComputer(true);
        builder.SetGPS(false);
    }
}

public class Application{
    public void MakeCar(){
        Director dir = new Director();
        CarBuilder cb = new CarBuilder();
        dir.BuildSports(cb);
        Car cr = cb.GetProduct();
        Console.WriteLine(cr); 
        
        CarMannualBuilder cmb = new CarMannualBuilder();
        dir.BuildSports(cmb);
        Mannual man = cmb.GetProduct();
        Console.WriteLine(man);
    }
    public static void Main(string[] args)
    {
        Application app = new Application();
        app.MakeCar();
    }
}

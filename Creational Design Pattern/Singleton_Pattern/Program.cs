using System;
class Logger{
    private static Logger _instance =null;
    
    private Logger(){}
    
    public static Logger GetInstance(){
        if(_instance == null){
            _instance = new Logger();
        }
        return _instance;
    }
    
    public void LogInfo(string message){
        string datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        string level = " INFO:";
        Console.WriteLine(datetime+level+message);
    }
    public void LogError(string message){
        string datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        string level = " ERROR:";
        Console.WriteLine(datetime+level+message);
    }
    public void LogWarning(string message){
        string datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        string level = " WARNING:";
        Console.WriteLine(datetime+level+message);
    }
}

class CustomerService{
    public void DoLog(){
    Logger lg = Logger.GetInstance();
    lg.LogInfo("Customer John Doe registered");
    lg.LogInfo("Order #1001 processed for customer ID: 123");

    }
}

class OrderService{
    public void DoLog(){
    Logger lg = Logger.GetInstance();
    lg.LogError("Database connection failed");
    }
}

class ErrorHandler{
    public void DoLog(){
    Logger lg = Logger.GetInstance();
    lg.LogWarning("Low inventory for product XYZ");
    }
}

class Program{
    public static void Main(string[] args){
        CustomerService cs = new CustomerService();
        OrderService os = new OrderService();
        ErrorHandler es = new ErrorHandler();
        
        cs.DoLog();
        os.DoLog();
        es.DoLog();
    }
}

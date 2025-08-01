/*
Problem Statement: "Smart Home Device Integration"
You’re developing a smart home automation system that controls devices through a common interface. Your system expects all smart devices to implement the following interface:

csharp
Copy
Edit
public interface ISmartDevice
{
    void TurnOn();
    void TurnOff();
}
You already have some modern smart devices like SmartLight, SmartFan, etc., that implement this interface directly.

However, there's a legacy device: OldHeater, which was built long ago. It has a different API:

csharp
Copy
Edit
public class OldHeater
{
    public void EnableHeater() { ... }
    public void DisableHeater() { ... }
}
You are not allowed to modify the OldHeater class. But you want it to be controllable through your system like other smart devices.

🛠️ Your Task:
Create the ISmartDevice interface.

Implement SmartLight or any one modern device.

Create the OldHeater class (the adaptee).

Use the Adapter Pattern to wrap OldHeater so it can be used like an ISmartDevice.

In your Main(), turn on and off both a SmartLight and the OldHeater (via adapter).
*/

using System;

public interface ISmartDevice
{
    void TurnOn();
    void TurnOff();
}

public class SmartLight : ISmartDevice{
    public void TurnOn(){
        Console.WriteLine("Light On");
    }
    public void TurnOff(){
        Console.WriteLine("Light Off");
    }
}

public class OldHeater
{
    public void EnableHeater() { Console.WriteLine("Heater On"); }
    public void DisableHeater() {  Console.WriteLine("Heater Off"); }
}

public class ApplianceAdapter : ISmartDevice{
    private OldHeater oldHeater;
    
    public ApplianceAdapter(OldHeater oldHeater){
        this.oldHeater = oldHeater;
    }
    
    public void TurnOn(){
        oldHeater.EnableHeater();
    }
    
    public void TurnOff(){
        oldHeater.DisableHeater();
    }
}

class Program{
    public static void Main(string[] args){
        OldHeater heater = new OldHeater();
        ApplianceAdapter adapter = new ApplianceAdapter(heater);
        adapter.TurnOn();
        adapter.TurnOff();
    }
}

   
/*
 What is the Bridge Pattern?
The Bridge Pattern is used to decouple an abstraction from its implementation so that the two can vary independently.

🚨 When to Use It?
When you want to avoid a big class explosion due to too many combinations of abstraction and implementation.

When you need to separate what something does from how it does it.

🔌 Real-World Analogy: Remote Control and Devices
Imagine:

You have remotes (basic or advanced).

And you have devices (TV, Radio, etc.).

You want:

Any remote to work with any device, without creating classes like BasicTVRemote, AdvancedTVRemote, BasicRadioRemote, etc.
 Abstraction
             |
      ------------------
     |                  |
Refined Abstraction   Implementor
                          |
                     Concrete Implementors
*/

using System;

public interface IDevices{
    void TurnOn();
}

public class TV : IDevices{
    public void TurnOn(){
        Console.WriteLine("TV ON");
    }
}

public class Remote {
    protected IDevices device;
    
    public Remote(IDevices device){
        this.device = device;
    }
    
    public virtual void TurnRemoteOnTV(){
        Console.WriteLine("Remote class");
        device.TurnOn();
    }
}

public class AdvanceRemote :v Remote {
    public AdvanceRemote(IDevices device) : base(device){}
    public override void TurnRemoteOnTV(){
        Console.WriteLine("This method is overriden from Remote class");
        device.TurnOn();
    }
}

class Program{
    public static void Main(string[] args){
        IDevices tv = new TV();
        AdvanceRemote remote = new AdvanceRemote(tv);
        remote.TurnRemoteOnTV();
    }
}

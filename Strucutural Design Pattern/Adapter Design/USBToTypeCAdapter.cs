/*
Imagine:
You have a modern phone that only supports USB-C charging.

But your old charger gives output via Micro-USB.

They’re incompatible directly.
So you use an Adapter that converts Micro-USB to USB-C.
 */

using System;

public interface ITypeCCharger{
    void ChargePhone();
}

public class USBCharger{
    public void ChargePhoneUSB(){
        Console.WriteLine("Phone Charging with USB");
    }
}

public class USBtoTypeCAdapter : ITypeCCharger{
    private USBCharger _usbCharger;
    
    public USBtoTypeCAdapter(USBCharger charger){
        _usbCharger = charger;
    }
    
    public void ChargePhone(){
        _usbCharger.ChargePhoneUSB();
    }
}

public class Program{
    public static void Main(string[] args){
        USBCharger oldcharger =  new USBCharger();
        USBtoTypeCAdapter adapter = new USBtoTypeCAdapter(oldcharger);
        adapter.ChargePhone();
    }
}
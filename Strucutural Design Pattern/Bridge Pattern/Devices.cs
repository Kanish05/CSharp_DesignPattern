/*
Imagine you are designing Remote Controls for different devices like TV, Radio, Projector, etc.

Instead of creating:

TVRemote, RadioRemote, ProjectorRemote...
You create:

A Remote abstraction and Device implementations, and bridge them together.
*/

using System;

public interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetVolume(int volume);
}

public class TV : IDevice
{
    public void TurnOn() => Console.WriteLine("TV turned ON.");
    public void TurnOff() => Console.WriteLine("TV turned OFF.");
    public void SetVolume(int volume) => Console.WriteLine($"TV volume set to {volume}.");
}

public class Radio : IDevice
{
    public void TurnOn() => Console.WriteLine("Radio turned ON.");
    public void TurnOff() => Console.WriteLine("Radio turned OFF.");
    public void SetVolume(int volume) => Console.WriteLine($"Radio volume set to {volume}.");
}

public class RemoteControl
{
    protected IDevice device;

    public RemoteControl(IDevice device)
    {
        this.device = device;
    }

    public virtual void TurnOnDevice()
    {
        device.TurnOn();
    }

    public virtual void TurnOffDevice()
    {
        device.TurnOff();
    }

    public virtual void SetDeviceVolume(int volume)
    {
        device.SetVolume(volume);
    }
}

public class AdvancedRemote : RemoteControl
{
    public AdvancedRemote(IDevice device) : base(device) {}

    public void Mute()
    {
        Console.WriteLine("Muting the device...");
        device.SetVolume(0);
    }
}

class Program
{
    static void Main()
    {
        IDevice tv = new TV();
        IDevice radio = new Radio();

        RemoteControl tvRemote = new RemoteControl(tv);
        tvRemote.TurnOnDevice();
        tvRemote.SetDeviceVolume(20);
        tvRemote.TurnOffDevice();

        Console.WriteLine();

        AdvancedRemote radioRemote = new AdvancedRemote(radio);
        radioRemote.TurnOnDevice();
        radioRemote.SetDeviceVolume(10);
        radioRemote.Mute();
        radioRemote.TurnOffDevice();
    }
}

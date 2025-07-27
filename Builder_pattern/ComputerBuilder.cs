using System;
using System.Collections.Generic;

// The final product - Computer
public class Computer
{
    public string CPU { get; private set; }
    public string GPU { get; private set; }
    public int RAM { get; private set; }
    public int Storage { get; private set; }
    public string StorageType { get; private set; }
    public bool HasWiFi { get; private set; }
    public bool HasBluetooth { get; private set; }
    public string OperatingSystem { get; private set; }
    public List<string> Accessories { get; private set; }

    // Private constructor - only builder can create Computer
    private Computer(ComputerBuilder builder)
    {
        CPU = builder.CPU;
        GPU = builder.GPU;
        RAM = builder.RAM;
        Storage = builder.Storage;
        StorageType = builder.StorageType;
        HasWiFi = builder.HasWiFi;
        HasBluetooth = builder.HasBluetooth;
        OperatingSystem = builder.OperatingSystem;
        Accessories = new List<string>(builder.Accessories);
    }

    public override string ToString()
    {
        var accessories = Accessories.Count > 0 ? string.Join(", ", Accessories) : "None";
        return $@"Computer Specifications:
- CPU: {CPU}
- GPU: {GPU}
- RAM: {RAM}GB
- Storage: {Storage}GB {StorageType}
- WiFi: {HasWiFi}
- Bluetooth: {HasBluetooth}
- OS: {OperatingSystem}
- Accessories: {accessories}";
    }

    // Builder class as nested class
    public class ComputerBuilder
    {
        public string CPU { get; private set; }
        public string GPU { get; private set; }
        public int RAM { get; private set; }
        public int Storage { get; private set; }
        public string StorageType { get; private set; } = "HDD";
        public bool HasWiFi { get; private set; } = false;
        public bool HasBluetooth { get; private set; } = false;
        public string OperatingSystem { get; private set; } = "Windows 11";
        public List<string> Accessories { get; private set; } = new List<string>();

        // Required parameters through constructor
        public ComputerBuilder(string cpu, string gpu)
        {
            CPU = cpu ?? throw new ArgumentNullException(nameof(cpu));
            GPU = gpu ?? throw new ArgumentNullException(nameof(gpu));
        }

        public ComputerBuilder SetRAM(int ram)
        {
            if (ram <= 0)
                throw new ArgumentException("RAM must be positive", nameof(ram));
            
            RAM = ram;
            return this; // Return builder for method chaining
        }

        public ComputerBuilder SetStorage(int storage, string storageType = "HDD")
        {
            if (storage <= 0)
                throw new ArgumentException("Storage must be positive", nameof(storage));
            
            Storage = storage;
            StorageType = storageType;
            return this;
        }

        public ComputerBuilder EnableWiFi()
        {
            HasWiFi = true;
            return this;
        }

        public ComputerBuilder EnableBluetooth()
        {
            HasBluetooth = true;
            return this;
        }

        public ComputerBuilder SetOperatingSystem(string os)
        {
            OperatingSystem = os ?? throw new ArgumentNullException(nameof(os));
            return this;
        }

        public ComputerBuilder AddAccessory(string accessory)
        {
            if (!string.IsNullOrEmpty(accessory))
            {
                Accessories.Add(accessory);
            }
            return this;
        }

        public ComputerBuilder AddAccessories(params string[] accessories)
        {
            foreach (var accessory in accessories)
            {
                if (!string.IsNullOrEmpty(accessory))
                {
                    Accessories.Add(accessory);
                }
            }
            return this;
        }

        // Build method with validation
        public Computer Build()
        {
            // Validation before building
            if (string.IsNullOrEmpty(CPU))
                throw new InvalidOperationException("CPU is required");
            
            if (string.IsNullOrEmpty(GPU))
                throw new InvalidOperationException("GPU is required");
            
            if (RAM <= 0)
                throw new InvalidOperationException("RAM must be specified");
            
            if (Storage <= 0)
                throw new InvalidOperationException("Storage must be specified");

            return new Computer(this);
        }
    }
}

// Director class - optional, helps with common configurations
public class ComputerDirector
{
    private Computer.ComputerBuilder _builder;

    public ComputerDirector(Computer.ComputerBuilder builder)
    {
        _builder = builder;
    }

    public Computer BuildGamingComputer()
    {
        return _builder
            .SetRAM(32)
            .SetStorage(1000, "SSD")
            .EnableWiFi()
            .EnableBluetooth()
            .SetOperatingSystem("Windows 11 Pro")
            .AddAccessories("Gaming Keyboard", "Gaming Mouse", "RGB Lighting")
            .Build();
    }

    public Computer BuildOfficeComputer()
    {
        return _builder
            .SetRAM(16)
            .SetStorage(512, "SSD")
            .EnableWiFi()
            .SetOperatingSystem("Windows 11")
            .AddAccessories("Wireless Keyboard", "Wireless Mouse")
            .Build();
    }

    public Computer BuildBudgetComputer()
    {
        return _builder
            .SetRAM(8)
            .SetStorage(256, "HDD")
            .EnableWiFi()
            .SetOperatingSystem("Windows 11 Home")
            .Build();
    }
}

// Usage examples
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Builder Pattern Demo ===\n");

        // Example 1: Manual building
        Console.WriteLine("1. Custom Gaming Computer:");
        var gamingPC = new Computer.ComputerBuilder("Intel i9-13900K", "RTX 4080")
            .SetRAM(32)
            .SetStorage(2000, "NVMe SSD")
            .EnableWiFi()
            .EnableBluetooth()
            .SetOperatingSystem("Windows 11 Pro")
            .AddAccessory("Mechanical Keyboard")
            .AddAccessory("Gaming Mouse")
            .AddAccessory("4K Monitor")
            .Build();

        Console.WriteLine(gamingPC);
        Console.WriteLine();

        // Example 2: Basic office computer
        Console.WriteLine("2. Basic Office Computer:");
        var officePC = new Computer.ComputerBuilder("Intel i5-12400", "Intel UHD Graphics")
            .SetRAM(16)
            .SetStorage(512, "SSD")
            .EnableWiFi()
            .SetOperatingSystem("Windows 11")
            .Build();

        Console.WriteLine(officePC);
        Console.WriteLine();

        // Example 3: Using Director for common configurations
        Console.WriteLine("3. Using Director Pattern:");
        var builder = new Computer.ComputerBuilder("AMD Ryzen 7 7700X", "RTX 4070");
        var director = new ComputerDirector(builder);
        
        var prebuiltGaming = director.BuildGamingComputer();
        Console.WriteLine("Director-built Gaming PC:");
        Console.WriteLine(prebuiltGaming);
        Console.WriteLine();

        // Example 4: Minimal computer
        Console.WriteLine("4. Minimal Computer:");
        var minimalPC = new Computer.ComputerBuilder("Intel i3-12100", "Intel UHD Graphics")
            .SetRAM(8)
            .SetStorage(256, "HDD")
            .Build();

        Console.WriteLine(minimalPC);
    }
}
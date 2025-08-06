/*
👨‍💻 Simple Real-Life Example in C#: Home Theater System
Imagine a home theater system with these components:

DVD Player

Projector

Surround Sound System

Lights

We’ll build a Facade called HomeTheaterFacade to control them all.
*/
using System;

// Subsystem 1
public class DVDPlayer {
    public void On() => Console.WriteLine("DVD Player is ON");
    public void Play() => Console.WriteLine("DVD Player is Playing Movie");
    public void Off() => Console.WriteLine("DVD Player is OFF");
}

// Subsystem 2
public class Projector {
    public void On() => Console.WriteLine("Projector is ON");
    public void WideScreenMode() => Console.WriteLine("Projector set to widescreen mode");
    public void Off() => Console.WriteLine("Projector is OFF");
}

// Subsystem 3
public class SurroundSoundSystem {
    public void On() => Console.WriteLine("Surround Sound is ON");
    public void SetVolume(int level) => Console.WriteLine($"Volume set to {level}");
    public void Off() => Console.WriteLine("Surround Sound is OFF");
}

// Subsystem 4
public class Lights {
    public void Dim(int level) => Console.WriteLine($"Lights dimmed to {level}%");
}

// Facade
public class HomeTheaterFacade {
    private DVDPlayer dvd;
    private Projector projector;
    private SurroundSoundSystem soundSystem;
    private Lights lights;

    public HomeTheaterFacade(DVDPlayer dvd, Projector projector, SurroundSoundSystem soundSystem, Lights lights) {
        this.dvd = dvd;
        this.projector = projector;
        this.soundSystem = soundSystem;
        this.lights = lights;
    }

    public void WatchMovie() {
        Console.WriteLine("\n--- Getting ready to watch a movie ---");
        lights.Dim(10);
        projector.On();
        projector.WideScreenMode();
        soundSystem.On();
        soundSystem.SetVolume(7);
        dvd.On();
        dvd.Play();
    }

    public void EndMovie() {
        Console.WriteLine("\n--- Shutting down movie theater ---");
        dvd.Off();
        soundSystem.Off();
        projector.Off();
        lights.Dim(100);
    }
}

// Client Code
public class Program {
    public static void Main(string[] args) {
        // Creating individual subsystems
        DVDPlayer dvd = new DVDPlayer();
        Projector projector = new Projector();
        SurroundSoundSystem soundSystem = new SurroundSoundSystem();
        Lights lights = new Lights();

        // Creating the facade
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(dvd, projector, soundSystem, lights);

        // Using the facade
        homeTheater.WatchMovie();

        Console.WriteLine("\n...Some time later...\n");

        homeTheater.EndMovie();
    }
}

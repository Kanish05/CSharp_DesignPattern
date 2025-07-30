using System;

class Badminton {
    private static readonly Lazy<Badminton> _instance = new Lazy<Badminton>(()=> new Badminton());
    public static Badminton Instance => _instance.Value;
    
    private Badminton() {
        // Private constructor to prevent instantiation
    }
    public void play(){
        Console.WriteLine("Smash");
    }
}

class Program{
    public static void Main(string[] args){
        Badminton.Instance.play();
    }
}
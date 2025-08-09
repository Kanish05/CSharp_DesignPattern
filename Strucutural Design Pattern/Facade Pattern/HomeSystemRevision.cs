using System;

public class LightSystem {
    public string ControlLightOn() => "Light Turns on" ;
     public string ControlLightOff() => "Light Turns off" ;
}

public class SecuritySystem  {
    public string ControlSecurityArm() => "Arm Security Alarm" ;
    public string ControlSecurityDisArm() => "DisArm Security Alarm" ;
}

public class ClimateControlSystem {
    public string ClimateControlOn() => "Adjust Temperature on";
    public string ClimateControlOff() => "Adjust Temperature off";
}

public class MusicSystem{
    public string ControlMusicPlay() => "Plays music";
    public string ControlMusicStop() => "Stops music";
}


public class SmartHomeFacade {
    private LightSystem _light;
    private SecuritySystem _security;
    private ClimateControlSystem _climate;
    private MusicSystem _music;
    
    public SmartHomeFacade(LightSystem light, SecuritySystem security,ClimateControlSystem climate, MusicSystem music){
        _light = light;
        _security = security;
        _climate = climate;
        _music = music;
    }
    
    public void StartMovieNight(){
        Console.WriteLine(_light.ControlLightOff());
        Console.WriteLine(_security.ControlSecurityDisArm());
        Console.WriteLine(_climate.ClimateControlOn());
        Console.WriteLine(_music.ControlMusicPlay());
    }
    
    public void LeaveHome(){
        Console.WriteLine(_light.ControlLightOff());
        Console.WriteLine(_security.ControlSecurityArm());
        Console.WriteLine(_climate.ClimateControlOff());
        Console.WriteLine(_music.ControlMusicStop());
    }
}

class Program{
    public static void Main(string[] args){
        LightSystem light =  new LightSystem();
        SecuritySystem security = new SecuritySystem();
        ClimateControlSystem climate = new ClimateControlSystem();
        MusicSystem music = new MusicSystem();
        
        SmartHomeFacade homeControl = new SmartHomeFacade(light,security,climate,music);
        homeControl.StartMovieNight();
        homeControl.LeaveHome();
    }
}

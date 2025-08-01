/*
Your media player application supports playing only MP4 files using an interface IMediaPlayer with a method Play(string fileName).

However, there's an existing legacy media player class that plays VLC files with a different method PlayVLC(string fileName).

You’re tasked with making the application compatible with VLC files without modifying the legacy class.

Requirements:
Define an interface IMediaPlayer with void Play(string fileName).

Create a concrete class MP4Player that implements IMediaPlayer and can play MP4 files.

Use the Adapter Pattern to:

Adapt a legacy class VLCPlayer (with void PlayVLC(string fileName)) to be usable via the IMediaPlayer interface.

In the Main method (or similar), show how both MP4 and VLC files can be played using the IMediaPlayer interface.
*/
using System;

public interface IMediaPlayer{
    void Play(string fileName);
}

public class VLCPlayer{
    public void PlayVLC(string fileName){
        Console.WriteLine("Playing with VLC");
    }
}

public class MP4Player : IMediaPlayer{
    public void Play(string fileName){
        Console.WriteLine("Playing with MP4Player");
    }
}

public class Mp4ToVlcAdapter : IMediaPlayer{
    private VLCPlayer vlcplayer;
    
    public Mp4ToVlcAdapter(VLCPlayer vlcplayer){
        this.vlcplayer = vlcplayer;
    }
    
    public void Play(string fileName){
        vlcplayer.PlayVLC("xx");
    }
}

class Program{
    public static void Main(string[] args){
        VLCPlayer player = new VLCPlayer();
        Mp4ToVlcAdapter adapter = new Mp4ToVlcAdapter(player);
        adapter.Play("xx");
    }
}


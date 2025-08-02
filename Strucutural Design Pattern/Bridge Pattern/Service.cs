/*
🌉 Bridge Pattern Example: Messaging System
📖 Scenario:
You're building a cross-platform messaging system. Messages can be of different types (like Text or Email), and they can be sent via different channels (like SMS or Email service).

You want to:

Allow messages to vary independently from the sending mechanism.

Avoid creating classes like TextMessageViaSMS, TextMessageViaEmail, EmailMessageViaSMS, etc.
*/

using System;

public interface ISender
{
    void Send(string message);
}

public class SMSSender : ISender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class EmailSender : ISender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public abstract class Message
{
    protected ISender sender;

    public Message(ISender sender)
    {
        this.sender = sender;
    }

    public abstract void SendMessage(string content);
}

public class TextMessage : Message
{
    public TextMessage(ISender sender) : base(sender) {}

    public override void SendMessage(string content)
    {
        sender.Send("Text: " + content);
    }
}

public class EmailMessage : Message
{
    public EmailMessage(ISender sender) : base(sender) {}

    public override void SendMessage(string content)
    {
        sender.Send("Email Body: " + content);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ISender sms = new SMSSender();
        ISender email = new EmailSender();

        Message msg1 = new TextMessage(sms);
        msg1.SendMessage("Hello via SMS!");

        Message msg2 = new EmailMessage(email);
        msg2.SendMessage("Hello via Email!");

        // Even mix them up
        Message msg3 = new TextMessage(email);
        msg3.SendMessage("Sending a text over Email!");
    }
}



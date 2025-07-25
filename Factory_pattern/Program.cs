using System;
public interface INotification
{
    void Send(string to, string message);
}

// Concrete products
public class EmailNotification : INotification
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"Sending EMAIL to {to}: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"Sending SMS to {to}: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"Sending PUSH notification to {to}: {message}");
    }
}

// Abstract factory
public abstract class NotificationFactory
{
    public void Notify(string to, string message)
    {
        INotification notification = CreateNotification();
        notification.Send(to, message);
    }

    public abstract INotification CreateNotification();
}

// Concrete factories
public class EmailNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public class SMSNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SMSNotification();
    }
}

public class PushNotificationFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}

// Client
public class Application
{
    public static void Main(string[] args)
    {
        NotificationFactory factory = new EmailNotificationFactory();
        factory.Notify("john@example.com", "Welcome to the system!");

        factory = new SMSNotificationFactory();
        factory.Notify("9876543210", "Your OTP is 1234");

        factory = new PushNotificationFactory();
        factory.Notify("PushUserID123", "You have a new message.");
    }
}

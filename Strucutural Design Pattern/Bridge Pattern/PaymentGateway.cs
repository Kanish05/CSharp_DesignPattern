/*
We’ll do Payment Processing — which is a great fit for the Bridge pattern because:

We have Payment Types (Online, Offline, Subscription, etc.)

And we have Payment Gateways (PayPal, Stripe, Razorpay, etc.)

Without the Bridge → huge class explosion: OnlinePayPalPayment, OnlineStripePayment, OfflinePayPalPayment, … yikes.


How This is the Bridge Pattern
Abstraction → Payment (OnlinePayment, SubscriptionPayment)

Implementation → IPaymentGateway (PayPalGateway, StripeGateway)

Bridge → The gateway object in Payment

Benefits:

Add a new payment type (e.g., OfflinePayment) without touching gateways.

Add a new gateway (e.g., RazorpayGateway) without touching payment types.

You can mix and match at runtime.
*/

using System;

// Implementation hierarchy (Payment Gateway)
public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}

public class PayPalGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount} via PayPal");
    }
}

public class StripeGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount} via Stripe");
    }
}

// Abstraction hierarchy (Payment Type)
public abstract class Payment
{
    protected IPaymentGateway gateway; // Bridge to implementation

    protected Payment(IPaymentGateway gateway)
    {
        this.gateway = gateway;
    }

    public abstract void MakePayment(decimal amount);
}

// Refined Abstractions
public class OnlinePayment : Payment
{
    public OnlinePayment(IPaymentGateway gateway) : base(gateway) { }

    public override void MakePayment(decimal amount)
    {
        Console.WriteLine("Initiating Online Payment...");
        gateway.ProcessPayment(amount);
    }
}

public class SubscriptionPayment : Payment
{
    public SubscriptionPayment(IPaymentGateway gateway) : base(gateway) { }

    public override void MakePayment(decimal amount)
    {
        Console.WriteLine("Initiating Subscription Payment...");
        gateway.ProcessPayment(amount);
    }
}

// Client code
class Program
{
    static void Main()
    {
        Payment onlinePayPal = new OnlinePayment(new PayPalGateway());
        onlinePayPal.MakePayment(250);

        Console.WriteLine();

        Payment subscriptionStripe = new SubscriptionPayment(new StripeGateway());
        subscriptionStripe.MakePayment(99.99m);
    }
}

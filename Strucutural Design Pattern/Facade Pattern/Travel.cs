/*
🧳 Problem Statement: "Travel Booking System"
You're designing a travel booking system. When a user wants to book a trip, the system should:

Subsystems:
FlightBookingService – Books the flight.

HotelBookingService – Reserves a hotel.

CarRentalService – Reserves a rental car.

You will create a TravelFacade class that simplifies the booking process into a single method:

✅ Your Task:
Create each subsystem with relevant methods (BookFlight, BookHotel, RentCar).

Implement the TravelFacade class with a method BookTrip(string location).

Console output should simulate the booking process.

Return a summary like: "Trip to Paris booked successfully!"
*/
using System;

// Subsystem 1
public class FlightBookingService {
    public void BookFlight(string destination) {
        Console.WriteLine($"Flight to {destination} booked.");
    }
}

// Subsystem 2
public class HotelBookingService {
    public void BookHotel(string destination) {
        Console.WriteLine($"Hotel in {destination} reserved.");
    }
}

// Subsystem 3
public class CarRentalService {
    public void RentCar(string destination) {
        Console.WriteLine($"Rental car booked for {destination}.");
    }
}

// Facade
public class TravelFacade {
    private FlightBookingService _flightService;
    private HotelBookingService _hotelService;
    private CarRentalService _carService;

    public TravelFacade(FlightBookingService flightService, HotelBookingService hotelService, CarRentalService carService) {
        _flightService = flightService;
        _hotelService = hotelService;
        _carService = carService;
    }

    public void BookTrip(string destination) {
        Console.WriteLine($"\nBooking a trip to {destination}...\n");

        _flightService.BookFlight(destination);
        _hotelService.BookHotel(destination);
        _carService.RentCar(destination);

        Console.WriteLine($"\nResult: Trip to {destination} booked successfully!");
    }
}

// Client Code
public class Program {
    public static void Main(string[] args) {
        // Create the subsystems
        FlightBookingService flight = new FlightBookingService();
        HotelBookingService hotel = new HotelBookingService();
        CarRentalService car = new CarRentalService();

        // Create the facade
        TravelFacade travelFacade = new TravelFacade(flight, hotel, car);

        // Use the facade
        travelFacade.BookTrip("Paris");

        Console.WriteLine();
        travelFacade.BookTrip("New York");
    }
}

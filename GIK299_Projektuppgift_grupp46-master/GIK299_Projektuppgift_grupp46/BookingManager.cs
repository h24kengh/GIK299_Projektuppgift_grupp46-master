﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace GIK299_Projektuppgift_grupp46
{
    public class BookingManager :Booking
    {
        private static List<Booking> bookings = new List<Booking>();

        public Booking GetBookingDetails()
        {
            Console.Write("Ange kundens namn: ");
            CustomerName = Console.ReadLine();

            Console.Write("Ange bilens registreringsnummer (ABC123): ");
            VehicleRegNr = Console.ReadLine();

            Console.Write("Ange bokningsdatum (ÅÅÅÅ-MM-DD): ");
            DateTime bookingDate;
            while (!DateTime.TryParse(Console.ReadLine(), out bookingDate))
            {
                Console.WriteLine("Fel: Ogiltigt datumformat. Försök igen.");
                Console.Write("Ange bokningsdatum (ÅÅÅÅ-MM-DD): ");
            }

            // Tilldela det bokade datumet
            Date = bookingDate;

            Console.Write("Ange bokningstid (HH:MM): ");
            Time = Console.ReadLine();

            Console.Write("Ange vilken tjänst som ska utföras: ");
            ServiceType = Console.ReadLine();

            // Skapa och returnera ett nytt Booking-objekt
            Booking booking = new Booking()
            {
                CustomerName = CustomerName,
                VehicleRegNr = VehicleRegNr,
                Date = Date,
                Time = Time,
                ServiceType = ServiceType
            };

            return booking; // Returnera objektet
        }

        
        public static void AddBooking(BookingManager bookingManager)
        {
            if (IsBookingValid(bookingManager))
            {
                bookings.Add(bookingManager);
                Console.WriteLine("Bokningen tillagd: " + bookingManager.ToString());
            }
            else
            {
                Console.WriteLine("Fel: Bokningen kan inte genomföras. Dubbelbokning eller ogiltiga uppgifter.");
            }
        }

        private static bool IsBookingValid(BookingManager bookingManager)
        {
            foreach (var booking in bookings)
            {
                if (booking.Date == bookingManager.Date && bookingManager.Time == bookingManager.Time)
                {
                    return false;
                }
            }
            
                    return true;
                }
            

           public override string ToString()
        {
            return $"{CustomerName} - {ServiceType} den {Date.ToShortDateString()} kl. {Time}";

        }


            public static void ShowAllBookings()
        {
            Console.WriteLine("Alla bokningar: ");
            foreach (var booking in bookings)
            {
                Console.WriteLine(booking.ToString());
            }
        }
       
}
            


    }
    public class Booking
    {
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? CustomerName { get; set; }
        public string? VehicleRegNr { get; set; }
        public string? ServiceType { get; set; }
    }

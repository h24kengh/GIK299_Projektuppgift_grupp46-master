using System;
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
            Console.Write("\nAnge kundens namn: ");
            CustomerName = Console.ReadLine();

            Console.Write("\nAnge bilens registreringsnummer (ABC123): ");
            VehicleRegNr = Console.ReadLine();

            Console.Write("\nAnge bokningsdatum (ÅÅÅÅ-MM-DD): ");
            DateTime bookingDate;
            while (!DateTime.TryParse(Console.ReadLine(), out bookingDate))
            {
                Console.WriteLine("\nFel: Ogiltigt datumformat. Försök igen.");
                Console.Write("\nAnge bokningsdatum (ÅÅÅÅ-MM-DD): ");
            }

            // Tilldela det bokade datumet
            Date = bookingDate;

            Console.Write("\nAnge bokningstid (HH:MM): ");
            Time = Console.ReadLine();

            Console.Write("\nAnge tjänst (Hjulbyte, Däckhotell, Hjulinställning, Däckbyte): ");
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

        public static void AddBooking()
        {
            BookingManager bookingManager = new BookingManager();
            bookingManager.GetBookingDetails();

            AddBooking(bookingManager);
        }

        
        public static void AddBooking(BookingManager bookingManager)
        {
            if (IsBookingValid(bookingManager))
            {
                bookings.Add(bookingManager);
                Console.Clear();
                Console.WriteLine("Bokningen bekräftad! " + bookingManager.ToString());
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
            return $"\nKundnamn: {CustomerName} \tTjänst: {ServiceType} \nDatum: {Date.ToShortDateString()} \tTid: {Time}\n";

        }

        public static void RemoveBooking()
        {
            ShowAllBookings();

            Console.Write("Ange kundens namn för bokningen du vill ta bort: ");
            string customerToRemove = Console.ReadLine();

            Console.Write("Ange bokningsdatum (ÅÅÅÅ-MM-DD) för bokningen du vill ta bort: ");
            DateTime dateToRemove;
            while(!DateTime.TryParse(Console.ReadLine(), out dateToRemove))
            {
                Console.WriteLine("Felaktigt datumformat (ÅÅÅÅ-MM-DD), försök igen.");
                Console.Write("Ange bokningsdatum (ÅÅÅÅ-MM-DD): ");
            }
            Console.Write("Ange bokningstid (HH:MM): ");
            string timeToRemove = Console.ReadLine();

            var bookingToRemove = bookings.FirstOrDefault(b =>
            b.CustomerName == customerToRemove &&
            b.Date == dateToRemove &&
            b.Time == timeToRemove);

            if (bookingToRemove != null)
            {
                bookings.Remove(bookingToRemove);
                Console.WriteLine();
                Console.WriteLine("Bokningen borttagen!" + bookingToRemove.ToString());
            }
            else
            {
                Console.WriteLine("\n Ingen matchande bokning.");
                
            }
        }
       public static void ChangeBooking()
        {
            ShowAllBookings();
           
           if (bookings.Count == 0)
            {
                return;
            }

            Console.WriteLine("Ange kundens namn för bokningen du vill ändra: ");
            string customerToChange = Console.ReadLine();

            Console.WriteLine("Ange bokingsdatum (ÅÅÅÅ-MM-DD) för bokningen du vill ändra: ");
            DateTime dateToChange;
            while (!DateTime.TryParse(Console.ReadLine(),out dateToChange))
            {
                Console.WriteLine("Felaktigt datumformat (ÅÅÅÅ-MM-DD), försök igen.");
                Console.WriteLine("Ange bokningsdatum (ÅÅÅÅ-MM-DD): ");
            }
            Console.WriteLine("Ange bokningstid (HH:MM): ");
            string timeToChange = Console.ReadLine();

            var bookingToChange = bookings.FirstOrDefault(b =>
            b.CustomerName == customerToChange &&
                b.Date == dateToChange &&
                b.Time == timeToChange);

            if (bookingToChange == null)
            {
                Console.WriteLine("\nIngen matchande bokning hittades.");
                return;
            }

            Console.WriteLine("\nBokning hittad: ");
            Console.WriteLine(bookingToChange.ToString());

            Console.WriteLine("Ange nytt kundnamn (lämna tomt för att behålla): ");
            string newCustomerName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCustomerName))
            {
                bookingToChange.CustomerName = newCustomerName;
            }

            Console.WriteLine("Ange ny bokningstid (HH:MM) (lämna tomt för att behålla): ");
            string newTime = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTime))
            {
                bookingToChange.Time = newTime;
            }

            Console.WriteLine("Ange ny tjänst (lämna tomt för att behålla): ");
            string newServiceType = Console.ReadLine();
            if (!string.IsNullOrEmpty(newServiceType))
            {
                bookingToChange.ServiceType = newServiceType;
            }

          
            Console.WriteLine("\nBokningen har uppdaterats: ");
            Console.WriteLine(bookingToChange.ToString());

        }

        public static void ShowAllBookings()
        {
            //Console.WriteLine("Alla bokningar: ");

            if(bookings.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Det finns inga bokningar just nu.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Alla bokningar: ");
                foreach (var booking in bookings)
                {
                    Console.WriteLine(booking.ToString());
                }
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


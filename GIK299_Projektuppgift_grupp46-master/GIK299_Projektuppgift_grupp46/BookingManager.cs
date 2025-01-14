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
    public class BookingManager : Booking
    {
        public static List<Booking> bookings = new List<Booking>();

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

            Console.Write("\nAnge bokningstid (HH:mm): ");
            Time = Console.ReadLine();



            Service service;
            while (true)
            {
                Console.Write("\nAnge tjänst (Hjulbyte, Däckhotell, Hjulinställning, Däckbyte): ");
                string ServiceType = Console.ReadLine();
                if (Enum.TryParse(ServiceType, true, out service))
                    break;
                Console.WriteLine("\nOgiltig tjänst. Ange något av de listade alternativen.");
            }

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
                Console.WriteLine("Bokningen bekräftad!\n" + bookingManager.ToString());
                ReturnToMainMenu();
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

            if (bookings.Count == 0)
            {
                return;
            }



            Console.Write("Ange kundens namn för bokningen du vill ta bort: ");
            string customerToRemove = Console.ReadLine();

            Console.Write("Ange bokningsdatum (ÅÅÅÅ-MM-DD) för bokningen du vill ta bort: ");
            DateTime dateToRemove;
            while (!DateTime.TryParse(Console.ReadLine(), out dateToRemove))
            {
                Console.WriteLine("Felaktigt datumformat (ÅÅÅÅ-MM-DD), försök igen.");
                Console.Write("Ange bokningsdatum (ÅÅÅÅ-MM-DD): ");
            }
            Console.Write("Ange bokningstid (HH:mm): ");
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
                ReturnToMainMenu();
            }
            else
            {
                Console.WriteLine("\nIngen matchande bokning.");
                ReturnToMainMenu();

            }
        }
        public static void ChangeBooking()
        {
            ShowAllBookings();

            if (bookings.Count == 0)
            {
                return;
            }

            Console.Write("Ange kundens namn för bokningen du vill ändra: ");
            string customerToChange = Console.ReadLine();

            Console.Write("Ange bokingsdatum (ÅÅÅÅ-MM-DD) för bokningen du vill ändra: ");
            DateTime dateToChange;
            while (!DateTime.TryParse(Console.ReadLine(), out dateToChange))
            {
                Console.WriteLine("Felaktigt datumformat (ÅÅÅÅ-MM-DD), försök igen.");
                Console.Write("Ange bokningsdatum (ÅÅÅÅ-MM-DD): ");
            }
            Console.Write("Ange bokningstid (HH:mm): ");
            string timeToChange = Console.ReadLine();

            var bookingToChange = bookings.FirstOrDefault(b =>
            b.CustomerName == customerToChange &&
                b.Date == dateToChange &&
                b.Time == timeToChange);

            if (bookingToChange == null)
            {
                Console.WriteLine("\nIngen matchande bokning hittades.");
                ReturnToMainMenu();
                return;
            }

            Console.WriteLine("\nBokning hittad: ");
            Console.WriteLine(bookingToChange.ToString());

            Console.Write("Ange nytt kundnamn (lämna tomt för att behålla): ");
            string newCustomerName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCustomerName))
            {
                bookingToChange.CustomerName = newCustomerName;
            }

            Console.Write("Ange ny bokningstid (HH:mm) (lämna tomt för att behålla): ");
            string newTime = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTime))
            {
                bookingToChange.Time = newTime;
            }

            Console.Write("Ange ny tjänst (lämna tomt för att behålla): ");
            string newServiceType = Console.ReadLine();
            if (!string.IsNullOrEmpty(newServiceType))
            {
                bookingToChange.ServiceType = newServiceType;
            }


            Console.WriteLine("\nBokningen har uppdaterats: ");
            Console.WriteLine(bookingToChange.ToString());
            ReturnToMainMenu();
        }

        public static void ShowTodaysBooking()
        {
            var bookings = BookingManager.GetAllBookings();

            if (bookings.Count == 0)
            {
                Console.WriteLine("Det finns inga bokningar idag.");
                BookingManager.ReturnToMainMenu();
                return;
            }

            DateTime today = DateTime.Today;

            var todaysBookings = bookings.Where(b => b.Date.Date == today).ToList();

            if (todaysBookings.Count == 0)
            {
                Console.WriteLine("Det finns inga bokningar idag.");
                ReturnToMainMenu();
                return;
            }

            Console.WriteLine("Dagens bokningar: ");
            foreach (var booking in todaysBookings)
            {
                Console.WriteLine(booking.ToString());

            }
            ReturnToMainMenu();
        }

        public static void ShowBookingForSpecificDay()
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("Det finns inga bokningar i systemet.");
                ReturnToMainMenu();
                return;
            }
            Console.WriteLine();
            Console.Write("Ange datum (ÅÅÅÅ-MM-DD) för att visa bokningar: ");
            DateTime specificDay;
            while (!DateTime.TryParse(Console.ReadLine(), out specificDay))

            {
                Console.WriteLine("Felaktigt datumformat, försök igen.");
                Console.Write("Ange datum (ÅÅÅÅ-MM-DD): ");
            }

            var specificDaysBooking = bookings.Where(b => b.Date.Date == specificDay.Date).ToList();

            if (specificDaysBooking.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Det finns inga bokningar för den valda dagen.");
                Console.WriteLine();

                return;
            }

            Console.WriteLine("Bokningar för den valda dagen: ");
            foreach (var booking in specificDaysBooking)
            {
                Console.WriteLine(booking.ToString());

            }
            ReturnToMainMenu();

        }

        public static void ShowAllBookings()
        {

            if (bookings.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Det finns inga bokningar just nu.");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Alla bokningar: ");
                foreach (var booking in bookings)
                {
                    Console.WriteLine(booking.ToString());

                }
            }
            ReturnToMainMenu();

        }


        public static void ShowAvailableChoises()
        {
            Console.Write("Ange datum (ÅÅÅÅ-MM-DD): ");
            DateTime inputDate;

            while (!DateTime.TryParse(Console.ReadLine(), out inputDate))
            {
                Console.WriteLine("Felaktigt datumformat, försök igen");
                Console.Write("Ange datum (ÅÅÅÅ-MM-DD: ");
            }

            List<string> availableTimes = BookingManager.FindAvailableChoises(inputDate);

            if (availableTimes.Count > 0)
            {
                Console.WriteLine("Tillgängliga tider:");
                foreach (string time in availableTimes)
                {
                    Console.WriteLine(time);

                }
            }
            else
            {
                Console.WriteLine("Inga tillgängliga tider.");

            }
            ReturnToMainMenu();
        }

        public static List<string> FindAvailableChoises(DateTime availableDate)
        {
            List<string> allTimes = new List<string>();
            for (int hour = 7; hour < 16; hour++)
            {
                for (int minute = 0; minute < 60; minute += 30)
                {
                    string timeSlot = new DateTime(availableDate.Year, availableDate.Month, availableDate.Day, hour, minute, 0).ToString("HH:mm");
                    allTimes.Add(timeSlot);
                }
            }

            var bookedTimes = bookings.Where(b => b.Date.Date == availableDate.Date)
                .Select(b => b.Time)
                 .ToList();

            List<string> availableTimes = allTimes.Where(time => !bookedTimes.Contains(time)).ToList();

            return availableTimes;
            Console.WriteLine();

        }
        public static void ReturnToMainMenu()
        {
            Console.Write("Tryck på valfri tangent för att återgå till startmenyn: ");
            Console.ReadKey();
            Console.Clear();
        }


        public static List<Booking> GetAllBookings()
        {
            return bookings;
        }
    }
    public class Booking
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string CustomerName { get; set; }
        public string VehicleRegNr { get; set; }
        public string ServiceType { get; set; }
        public bool IsWorkDone { get; set; }
    }
}

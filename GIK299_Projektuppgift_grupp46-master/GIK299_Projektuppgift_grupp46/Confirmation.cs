using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIK299_Projektuppgift_grupp46
{
    internal class Confirmation
    {
       public static void ConfirmWorkDone()
        {
            BookingManager.ShowAllBookings();

            Console.Write("Ange kundens namn för bokningen: ");
            string customerName = Console.ReadLine();

            Console.Write("Ange bokningsdatum (ÅÅÅÅ-MM-DD): ");
            DateTime bookingDate;
            
            while (!DateTime.TryParse(Console.ReadLine(), out bookingDate))
            {
                Console.WriteLine("Felaktigt datumformat, försök igen.");
                Console.Write("Ange bokningsdatum, (ÅÅÅÅ-MM-DD): ");
            }

            Console.Write("Ange bokningstid (HH:MM): ");
            string bookingTime = Console.ReadLine();

            var bookingToConfirm = BookingManager.bookings.FirstOrDefault(b=>
            b.CustomerName == customerName &&
            b.Date.Date == bookingDate.Date &&
            b.Time == bookingTime);

            if (bookingToConfirm == null)
            {
                Console.WriteLine("Ingen matchande bokning hittades.");
                return;
            }

            bookingToConfirm.IsWorkDone = true;

            Console.WriteLine($"Arbetet för bokningen är nu markerat som klart! {bookingToConfirm.ToString()}");

        }
    }
}

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
            var bookings = BookingManager.GetAllBookings();

            if (bookings.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Det finns inga bokningar att bekräfta.");
                Console.WriteLine();
                BookingManager.ReturnToMainMenu();
                return; 
            }
            Console.Write("Ange kundens namn för bokningen: ");
            string customerName = Console.ReadLine();

            var bookingToConfirm = BookingManager.bookings.FirstOrDefault(b=>
            b.CustomerName == customerName);


            if (bookingToConfirm == null)
            {
                Console.WriteLine("Ingen matchande bokning hittades.");
                return;
            }

            bookingToConfirm.IsWorkDone = true;

            Console.WriteLine($"Arbetet för bokningen är nu markerat som klart! {bookingToConfirm.ToString()}");
            BookingManager.ReturnToMainMenu();

        }
    }
}

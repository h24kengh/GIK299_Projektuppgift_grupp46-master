using System;
using System.Collections.Generic;


namespace GIK299_Projektuppgift_grupp46
{
    class Program
    {
        static List<BookingManager> bookings = new List<BookingManager>();
        static void Main(string[] args)
        {
            Console.WriteLine(new string('*', 80));
            Console.WriteLine("Däckarns bokningsapp\n");

            while (true)
            {
                // Visa meny för bokningssystem
                Console.WriteLine("1.Lägg till bokning");
                Console.WriteLine("2.Ta bort bokning");
                Console.WriteLine("3.Ändra bokning");
                Console.WriteLine("4.Visa dagens bokningar");
                Console.WriteLine("5.Visa bokningar för specifik dag");
                Console.WriteLine("6.Visa alla bokningar");
                Console.WriteLine("7.Bekräfta utfört arbete");
                Console.WriteLine("8.Visa lediga tider för specifik dag");
                Console.WriteLine("9.Avsluta");
                Console.Write("\nVälj ett alternativ: ");

                // Läsa och spara valet för användare 
                var choise = Console.ReadLine();

               

                switch (choise)
                {
                    case "1":
                        BookingManager.AddBooking();
                        break;
                    case "2":
                        BookingManager.RemoveBooking();
                        break;
                    case "3":
                        BookingManager.ChangeBooking();
                        break;
                    case "4":
                        BookingManager.ShowTodaysBooking();
                        break;
                    case "5":
                        BookingManager.ShowBookingForSpecificDay();
                        break;
                    case "6":
                        BookingManager.ShowAllBookings();
                        break;
                    case "7":
                        Confirmation.ConfirmWorkDone();
                        break;
                    case "8":
                        BookingManager.ShowAvailableChoises();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, ange alternativ (1-9) och försök igen.");
                        break;


                }

            }

        }
    }
}

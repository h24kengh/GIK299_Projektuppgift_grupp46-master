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
                Console.WriteLine("8.Söka efter lediga dagar och tider");
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
                        RemoveBooking();
                        break;
                    case "3":
                        ChangeBooking();
                        break;
                    case "4":
                        ShowTodaysBooking();
                        break;
                    case "5":
                        ShowBookingForSpecificDay();
                        break;
                    case "6":
                        ShowAllBookings();
                        break;
                    case "7":
                        ConfirmWorkDone();
                        break;
                    case "8":
                        FindAvailableChoises();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, ange alternativ (1-9) och försök igen.");
                        break;


                }

            }
        }

        //static void AddBooking()
        //{
        //    // Skapa en ny instans av BookingManager för att samla in information om bokningen.
        //    BookingManager bookingManager = new BookingManager();
        //   bookingManager.GetBookingDetails();  // Hämtar bokningsdetaljer från användaren genom att anropa metoden.

        //    // Lägger till den nya bokningen i listan med bokningar.
        //    bookings.Add(bookingManager);
        //    Console.WriteLine("Bokning tillagd: " + bookingManager.ToString()); // Skriver ut en bekräftelse i konsolen 
        //    // med detaljerna för den nya bokningen.
        //}
        static void RemoveBooking()
        {

        }

        static void ChangeBooking()
        {

        }

        static void ShowTodaysBooking()
        {

        }

        static void ShowBookingForSpecificDay()
        {

        }
        static void ShowAllBookings()
        {

        }

        static void ConfirmWorkDone()
        {
        }
        
        static void FindAvailableChoises()
        {

        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RentEasy.Models;
using RentEasy.Services;

namespace RentEasy.Seeder
{
    public class Program
    {
        private static ApartmentService apartmentService = new ApartmentService();
        private static ClientService clientService = new ClientService();
        private static LocationService locationService = new LocationService();
        private static ReservationService reservationService = new ReservationService();

        public static void Main()
        {
            SeedApartments(100);
            SeedClients(100);
            SeedLocations(100);
        }


        
        public static void SeedLocations(int locationCount)
        {
            List<string> locationNames = new List<string>()
            {
                "Downtown", "Suburb", "Beachfront", "Mountain View", "Rural"
            };

            foreach (var name in locationNames)
            {
                locationService.AddLocation(name);
            }
        }

        public static void SeedClients(int clientCount)
        {
            List<string> firstNames = new List<string>()
            {
                "Alice", "Bob", "Charlie", "David", "Eva", "Frank"
            };

            foreach (var firstName in firstNames)
            {
                string phoneNumber = GeneratePhoneNumber();
                clientService.AddClient(firstName, phoneNumber);
            }
        }

        public static void SeedApartments(int apartmentCount)
        {
            Random random = new Random();

            for (int i = 1; i <= apartmentCount; i++)
            {
                string name = $"Apartment {i}";
                string location = "Downtown";
                decimal pricePerNight = random.Next(50, 300);
                int numOfBeds = random.Next(1, 5);

                apartmentService.AddApartment(name, location, pricePerNight, numOfBeds);
            }
        }

        private static int GetRandomId<T>(List<T> entities)
        {
            Random random = new Random();
            PropertyInfo idProperty = entities[0].GetType().GetProperty("Id");
            int index = random.Next(entities.Count);
            return (int)idProperty.GetValue(entities[index]);
        }

        private static DateTime GetRandomStartDate()
        {
            Random random = new Random();
            DateTime start = new DateTime(2023, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private static int GetRandomDuration()
        {
            Random random = new Random();
            return random.Next(1, 14);
        }

        private static string GeneratePhoneNumber()
        {
            Random random = new Random();
            return $"{random.Next(100, 999)}{random.Next(100, 999)}{random.Next(1000, 9999)}";
        }
    }
}

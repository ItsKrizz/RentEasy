using RentEasy.Services;
using RentEasy.Models;
using System;
using System.Collections.Generic;

namespace RentEasy.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            ApartmentService apartmentService = new ApartmentService();
            ClientService clientService = new ClientService();
            LocationService locationService = new LocationService();
            ReservationService reservationService = new ReservationService();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the RentEasy system!");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Add apartment");
                Console.WriteLine("2 - Add client");
                Console.WriteLine("3 - Add location");
                Console.WriteLine("4 - List all apartments");
                Console.WriteLine("5 - List all clients");
                Console.WriteLine("6 - List all locations");
                Console.WriteLine("7 - Update apartment beds");
                Console.WriteLine("8 - Delete apartment by ID");
                Console.WriteLine("9 - Add Reservation");
                Console.Write("Enter your choice: ");
                string choiceString = Console.ReadLine();

                if (!int.TryParse(choiceString, out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 0 and 9.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        exit = true;
                        Console.WriteLine("Exiting the RentEasy system...");
                        break;
                    case 1:
                        AddApartment(apartmentService);
                        break;
                    case 2:
                        AddClient(clientService);
                        break;
                    case 3:
                        AddLocation(locationService);
                        break;
                    case 4:
                        ListAllApartments(apartmentService);
                        break;
                    case 5:
                        ListAllClients(clientService);
                        break;
                    case 6:
                        ListAllLocations(locationService);
                        break;
                   
                        break;
                    case 7:
                        UpdateApartmentBeds(apartmentService);
                        break;
                    case 8:
                        DeleteApartmentById(apartmentService);
                        break;
                    case 9:
                        AddReservation(reservationService, clientService, apartmentService);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 9.");
                        break;
                }
            }
        }

        static void ListAllApartments(ApartmentService apartmentService)
        {
            var apartments = apartmentService.GetAllApartments();

            Console.WriteLine("Apartments:");
            foreach (var apartment in apartments)
            {
                Console.WriteLine(apartment.ToString());
            }
        }

        static void ListAllClients(ClientService clientService)
        {
            var clients = clientService.GetAllClients();

            Console.WriteLine("Clients:");
            foreach (var client in clients)
            {
                Console.WriteLine(client.ToString());
            }
        }

        static void ListAllLocations(LocationService locationService)
        {
            var locations = locationService.GetAllLocations();

            Console.WriteLine("Locations:");
            foreach (var location in locations)
            {
                Console.WriteLine(location.ToString());
            }
        }

        static void AddApartment(ApartmentService apartmentService)
        {
            Console.Write("Enter the apartment name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the apartment location: ");
            string location = Console.ReadLine();

            Console.Write("Enter the price per night: ");
            decimal pricePerNight = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the number of beds: ");
            int numOfBeds = int.Parse(Console.ReadLine());

            apartmentService.AddApartment(name, location, pricePerNight, numOfBeds);
            Console.WriteLine("Apartment added successfully.");
        }

        static void AddClient(ClientService clientService)
        {
            Console.Write("Enter the client name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the client phone number: ");
            string phoneNumber = Console.ReadLine();

            clientService.AddClient(name, phoneNumber);
            Console.WriteLine("Client added successfully.");
        }

        static void AddLocation(LocationService locationService)
        {
            Console.Write("Enter the location name: ");
            string name = Console.ReadLine();

            locationService.AddLocation(name);
            Console.WriteLine("Location added successfully.");
        }

        static void UpdateApartmentBeds(ApartmentService apartmentService)
        {
            Console.Write("Enter the ID of the apartment to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the new number of beds: ");
            int numOfBeds = int.Parse(Console.ReadLine());

            if (apartmentService.UpdateApartment(id, numOfBeds))
            {
                Console.WriteLine("Apartment beds updated successfully.");
            }
            else
            {
                Console.WriteLine("Apartment not found.");
            }
        }

        static void DeleteApartmentById(ApartmentService apartmentService)
        {
            Console.Write("Enter the ID of the apartment to delete: ");
            int id = int.Parse(Console.ReadLine());

            if (apartmentService.DeleteApartment(id))
            {
                Console.WriteLine("Apartment deleted successfully.");
            }
            else
            {
                Console.WriteLine("Apartment not found.");
            }
        }
        static void AddReservation(ReservationService reservationService, ClientService clientService, ApartmentService apartmentService)
        {
            Console.Write("Enter the start date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
                return;
            }

            Console.Write("Enter the end date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
            {
                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
                return;
            }

            Console.Write("Enter the ID of the apartment: ");
            if (!int.TryParse(Console.ReadLine(), out int apartmentId))
            {
                Console.WriteLine("Invalid apartment ID.");
                return;
            }

            Console.Write("Enter the ID of the client: ");
            if (!int.TryParse(Console.ReadLine(), out int clientId))
            {
                Console.WriteLine("Invalid client ID.");
                return;
            }

            var client = clientService.GetClientById(clientId);
            var apartment = apartmentService.GetApartmentById(apartmentId);

            if (client == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            if (apartment == null)
            {
                Console.WriteLine("Apartment not found.");
                return;
            }

            var reservation = reservationService.AddReservation(startDate, endDate, apartmentId, clientId);
            Console.WriteLine("Reservation added successfully.");
        }


    }
}

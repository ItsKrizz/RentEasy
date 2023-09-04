using RentEasy.Data;
using RentEasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentEasy.Services
{
    public class ApartmentService
    {
        public Apartment GetApartmentById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Apartments.FirstOrDefault(apartment => apartment.Id == id);
            }
        }

        public List<Apartment> GetAllApartments()
        {
            using (var context = new AppDbContext())
            {
                return context.Apartments.ToList();
            }
        }

        public Apartment AddApartment(string name, string location, decimal pricePerNight, int numOfBeds)
        {
            using (var context = new AppDbContext())
            {
                var apartment = new Apartment
                {
                    Name = name,
                    Location = location,
                    PricePerNight = pricePerNight,
                    NumOfBeds = numOfBeds
                };

                context.Apartments.Add(apartment);
                context.SaveChanges();

                return apartment;
            }
        }

        public bool UpdateApartment(int id, int numOfBeds)
        {
            using (var context = new AppDbContext())
            {
                var apartment = context.Apartments.FirstOrDefault(apartment => apartment.Id == id);

                if (apartment == null)
                {
                    return false;
                }

                apartment.NumOfBeds = numOfBeds;
                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteApartment(int id)
        {
            using (var context = new AppDbContext())
            {
                var apartment = context.Apartments.FirstOrDefault(apartment => apartment.Id == id);

                if (apartment == null)
                {
                    return false; 
                }

                context.Apartments.Remove(apartment);
                context.SaveChanges();

                return true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using RentEasy.Models;
using RentEasy.Data;
using System.Linq;

namespace RentEasy.Services
{
    public class LocationService
    {
        private readonly AppDbContext context;

        public Location GetLocationById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Locations.Find(id);
            }
        }

        public List<Location> GetAllLocations()
        {
            using (var context = new AppDbContext())
            {
                return context.Locations.ToList();
            }
        }

        public Location AddLocation(string name)
        {
            using (var context = new AppDbContext())
            {
                var location = new Location(name);
                {
                    context.Locations.Add(location);
                    context.SaveChanges();

                    return location;
                };
            }
        }
    }
}

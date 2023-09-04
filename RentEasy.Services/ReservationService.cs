using RentEasy.Data;
using RentEasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentEasy.Services
{
    public class ReservationService
    {
        private readonly AppDbContext context;

        public Reservation GetReservationById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Reservations.Find(id);
            }
        }
        public List<Reservation> GetAllReservations()
        {
            using (var context = new AppDbContext())
            {
                return context.Reservations.ToList();
            }
        }

        public Reservation AddReservation(DateTime startDate, DateTime endDate, int apartmentId, int clientId)
        {
            using (var context = new AppDbContext())
            {
                var reservation = new Reservation(startDate, endDate, apartmentId, clientId);

                context.Reservations.Add(reservation);
                context.SaveChanges();

                return reservation;
            }
        }

    }
}

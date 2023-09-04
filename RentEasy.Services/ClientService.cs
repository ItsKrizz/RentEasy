using Castle.Core.Resource;
using RentEasy.Data;
using RentEasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentEasy.Services
{
    public class ClientService
    {
        private readonly AppDbContext context;

        public Client GetClientById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Clients.Find(id);
            }
        }
        public List<Client> GetAllClients()
        {
            using (var context = new AppDbContext())
            {
                return context.Clients.ToList();
            }
        }
        public Client AddClient(string name, string phoneNumber)
        {
            using (var context = new AppDbContext())
            {
                var client = new Client()
                {
                    Name = name,
                    PhoneNumber = phoneNumber
                };

                context.Clients.Add(client);
                context.SaveChanges();

                return client;
            }
        }

    }
}
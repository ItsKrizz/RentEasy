
namespace RentEasy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Client
    {

        public Client() { }
        public Client(string name, string phoneNumber) 
        {
            Name= name;
            PhoneNumber= phoneNumber;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Phone number: {PhoneNumber}";
        }
    }
}

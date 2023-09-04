namespace RentEasy.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    public class Location
    {
        public Location(string name)
        {
            Name = name;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }

        public override string ToString()
        {
            return $"Location Name: {Name}";
        }
    }
}

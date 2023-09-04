namespace RentEasy.Models
{
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public decimal PricePerNight { get; set; }
        [Required]
        public int NumOfBeds { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Location: {Location}, NumOfBeds: {NumOfBeds}";
        }
    }
}

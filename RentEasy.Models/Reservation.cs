using Castle.Core.Resource;
using RentEasy.Models;
using System;

public class Reservation
{
    private int apartmentId;

    public Reservation()
    {
    }
    public Reservation(DateTime startDate, DateTime endDate)
    {
        CheckInDate = startDate;
        CheckOutDate = endDate;
    }

    public Reservation(DateTime startDate, DateTime endDate, int apartmentId, int clientId) : this(startDate, endDate)
    {
        this.apartmentId = apartmentId;
        ClientId = clientId;
    }

    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public decimal PricePerNight => Apartment.PricePerNight;

    public int NumOfNights => (int)(CheckOutDate - CheckInDate).TotalDays;
    public decimal TotalPrice => PricePerNight * NumOfNights;
    public int ClientId { get; set; }
    public virtual Apartment Apartment { get; set; }

    public override string ToString()
    {
        return $"CheckInDate: {CheckInDate}, CheckOutDate: {CheckOutDate}, Apartment: {Apartment.Name}, Client Id: {ClientId}";
    }
}

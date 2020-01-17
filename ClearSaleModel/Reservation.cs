using ClearSaleModel;
using System;
using System.Collections.Generic;

namespace RestFulIntegration.Reservation.Models
{
    public class Reservation
    {
        
        public string ID { get; set; }
        
        public DateTime Date { get; set; }        

        public string Email { get; set; }
        
        public decimal TotalValueOriginal { get; set; }
        
        public decimal TotalValue { get; set; }
        
        public string IP { get; set; }

        public string Obs { get; set; }
        
        public string Currency { get; set; }        

        public string Status { get; set; }

        public List<Payment> Payments { get; set; }

        public Person BillingData { get; set; }

        public Person ContactData { get; set; }

        public List<Person> Guests { get; set; }

        public Agency Agency { get; set; }

        public List<Details> Details { get; set; }

        public List<Custom> CustomFields { get; set; }

        public string SessionID { get; set; }
    }

    public class Agency
    {
        public string Name { get; set; }

        public string CorporateName { get; set; }

        public string Nationality { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string IATA { get; set; }

        public string Margin  { get; set; }
    }

    public class LogAccess
    {
        public string UserName { get; set; }

        public string Currency { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastAccess { get; set; }

        public string PasswordHash { get; set; }
    }

    public class Details
    {
        public int ReservationType { get; set; }

        
        public Hotel Hotel { get; set; }

        public string Deadline { get; set; }

        
        public DateTime Checkin { get; set; }
        
        public DateTime Checkout { get; set; }

        public int Rooms { get; set; }

        public string Adult { get; set; }

        public string Children { get; set; }

    }

    public class Hotel {

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

    }
}
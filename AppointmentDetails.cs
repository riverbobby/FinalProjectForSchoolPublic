using System;

namespace JustinTownleyCapstone
{
    public class AppointmentDetails : CreateUpdate
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }
        public string Phone { get; set; }
        public string AreaName { get; set; }
        public string Country { get; set; }
        //constructor for AppointmentDetails
        public AppointmentDetails(int appointmentID, string title, string description, string location, 
            string type, DateTime start, DateTime end, DateTime createDate, string createdBy, 
            DateTime lastUpdate, string lastUpdateBy, string contactName, string contactEmail, 
            string customerName, string address, string postal, string phone, string areaName, string country)
        {
            ID = appointmentID;
            Title = title;
            Description = description;
            Location = location;
            Type = type;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
            ContactName = contactName;
            ContactEmail = contactEmail;
            CustomerName = customerName;
            Address = address;
            Postal = postal;
            Phone = phone;
            AreaName = areaName;
            Country = country;
        }

    }
}

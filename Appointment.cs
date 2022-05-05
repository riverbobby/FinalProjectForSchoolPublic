using System;

namespace JustinTownleyCapstone
{
    public class Appointment : CreateUpdate
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int ContactID { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        //constructor for current appointment
        public Appointment(int appointmentID, string title, string description, string location, string type, 
            DateTime start, DateTime end, DateTime createDate, string createdBy, DateTime lastUpdate, 
            string lastUpdateBy, int customerID, int userID, int contactID)
        {
            ID = appointmentID;
            CustomerID = customerID;
            UserID = userID;
            Title = title;
            Description = description;
            Location = location;
            ContactID = contactID;
            Type = type;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

    }
}

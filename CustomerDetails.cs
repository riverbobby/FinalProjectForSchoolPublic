using System;

namespace JustinTownleyCapstone
{
    public class CustomerDetails : CreateUpdate
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }
        public string Phone { get; set; }
        public string AreaName { get; set; }
        public string Country { get; set; }

        //constructor for CustomerDetails
        public CustomerDetails(string name, string address, string postal, string phone,
            DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy, 
            string areaName, string country)
        {
            Name = name;
            Address = address;
            Postal = postal;
            Phone = phone;
            AreaName = areaName;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
            Country = country;
        }
    }
}

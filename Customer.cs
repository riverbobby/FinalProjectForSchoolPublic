using System;

namespace JustinTownleyCapstone
{
    public class Customer : CreateUpdate 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }
        public string Phone { get; set; }
        public int AreaID { get; set; }

        //constructor for customer
        public Customer(int id, string name, string address, string postal, string phone, 
            DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy, int areaID)
        {
            ID = id;
            Name = name;
            Address = address;
            Postal = postal;
            Phone = phone;
            AreaID = areaID;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
    }
}

using System;

namespace JustinTownleyCapstone
{
    public class Area : CreateUpdate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }

        //constructor for Area
        public Area(int id, string name, DateTime createDate, string createdBy, 
            DateTime updated, string updatedBy, int countryID)
        {
            ID = id;
            Name = name;
            CountryID = countryID;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = updated;
            LastUpdateBy = updatedBy;

        }
    }
}

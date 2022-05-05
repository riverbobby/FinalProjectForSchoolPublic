using System;

namespace JustinTownleyCapstone
{
    public class Country : CreateUpdate 
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //constructor for country
        public Country(int id, string name, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            ID = id;
            Name = name;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
    }
}

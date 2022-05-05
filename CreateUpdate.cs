using System;

namespace JustinTownleyCapstone
{
    public abstract class CreateUpdate : Base
    {
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }
}

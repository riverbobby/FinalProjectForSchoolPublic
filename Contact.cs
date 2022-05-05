namespace JustinTownleyCapstone
{
    public class Contact : Base
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        //constructor for contact
        public Contact(int id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;
        }
    }
}

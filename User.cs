namespace JustinTownleyCapstone
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //constructor for current user
        public User(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}

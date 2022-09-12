namespace Imperfect.Clients
{
    public class ProfileInfo
    {
        public String userName { get; set; }
        public String mail { get; set; }
        //should only be visible for yourself 
        //This one should maybe be continously updated?
        public List<String> followers { get; set; }
        //This one should maybe be continously updated?
        public List<Object> posts { get; set; }

    }
}

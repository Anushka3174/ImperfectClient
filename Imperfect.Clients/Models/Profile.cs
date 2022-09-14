namespace Imperfect.Clients.Models
{
       public class Profile
    {
        public string? Id { get; set; }

        public string? label { get; set; }

        public string? type { get; set; }

        public ProfileProperties? properties { get; set; }
    }
    public class ProfileProperties
    {
        public List<PropertyObject>? FirstName { get; set; }

        public List<PropertyObject>? LastName { get; set; }

        public List<PropertyObject>? Description { get; set; }

        public List<PropertyObject>? ProfilePicture { get; set; }
        public List<PropertyObject>? Profile { get; set; }
    }

    public class PropertyObject 
    {
        public string? Id { get; set;}
        public string? Value { get; set; }
    }
}

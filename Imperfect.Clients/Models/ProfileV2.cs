namespace Imperfect.Clients.Models
{
    public class ProfileV2
    {
        public String? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Object>? ContentPosts { get; set; }

    }
}
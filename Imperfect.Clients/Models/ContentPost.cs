namespace Imperfect.Clients.Models
{
    public class ContentPosts
    {
        public String? Id { get; set; }

        public Object? Photo { get; set; }

        public String? ContentText { get; set; }

        //Maybe use lambda expression in a method here?
        public List<String>? Comments { get;set; }

    }
}
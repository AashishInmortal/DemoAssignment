using System.ComponentModel.DataAnnotations;

namespace Demo22Sep22.Model
{
    public class LocationMdl
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }
}

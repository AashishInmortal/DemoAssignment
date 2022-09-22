using System.ComponentModel.DataAnnotations;

namespace Demo22Sep22.Model
{
    public class JobDetailMdl
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "ClosingDate is required")]
        public DateTime ClosingDate { get; set; }
        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "LocationId is required")]
        public int locationId { get; set; }
    }
}

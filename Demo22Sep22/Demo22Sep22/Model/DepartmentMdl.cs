using System.ComponentModel.DataAnnotations;

namespace Demo22Sep22.Model
{
    public class DepartmentMdl
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
    }
}

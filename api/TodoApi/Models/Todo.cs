using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        public Todo()
        {
            Content = string.Empty;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}

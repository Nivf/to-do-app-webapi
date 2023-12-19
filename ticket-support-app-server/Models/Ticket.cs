using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ticket_support_app_server.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}
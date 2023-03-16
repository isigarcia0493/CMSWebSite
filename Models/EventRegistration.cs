using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSWebsite.Models
{
    public class EventRegistration
    {
        [Key]
        public int Id { get; set; }

        public int RegistrationId { get; set; }
        [ForeignKey("RegistrationId")]
        public Registration Registration { get; set; }

        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}

using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSWebsite.Models
{
    public class FormMessage
    {
        [Key]
        public int FormMessageId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfMessage { get; set; }

        [Required(ErrorMessage = "Please type your subject")]
        [MaxLength(50)]
        [DisplayName("Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please type your message")]
        [DisplayName("Message")]
        public string Body { get; set; }

        //Relationships
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}

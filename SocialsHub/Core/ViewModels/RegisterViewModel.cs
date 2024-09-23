using System.ComponentModel.DataAnnotations;

namespace SocialsHub.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]     
        public string Content { get; set; }
    }
}

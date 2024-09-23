using System.ComponentModel.DataAnnotations;

namespace SocialsHub.Core.Models.Domains
{
    public class Link
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        public bool? IsActive { get; set; }

        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }
    }
}

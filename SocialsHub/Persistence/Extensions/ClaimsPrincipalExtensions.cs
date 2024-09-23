using System.Security.Claims;

namespace SocialsHub.Persistence.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsetId(this ClaimsPrincipal model)
        {
            return model.FindFirstValue(ClaimTypes.NameIdentifier);
        }

      

    }
}

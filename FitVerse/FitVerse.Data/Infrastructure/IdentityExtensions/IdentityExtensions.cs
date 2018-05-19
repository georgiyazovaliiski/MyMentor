using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Data.Infrastructure.IdentityExtensions
{
    public static class IdentityExtensions
    {
        public static string GetSocPriority(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("socPriority");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetFitPriority(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("fitPriority");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetEduPriority(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("eduPriority");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}

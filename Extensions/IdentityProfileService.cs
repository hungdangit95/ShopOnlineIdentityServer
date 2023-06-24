using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using ShopOnline.IDP.Common;
using ShopOnline.IDP.Entities;
using System.Security.Claims;

namespace ShopOnline.IDP.Extensions
{
    public class IdentityProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<User> _claimFactory;
        private readonly UserManager<User> _userManager;

        public IdentityProfileService(IUserClaimsPrincipalFactory<User> claimFactory, UserManager<User> userManager)
        {
            _claimFactory = claimFactory;
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(subjectId);
            if (user == null)
            {
                throw new ArgumentNullException("User Id not found");
            }

            var principal = await _claimFactory.CreateAsync(user);
            var claims = principal.Claims.ToList();
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(new List<Claim>
            {
                   new Claim(SystemConstants.Claims.FirstName, user.FirstName),
                    new Claim(SystemConstants.Claims.LastName , user.LastName),
                    new Claim(SystemConstants.Claims.Roles, String.Join(";", roles)),
                    new Claim(JwtClaimTypes.Address, user.Address),
                    new Claim(JwtClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(SystemConstants.Claims.UserName, user.UserName),
                    new Claim(SystemConstants.Claims.UserId, user.Id),
                     new Claim(ClaimTypes.Name, user.UserName),
            });
            context.IssuedClaims = claims;
        }

        

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subjectId =  context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(subjectId);
            context.IsActive = user != null;
        }
    }
}

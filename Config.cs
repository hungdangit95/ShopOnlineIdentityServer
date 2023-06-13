using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace ShopOnline.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string>
                {
                    "role"
                }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope("shoponline_microservices_api.read","ShopOnline Microservice Api Read Scope"),
                new ApiScope("shoponline_microservices_api.write","ShopOnline Microservice Api Write Scope"),
            };

    public static IEnumerable<ApiResource> ApiResource => new ApiResource[]
    {
        new ApiResource("shoponline_microservices_api", "ShopOnline Microservice Api")
        {
            Scopes = new List<string>{ "shoponline_microservices_api.read", "shoponline_microservices_api.write" },
            UserClaims = new List<string>{"role"}
        }
    };

    public static IEnumerable<Client> Clients =>
        new Client[]
            {
                new()
                {
                    ClientName = "ShopOnline Microservice Client",
                    AccessTokenLifetime = 60*60*2,
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    ClientId = "shoponline_microservice_client",
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:5001/swagger/oauth2-redirect.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:5001/swagger/oauth2-redirect.html"
                    },
                    AllowedCorsOrigins = new List<string>
                    { "http://localhost:5001" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        "shoponline_microservices_api.read",
                        "shoponline_microservices_api.write",
                    }
                },
                new()
                {
                    ClientName = "ShopOnline Microservice Postman",
                    AccessTokenLifetime = 60*60*2,
                    RequireConsent = false,
                    AllowedGrantTypes = new []{GrantType.ClientCredentials},
                    ClientId = "shoponline_microservice_postman",
                    RedirectUris = new List<string>
                    {
                        "http://localhost:5001/swagger/oauth2-redirect.html"
                    },
                    Enabled = true,
                    ClientUri = null,
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:5001/swagger/oauth2-redirect.html"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        "shoponline_microservices_api.read",
                        "shoponline_microservices_api.write",
                    },
                    AllowOfflineAccess = true,
                    RequireClientSecret = true,

                    ClientSecrets =  new[]
                    {
                        new Secret("SuperStrongSecret".Sha512())
                    }
                }
            };
}
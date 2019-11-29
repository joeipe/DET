using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DET.IDP
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "Joe",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Joe"),
                        new Claim("family_name", "Ipe"),
                        //new Claim("address", "187 George st"),
                        //new Claim("role", "Admin"),
                        //new Claim("subscriptionlevel", "Admin"),
                        //new Claim("country", "au")
                    }
                },
                new TestUser
                {
                    SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "Josie",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Josie"),
                        new Claim("family_name", "Riseley"),
                        //new Claim("address", "Big Street 2"),
                        //new Claim("role", "User"),
                        //new Claim("subscriptionlevel", "User"),
                        //new Claim("country", "au")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                     new List<string>() { "role" }),
                new IdentityResource(
                    "country",
                    "The country you're living in",
                    new List<string>() { "country" }),
                new IdentityResource(
                    "subscriptionlevel",
                    "Your subscription level",
                    new List<string>() { "subscriptionlevel" })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "DET",
                    ClientId = "DETWeb_ClientId",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:44326/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:44326/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                    },
                    ClientSecrets =
                    {
                        new Secret("secretfordet".Sha256())
                    }
                }
            };
        }
    }
}

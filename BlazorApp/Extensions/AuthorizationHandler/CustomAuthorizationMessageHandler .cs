using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorApp.Extensions.AuthorizationHandler
{
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigation)
                : base(provider, navigation)
        {
            ConfigureHandler(
                    authorizedUrls: new[] { "https://localhost:5001" }
                );
        }
    }
}
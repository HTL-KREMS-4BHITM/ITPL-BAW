using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal? _currentUser;

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Return the current user or an unauthenticated state
        return Task.FromResult(new AuthenticationState(_currentUser ?? new ClaimsPrincipal(new ClaimsIdentity())));
    }

    public void SetUser(ClaimsPrincipal user)
    {
        _currentUser = user;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }


    public void ClearUser()
    {
        _currentUser = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
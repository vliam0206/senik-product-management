using Application.IServices;
using System.Security.Claims;

namespace SenikWebApi;

public class ClaimService : IClaimService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetCurrentUserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor
                                .HttpContext?
                                .User?
                                .FindFirstValue(ClaimTypes.SerialNumber);

            return string.IsNullOrEmpty(userIdClaim) ? -1 : int.Parse(userIdClaim);
        }
    }

    public string GetCurrentUserName
    {
        get
        {
            var userNameClaim = _httpContextAccessor
                                    .HttpContext?
                                    .User?
                                    .FindFirstValue(ClaimTypes.NameIdentifier);
            return string.IsNullOrEmpty(userNameClaim) ?
                            string.Empty : userNameClaim;
        }
    }
}

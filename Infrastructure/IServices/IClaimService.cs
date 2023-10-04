namespace Infrastructure.IServices;

public interface IClaimService
{
    public int GetCurrentUserId { get; }
    public string GetCurrentUserName { get; }
}

namespace Airways.Shared.Service
{
    public interface IClaimService
    {
        string GetUserId();

        string GetClaim(string key);
    }
}

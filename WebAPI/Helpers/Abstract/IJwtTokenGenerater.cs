using System.Security.Claims;

namespace WebAPI.Helpers.Abstract
{
    public interface IJwtTokenGenerater
    {
        IJwtTokenGenerater Generate(Claim[] claims, byte[] secretKey, int ExpireTime);
        string WriteToken();
    }
}
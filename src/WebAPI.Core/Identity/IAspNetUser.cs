using System;

namespace WebAPI.Core.Identity
{
    public interface IAspNetUser
    {
        Guid GetUserId();
        bool IsAuthenticated();
    }
}
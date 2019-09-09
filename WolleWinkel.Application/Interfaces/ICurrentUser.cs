using System;
using System.Collections;
using System.Collections.Generic;

namespace WolleWinkel.Application.Interfaces
{
    public interface ICurrentUser
    {
        Guid UserId { get; set; }
        ICollection<string> Roles { get; set; }
        
        bool IsAdmin { get; set; }
        bool IsUser { get; set; }
    }
}
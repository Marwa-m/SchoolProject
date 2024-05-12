﻿using CleanArchitecture.Data.Attributes;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        [Encrypted]
        public string? Code { get; set; }

        [InverseProperty(nameof(UserRefreshToken.User))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}

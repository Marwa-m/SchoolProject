﻿using CleanArchitecture.Data.DTOs;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<string> EditRoleAsync(EditRoleRequest request);

        public Task<bool> IsRoleExist(string roleName);
    }
}

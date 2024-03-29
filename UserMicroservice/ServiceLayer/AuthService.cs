﻿using UserMicroservice.Dal;
using UserMicroservice.SecurityServices;
using System.Threading.Tasks; 

namespace UserMicroservice.ServiceLayer
{
    public class AuthService
    {
        private readonly TokenService _tokenService;
        private readonly PasswordService _passwordService;
        private readonly IUserData _userData;

        public AuthService(TokenService tokenService, PasswordService passwordService, IUserData userData)
        {
            _tokenService = tokenService;
            _passwordService = passwordService;
            _userData = userData;
        }

        public async Task<string> Login(string employeeId, string password) 
        {
            var user = await _userData.GetByEmployeeIdAsync(employeeId); // Brug await for at afvente resultatet
            if (user != null && _passwordService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return _tokenService.GenerateToken(employeeId, user.Role);
            }

            return null; // Eller kast en exception, hvis brugervalideringen fejler
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Activate.InterviewProject.Core.Models.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Activate.InterviewProject.Core.Models
{
    public class AppUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public AppUser(string username, string password, string email, string role, string refreshToken = null, DateTime? refreshTokenExpiryTime = null)
        {
            Username = username;
            Password = password;
            Email = email;
            Role = role;
            RefreshToken = refreshToken;
            RefreshTokenExpiryTime = refreshTokenExpiryTime;
        }
    }
}

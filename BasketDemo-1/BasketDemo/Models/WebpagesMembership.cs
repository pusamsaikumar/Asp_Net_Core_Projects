using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class WebpagesMembership
    {
        public int UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ConfirmationToken { get; set; }
        public bool? IsConfirmed { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public string Password { get; set; } = null!;
        public DateTime? PasswordChangedDate { get; set; }
        public string PasswordSalt { get; set; } = null!;
        public string? PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }
}

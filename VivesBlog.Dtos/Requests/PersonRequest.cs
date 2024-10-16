﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace VivesBlog.Dtos.Requests
{
    public class PersonRequest
    {

        [DisplayName("First name")]
        [Required]
        public required string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        public required string LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}

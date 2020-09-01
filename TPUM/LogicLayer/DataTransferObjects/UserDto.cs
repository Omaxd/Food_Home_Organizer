using System;
using DataLayer.Model;
using System.ComponentModel.DataAnnotations;

namespace LogicLayer.DataTransferObjects
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public Cart Cart { get; set; }
    }
}
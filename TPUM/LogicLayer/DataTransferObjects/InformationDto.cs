using System;
using System.ComponentModel.DataAnnotations;

namespace LogicLayer.DataTransferObjects
{
    public class InformationDto
    {
        public Guid? Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
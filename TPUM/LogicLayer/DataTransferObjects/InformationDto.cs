using System.ComponentModel.DataAnnotations;

namespace LogicLayer.DataTransferObjects
{
    public class InformationDto
    {
        [Required]
        public string Content { get; set; }
    }
}
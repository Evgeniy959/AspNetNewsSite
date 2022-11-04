using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetNewsSite.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill in this field")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill in this field")]
        [MaxLength(255)]
        public string Email { get; set; }
    }
}

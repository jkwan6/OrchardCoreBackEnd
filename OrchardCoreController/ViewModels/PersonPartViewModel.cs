using Microsoft.AspNetCore.Mvc;
using OrchardCoreController.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCoreController.ViewModels
{
    public class PersonPartViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? BirthDateUtc { get; set; }
        [Required]
        public Handedness Handedness { get; set; }  

    }
}

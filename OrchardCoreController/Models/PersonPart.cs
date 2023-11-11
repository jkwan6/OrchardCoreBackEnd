using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCoreController.Models
{
    public class PersonPart : ContentPart
    {
        public string Name { get; set; }
        public DateTime? BirthDateUtc { get; set; }
        public Handedness Handedness { get; set; }
        public TextField Biography { get; set; }
    }

    public enum Handedness
    {
        Right,
        Left
    }
}

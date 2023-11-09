using Microsoft.VisualBasic.FileIO;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomFormModule.Models
{
    public class PersonPart: ContentPart
    {
        public string Name { get; set; }
        public Handedness Handedness { get; set; }
        public DateTime? BirthdayUtc { get; set; }
        public TextField Biography { get; set; }

    }
    public enum Handedness
    {
        Right,
        Left,
    }
}

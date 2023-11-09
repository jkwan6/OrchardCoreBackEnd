using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFormModule
{
    public class ContactFormPart : ContentPart
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}

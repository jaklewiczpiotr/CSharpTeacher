using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CSharpTeacher.Models
{
    public class GlobalsViewModel
    {
        public string expression { get; set; }
        public object result { get; set; }
    }
}

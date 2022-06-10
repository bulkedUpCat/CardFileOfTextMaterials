using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RequestFeatures
{
    public class TextMaterialParameters : RequestParameters
    {
        public string? SearchTitle { get; set; }
        public string? SearchCategory { get; set; }
    }
}

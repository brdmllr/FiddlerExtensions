using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiddlerExtensions.Exporters.ExtensionMethods
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendDelimiter(this StringBuilder sb, string value, string delimiter)
        {
            return sb.Append(value).Append(delimiter);
        }
    }
}

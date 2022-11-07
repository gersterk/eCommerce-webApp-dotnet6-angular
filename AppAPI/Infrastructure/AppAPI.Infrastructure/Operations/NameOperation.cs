using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Infrastructure.Operations

{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string name)

            => name.Replace("\"", "")
                .Replace("!", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("&", "")
                .Replace("*", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("/", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("_", "")
                .Replace(",", "")
                .Replace("@", "")
                .Replace("$", "")
                .Replace("é", "e")
                .Replace(":", "")
                .Replace(":", "")
                .Replace("¥", "")
                .Replace("€", "")
                .Replace("£", "")
                .Replace("~", "")
                .Replace("`", "")
                .Replace(".", "-")
                .Replace(";", "")
                .Replace("}", "")
                .Replace("{", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("’", "")
                .Replace("€", "")
                .Replace("Ç", "c")
                .Replace("Ğ", "g")
                .Replace("ç", "c")
                .Replace("ğ", "g")
                .Replace("ş", "s")
                .Replace("Ş", "s")
                .Replace("Ü", "u")
                .Replace("ü", "u")
                .Replace("I", "i")
                .Replace("ı", "i")
                .Replace("I", "i")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("¶", "")
                .Replace("|", "");


    }  
} 

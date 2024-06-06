using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Domain.Resources.Tags
{
    public static class Languages
    {
        public const string SK = "sk-SK";
        public const string EN = "en-US";

        public static List<string> GetAllLangCodes()
        {
            return new List<string>
            {
                "en-US",
                "sk-SK"
            };
        }
    }
}

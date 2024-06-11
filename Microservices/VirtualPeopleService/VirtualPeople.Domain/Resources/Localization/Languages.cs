using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Domain.Resources.Localization
{
    public static class Languages
    {
        public const string SK = "sk-SK";
        public const string EN = "en-US";

        public static List<string> GetAll()
        {
            return new List<string>
            {
                SK,
                EN
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Domain.Interfaces
{
    public interface ILanguageService
    {
        public Task<string> GetCurrentLanguageCode();
    }
}

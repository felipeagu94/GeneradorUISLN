using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public interface IGenerate
    {
        Task<String> GenerateHTML();
    }
}

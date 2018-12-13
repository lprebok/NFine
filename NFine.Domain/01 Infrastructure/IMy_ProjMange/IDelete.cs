using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._01_Infrastructure.IMy_ProjMange
{
    public interface IDelete
    {
        int FCancelFlag { get; set; }
        string FCancelPeople { get; set; }
        DateTime? FCancelDate { get; set; }

    }
}

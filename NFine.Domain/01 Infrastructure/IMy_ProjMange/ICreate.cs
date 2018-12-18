using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._01_Infrastructure.IMy_ProjMange
{
    public interface ICreate
    {
        string FID { get; set; }
        string FWritePeople { get; set; }
        DateTime? FWriteDate { get; set; }
        int FCheckFlag { get; set; }
        string FCheckPeople { get; set; }
        DateTime? FCheckDate { get; set; }
        int FCancelFlag { get; set; }
        string FCancelPeople { get; set; }
        DateTime? FCancelDate { get; set; }
    }
}

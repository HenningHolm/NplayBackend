using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPlay.Data.Enitites
{
    public interface IHaveInsertTimestamps
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
    }
}

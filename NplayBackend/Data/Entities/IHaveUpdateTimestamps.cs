using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojal.Data.Enitites
{
    public interface IHaveUpdateTimestamps
    {
        DateTime? ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
}

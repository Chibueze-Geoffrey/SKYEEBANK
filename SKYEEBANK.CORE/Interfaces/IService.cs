using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYEEBANK.Core.Interfaces
{
    public interface IService
    {
      public void Edit(int id);
      public void Delete(int id);
    }
}

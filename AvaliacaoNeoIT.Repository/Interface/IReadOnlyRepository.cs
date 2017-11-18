using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoNeoIT.Repository.Interface
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IList<T> GetAll();
    }
}

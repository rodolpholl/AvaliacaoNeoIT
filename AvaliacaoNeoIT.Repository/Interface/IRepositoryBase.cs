using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoNeoIT.Repository.Interface
{
    public interface IRepositoryBase<T> : IReadOnlyRepository<T> where T : class
    {
        T GetById(long Id);
        IList<T> GetAll();
        void Inserir(T entity);
        void Update(T entity);
    }
}

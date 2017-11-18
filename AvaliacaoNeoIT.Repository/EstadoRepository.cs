using AvaliacaoNeoIT.Domain;
using AvaliacaoNeoIT.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AvaliacaoNeoIT.Repository
{
    public class EstadoRepository : RepositoryBase<Estado>, IReadOnlyRepository<Estado>
    {

        public EstadoRepository(string pConnectionString) : base(pConnectionString) { }
        
        public IList<Estado> GetAll()
        {
            try
            {
                OpenConnection();

                _Command.CommandText = @"select IdEstado, Descricao from Estado order by Descricao";

                using (var dr = _Command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    return DataReaderToList<Estado>(dr);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Estado GetById(int idEstado)
        {
            try
            {
                

                _Command.CommandText = @"select IdEstado, Descricao from Estado where IdEstado = @Id";

                if(_Command.Parameters.Count == 0)
                    _Command.Parameters.Add("@Id", SqlDbType.Int);

                _Command.Parameters["@Id"].Value = idEstado;

                OpenConnection();
                using (var dr = _Command.ExecuteReader(CommandBehavior.CloseConnection))
                    return DataReaderToList<Estado>(dr)[0];
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

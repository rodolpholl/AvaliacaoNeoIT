using AvaliacaoNeoIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using AvaliacaoNeoIT.Repository.Interface;
using System.Data;

namespace AvaliacaoNeoIT.Repository
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IReadOnlyRepository<Fornecedor>
    {

        public FornecedorRepository(string pConnectionString) : base(pConnectionString) { }
        
        public IList<Fornecedor> GetAll()
        {
            try
            {
                OpenConnection();

                _Command.CommandText = @"select IdFornecedor, CNPJ, Nome from Fornecedor";

                using (var dr = _Command.ExecuteReader(CommandBehavior.CloseConnection))
                    return DataReaderToList<Fornecedor>(dr);
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

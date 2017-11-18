using AvaliacaoNeoIT.Domain;
using AvaliacaoNeoIT.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoNeoIT.Repository
{
    public class FornecedorRegiaoRepository : RepositoryBase<FornecedorRegiao>, IRepositoryBase<FornecedorRegiao>
    {
        public FornecedorRegiaoRepository(string pConnectionString) : base(pConnectionString) { }
        
        public IList<FornecedorRegiao> GetAll()
        {
            try
            {
                OpenConnection();

                _Command.CommandText = @"select IdFornecedor, IdRegiao,  IdFornecedorRegiao from FornecedorRegiao";

                using (var dr = _Command.ExecuteReader(CommandBehavior.CloseConnection))
                    return DataReaderToList<FornecedorRegiao>(dr);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FornecedorRegiao GetById(long Id)
        {
            try
            {
                OpenConnection();

                _Command.CommandText = @"select IdFornecedor, IdRegiao,  IdFornecedorRegiao from FornecedorRegiao where IdFornecedorRegiao = @Id";
                _Command.Parameters.Clear();
                _Command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;

                using (var dr = _Command.ExecuteReader(CommandBehavior.CloseConnection))
                    return DataReaderToList<FornecedorRegiao>(dr)[0];


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inserir(FornecedorRegiao entity)
        {
            try
            {
                var strInclusao = @"insert into FornecedorRegiao (IdFornecedor, IdRegiao ) 
                                values ( 
                                @IdFornecedor,
                                @IdRegiao)";

                _Command.CommandText = strInclusao;

                _Command.Parameters.Clear();

                _Command.Parameters.AddWithValue("@IdFornecedor", entity.IdFornecedor);
                _Command.Parameters.AddWithValue("@IdRegiao", entity.IdRegiao);
                
                OpenConnection();
                _Command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public void Update(FornecedorRegiao entity)
        {
            throw new NotImplementedException("Funcionalidade Desabilitada para este repositório");
        }

        public IList<FornecedorRegiao> GetFornecedorRegiaoByFornecedor(Fornecedor fornecedor)
        {
            try
            {
                OpenConnection();

                _Command.CommandText = @"select IdFornecedor, IdRegiao,  IdFornecedorRegiao from FornecedorRegiao where IdFornecedor = @IdFornecedor";
                _Command.Parameters.Clear();
                _Command.Parameters.Add("@IdFornecedor", SqlDbType.BigInt).Value = fornecedor.IdFornecedor ;

                using (var dr = _Command.ExecuteReader(CommandBehavior.CloseConnection))
                    return DataReaderToList<FornecedorRegiao>(dr);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteByFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var strExclusao = @"delete from FornecedorRegiao where IdFornecedor = @IdFornecedor";
                                

                _Command.CommandText = strExclusao;

                _Command.Parameters.Clear();
                _Command.Parameters.Add("@IdFornecedor", SqlDbType.VarChar, 50).Value = fornecedor.IdFornecedor;
          
                OpenConnection();
                _Command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

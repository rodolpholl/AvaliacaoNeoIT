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
    public class RegiaoRepository : RepositoryBase<Regiao>, IRepositoryBase<Regiao>
    {

        public RegiaoRepository(string pConnectionString) : base(pConnectionString) { }
    

        public Regiao GetById(long Id)
        {
            try
            {
                OpenConnection();
                _Command.CommandText = @"select IdRegiao
                                              ,IdEstado
                                              ,Descricao
                                              ,Ativo
                                          from Regiao where IdRegiao = @Id";
                _Command.Parameters.Add("@Id", SqlDbType.BigInt).Value = Id;

                using (var dr = _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    return DataReaderToList<Regiao>(dr)[0];


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Regiao> GetAll()
        {
            try
            {
                OpenConnection();
                _Command.CommandText = @"select IdRegiao
                                              ,IdEstado
                                              ,Descricao
                                              ,Ativo
                                          from Regiao";

                using (var dr = _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    return DataReaderToList<Regiao>(dr);
                

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inserir(Regiao entity)
        {
            try
            {
                var strInclusao = @"insert into regiao (Descricao, IdEstado, Ativo) 
                                values ( 
                                @Descricao,
                                @IdEstado,
                                @Ativo)";

                _Command.CommandText = strInclusao;

                _Command.Parameters.Add("@Descricao", SqlDbType.VarChar, 50).Value = entity.Descricao;
                _Command.Parameters.Add("@IdEstado", SqlDbType.Int).Value = entity.IdEstado;
                _Command.Parameters.Add("@Ativo", SqlDbType.Bit).Value = entity.Ativo;

                OpenConnection();
                _Command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(Regiao entity)
        {
            try { 
                var strAltercao = @"update regiao set 
                                        Descricao = @Descricao,
                                        IdEstado = @IdEstado,
                                        Ativo = @Ativo
                                    where IdRegiao = @IdRegiao";

                _Command.Parameters.Add("@Descricao", SqlDbType.VarChar, 50).Value = entity.Descricao;
                _Command.Parameters.Add("@IdEstado", SqlDbType.Int).Value = entity.IdEstado;
                _Command.Parameters.Add("@Ativo", SqlDbType.Bit).Value = entity.Ativo;
                _Command.Parameters.Add("@IdRegiao", SqlDbType.BigInt).Value = entity.IdRegiao;

                _Command.CommandText = strAltercao;

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

using AvaliacaoNeoIT.Domain;
using AvaliacaoNeoIT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoNeoIT.Services
{
    public class CadastroFornecedorRegiaoService : ServiceBase, IDisposable
    {
        private FornecedorRepository fornecedorRepository;
        private FornecedorRegiaoRepository fornecedorRegiaoRepository;
        private RegiaoRepository regiaoRepository;
        private EstadoRepository estadoRepository;

        public CadastroFornecedorRegiaoService() : base()
        {
            InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            fornecedorRepository = new FornecedorRepository(this._connectionString);
            fornecedorRegiaoRepository = new FornecedorRegiaoRepository(this._connectionString);
            regiaoRepository = new RegiaoRepository(this._connectionString);
            estadoRepository = new EstadoRepository(this._connectionString);
        }

        public IList<Fornecedor> GetListFornecedor()
        {
            try
            {
                return fornecedorRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar retornar a lista de Fornecedores:\nMensagem de Erro: {ex.Message}");
            }
        }

        public IList<Regiao> GetListRegiao()
        {
            try
            {
                return regiaoRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar retornar a lista de Regiões:\nMensagem de Erro: {ex.Message}");
            }
        }

        public Estado GetEstadoById(int idEstado)
        {
            try
            {
                return estadoRepository.GetById(idEstado);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar uma UF pelo Identificador: \nMensagem de Erro: {ex.Message}");
            }
        }

        public IList<Regiao> GetRegiaoByFornecedor(long pIdFornecedor)
        {
            try
            {

              var ListaIdRegiao = fornecedorRegiaoRepository.GetFornecedorRegiaoByFornecedor(new Fornecedor() { IdFornecedor = pIdFornecedor }).Select(x => x.IdRegiao).ToList();

              return regiaoRepository.GetAll().Where(x => ListaIdRegiao.Contains(x.IdRegiao)).ToList();
                

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar retornar a lista de Regiões referentes ao fornecedor selecionado:\nMensagem de Erro: {ex.Message}");
            }
        }

        public void AtualizarFornecedorRegiao(IList<FornecedorRegiao> pListaAtualizacao)
        {
            try
            {
                var Fornecedor = new Fornecedor() { IdFornecedor = pListaAtualizacao.FirstOrDefault().IdFornecedor };
                fornecedorRegiaoRepository.DeleteByFornecedor(Fornecedor);
                
                foreach(var fornecedorRegiao in pListaAtualizacao)
                {
                    fornecedorRegiaoRepository.Inserir(new FornecedorRegiao()
                    {
                        IdFornecedor = fornecedorRegiao.IdFornecedor,
                        IdRegiao = fornecedorRegiao.IdRegiao
                    });
                }


            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar a lista de Regiões relacionadas ao fornecedor selecionado:\nMensagem de Erro: {ex.Message}");
            }
        }

        public void Dispose()
        {
            fornecedorRepository.Dispose();
            fornecedorRegiaoRepository.Dispose();
            regiaoRepository.Dispose();
            estadoRepository.Dispose();
        }
    }
}

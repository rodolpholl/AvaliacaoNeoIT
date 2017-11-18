using AvaliacaoNeoIT.Domain;
using AvaliacaoNeoIT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoNeoIT.Services
{
    public class CadastroRegioesService : ServiceBase,IDisposable
    {
        private EstadoRepository estadoRepository;
        private RegiaoRepository regiaoRepository;

        public CadastroRegioesService() : base()
        {
            InitializeRepositories();
        }
        
        private void InitializeRepositories()
        {
            estadoRepository = new EstadoRepository(this._connectionString);
            regiaoRepository = new RegiaoRepository(this._connectionString);
        }

        public void Dispose()
        {
            estadoRepository.Dispose();
            regiaoRepository.Dispose();
        }

        public IList<Estado> GetListEstado()
        {
            try
            {
                return estadoRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao tentar retornar a lista de Estados:\nMensagem de Erro: {ex.Message}");
            }
        }

        public IList<Regiao> GetListRegiao()
        {
            try
            {
                return regiaoRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao tentar retornar a lista das Regiões:\nMensagem de Erro: {ex.Message}");
            }
        }

        public void InserirNovaRegiao(Regiao regiao)
        {
            try
            {
                regiaoRepository.Inserir(regiao);
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao tentar inserir uma nova região: \nMensagem de Erro: {ex.Message}");
            }
                                
                               
        }

        public void AlterarRegiao(Regiao regiao)
        {
            try
            {

                var regiaoOld = regiaoRepository.GetById(regiao.IdRegiao);
                regiaoOld.IdEstado = regiao.IdEstado;
                regiaoOld.Descricao = regiao.Descricao;

                regiaoRepository.Update(regiaoOld);
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Alterar a região: \nMensagem de Erro: {ex.Message}");
            }
        }

        public void AtivarRegiao(Regiao regiao)
        {
            try
            {

                var regiaoOld = regiaoRepository.GetById(regiao.IdRegiao);
                regiaoOld.Ativo = true;
           
                regiaoRepository.Update(regiaoOld);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Ativar a região: \nMensagem de Erro: {ex.Message}");
            }
        }

        public void InativarRegiao(Regiao regiao)
        {
            try
            {

                var regiaoOld = regiaoRepository.GetById(regiao.IdRegiao);
                regiaoOld.Ativo = false;

                regiaoRepository.Update(regiaoOld);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Inativar a região: \nMensagem de Erro: {ex.Message}");
            }
        }

        public IList<string> ValidarRegiao(Regiao regiao)
        {
            var retorno = new List<string>();

            if (string.IsNullOrWhiteSpace(regiao.Descricao))
                retorno.Add("A Descrição é Obrigatória");

            if ((regiao.IdEstado <= 0))
                retorno.Add("O Estado é Obrigatório");

            return retorno;
        }
    }
}

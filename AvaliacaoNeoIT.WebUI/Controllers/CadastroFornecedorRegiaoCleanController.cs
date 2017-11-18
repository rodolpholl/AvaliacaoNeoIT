using AvaliacaoNeoIT.Domain;
using AvaliacaoNeoIT.Services;
using AvaliacaoNeoIT.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoNeoIT.WebUI.Controllers
{
    public class CadastroFornecedorRegiaoCleanController : Controller
    {
        // GET: CadastroFornecedorRegiaoClean
        public ActionResult Index()
        {
            using (var regiaoFornecedorService = new CadastroFornecedorRegiaoService())
            {

                var listaFornecedor = regiaoFornecedorService.GetListFornecedor();

                var listaComboFornecedor = listaFornecedor.OrderBy(x => x.Nome).Select(x => new SelectListItem()
                {
                    Text = x.Nome,
                    Value = x.IdFornecedor.ToString()
                }).ToList();

                listaComboFornecedor.Insert(0, new SelectListItem()
                {
                    Text = "- Selecione",
                    Value = "0",
                    Selected = true
                });

                ViewData["ListaFornecedor"] = listaComboFornecedor;

                var listaRegioes = regiaoFornecedorService.GetListRegiao();


                var result = listaRegioes.Select(x => new FornecedorRegiaoModel()
                {
                    Regiao = new RegiaoModel()
                    {
                        Estado = new EstadoModel()
                        {
                            Descricao = regiaoFornecedorService.GetEstadoById(x.IdEstado).Descricao
                        },
                        Descricao = x.Descricao,
                        IdRegiao = x.IdRegiao,
                        Ativo = x.Ativo ? "Ativo" : "Inativo"
                    },
                    Selecionado = false,
                    Uf = regiaoFornecedorService.GetEstadoById(x.IdEstado).Descricao
                })
                .OrderBy(x => x.Regiao.Estado.Descricao)
                .ThenBy(x => x.Regiao.Descricao)
                .ToList();


                return View(result);


            }
        }

        [HttpPost]
        public dynamic GetRegioesByFornecedor(long IdFornecedor)
        {

            try
            {

                using (var regiaoFornecedorService = new CadastroFornecedorRegiaoService())
                {

                    var listRegioesFornecedor = regiaoFornecedorService.GetRegiaoByFornecedor(IdFornecedor).Select(x => new
                    {
                        Ativo = x.Ativo ? "Ativo" : "Inativo",
                        IdRegiao = x.IdRegiao
                    }).ToList();


                    return Json(new
                    {
                        error = false,
                        ListRegioes = listRegioesFornecedor
                    });
                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = true,
                    message = ex.Message
                });
            }

        }

        [HttpPost]
        public dynamic AtualizarFornecedorRegiao(long IdFornecedor, IList<long> pListaIdRegiao)
        {
            try
            {

                using (var regiaoFornecedorService = new CadastroFornecedorRegiaoService())
                {

                    var listaAtualizacao = pListaIdRegiao.Select(x => new FornecedorRegiao()
                    {
                        IdRegiao = x,
                        IdFornecedor = IdFornecedor
                    }).ToList();

                    regiaoFornecedorService.AtualizarFornecedorRegiao(listaAtualizacao);

                    return Json(new
                    {
                        error = false
                    });
                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = true,
                    message = ex.Message
                });
            }
        }
    }
}
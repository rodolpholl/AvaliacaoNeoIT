using AvaliacaoNeoIT.Domain;
using AvaliacaoNeoIT.Services;
using AvaliacaoNeoIT.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoNeoIT.WebUI.Controllers
{
    public class CadastroRegioesController : BaseController
    {   
        
        public ActionResult Index()
        {

            try
            {
                
                using (var srvCadastroRegioes = new CadastroRegioesService())
                {

                    var listaEstado = srvCadastroRegioes.GetListEstado();
               

                    var listaComboEstado = listaEstado
                                              .OrderBy(x => x.Descricao)
                                              .Select(x => new SelectListItem()
                                               {
                                                  Text = x.Descricao,
                                                  Value = x.IdEstado.ToString()
                                               }).ToList();

                    listaComboEstado.Insert(0, new SelectListItem()
                    {
                        Text = "- Selecione",
                        Value = "0"
                    });

                    ViewData["ListaEstado"] = listaComboEstado;

                    var listaRegiao = srvCadastroRegioes.GetListRegiao();

                    var retorno = (from r in listaRegiao
                                 join e in listaEstado on r.IdEstado equals e.IdEstado
                                 select new RegiaoModel()
                                 {
                                     Ativo = r.Ativo ? "Ativo" : "Inativo",
                                     Descricao = r.Descricao,
                                     Estado = new EstadoModel()
                                     {
                                         Descricao = e.Descricao,
                                         IdEstado = e.IdEstado
                                     },
                                     IdEstado = e.IdEstado,
                                     IdRegiao = r.IdRegiao
                                 }
                                )
                                .OrderBy(x => x.Estado.Descricao)
                                .ThenBy(x => x.Descricao)
                                .ToList();

                    return View(retorno);

                }

                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
                

        }

     

        // GET: CadastroRegioes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     

        // POST: CadastroRegioes/Create
        [HttpPost]
        public dynamic Create(RegiaoModel regiao)
        {
            try
            {

                using (var serviceCadastroRegiao = new CadastroRegioesService())
                {
                    var regiaoAdd = new Regiao()
                    {
                        Ativo = true,
                        Descricao = regiao.Descricao,
                        IdEstado = regiao.IdEstado

                    };

                    var validacao = serviceCadastroRegiao.ValidarRegiao(regiaoAdd);
                    var stringErro = "";

                    if (!validacao.Any())
                        serviceCadastroRegiao.InserirNovaRegiao(regiaoAdd);
                    else
                    {
                        stringErro = "<ul>";
                        foreach (var erro in validacao)
                        {
                            stringErro += $@"<li>{erro}</li>";
                        }

                        stringErro += "</ul>";
                    }

                    return Json(new
                    {
                        error = validacao.Any(),
                        message = stringErro
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
        public dynamic Edit(RegiaoModel regiao)
        {
            try
            {

                using (var serviceCadastroRegiao = new CadastroRegioesService())
                {
                    var regiaoAlt = new Regiao()
                    {
                        Ativo = true,
                        Descricao = regiao.Descricao,
                        IdEstado = regiao.IdEstado,
                        IdRegiao = regiao.IdRegiao

                    };
                    var validacao = serviceCadastroRegiao.ValidarRegiao(regiaoAlt);
                    var stringErro = "";

                    if (!validacao.Any())
                        serviceCadastroRegiao.AlterarRegiao(regiaoAlt);
                    else
                    {
                        stringErro = "<ul>";
                        foreach (var erro in validacao)
                        {
                            stringErro += $@"<li>{erro}</li>";
                        }

                        stringErro += "</ul>";
                    }


                    return Json(new
                    {
                        error = validacao.Any(),
                        message = stringErro
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

      
        [HttpGet]
        public ActionResult Ativar(int id)
        {
            try
            {

                using (var serviceCadastroRegiao = new CadastroRegioesService())
                {

                    serviceCadastroRegiao.AtivarRegiao(new Regiao()
                    {
                        IdRegiao = id
                    });

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Inativar(int id)
        {
            try
            {

                using (var serviceCadastroRegiao = new CadastroRegioesService())
                {

                    serviceCadastroRegiao.InativarRegiao(new Regiao()
                    {
                        IdRegiao = id
                    });

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        


    }
}

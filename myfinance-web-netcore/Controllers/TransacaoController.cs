using System.Diagnostics;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers {
    
    public class TransacaoController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;

        public TransacaoController(ILogger<HomeController> logger, MyFinanceDbContext myFinanceDbContext)
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
        }

        [HttpGet]
        [Route("Transacao/")]
        public IActionResult Index()
        {
                    
            var listaTrasacoesContaModel = new List<TransacaoModel>();
            var listaTrasacoesContas = _myFinanceDbContext.Transacao.Include(f => f.PlanoConta);
            foreach (var transacao in listaTrasacoesContas){
                var transacaoModel = new TransacaoModel(){
                    Id = transacao.Id,
                    Data = transacao.Data,
                    Valor = transacao.Valor,
                    Historico = transacao.Historico,
                    PlanoContaId = transacao.PlanoContaId,
                    ItemPlanoConta = new PlanoContaModel(){
                        Id = transacao.PlanoContaId,
                        Descricao = transacao.PlanoConta.Descricao,
                        Tipo =  transacao.PlanoConta.Tipo
                    }
                };
                listaTrasacoesContaModel.Add(transacaoModel);
            }

            ViewBag.ListaTransacao = listaTrasacoesContaModel;

            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
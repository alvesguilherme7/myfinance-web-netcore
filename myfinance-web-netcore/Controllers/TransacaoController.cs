using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers {
    
    [Route("[controller]")]
    public class TransacaoController : Controller
    {

        private readonly ILogger<TransacaoController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;

        public TransacaoController(ILogger<TransacaoController> logger, MyFinanceDbContext myFinanceDbContext)
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

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {

            var transacaoModel = new TransacaoModel();
            
            if(id != null){
                var transacaoDomain = _myFinanceDbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
                if(transacaoDomain != null){
                    transacaoModel.Id = transacaoDomain.Id;
                    transacaoModel.Data = transacaoDomain.Data;
                    transacaoModel.Valor = transacaoDomain.Valor;
                    transacaoModel.Historico = transacaoDomain.Historico;
                    transacaoModel.PlanoContaId = transacaoDomain.PlanoContaId;
                }
            }

            var itensPlanoConta = _myFinanceDbContext.PlanoConta;
            List<SelectListItem> itensPlano = new();
            foreach (var item in itensPlanoConta){
                itensPlano.Add(new SelectListItem() { Text = item.Descricao, Value = item.Id.ToString(),});
            }        
            transacaoModel.PlanoContas = itensPlano;
            return View(transacaoModel);
            
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(TransacaoModel input)
        {

            var transacao = new Transacao() { 
                Id = input.Id,
                Historico = input.Historico,
                Data = input.Data,
                Valor = input.Valor,
                PlanoContaId = input.PlanoContaId
            };

            if(transacao.Id == null){
                _myFinanceDbContext.Transacao.Add(transacao);
            }else{
                _myFinanceDbContext.Transacao.Attach(transacao);
                _myFinanceDbContext.Entry(transacao).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int? id)
        {

            var transacao = _myFinanceDbContext.Transacao.Find(id);
            if(transacao != null){
                _myFinanceDbContext.Transacao.Remove(transacao);
                _myFinanceDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
            
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
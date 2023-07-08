using System.Diagnostics;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers {

    [Route("[controller]")]
    public class PlanoContaController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;

        public PlanoContaController(ILogger<HomeController> logger, MyFinanceDbContext myFinanceDbContext)
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
                    
            var listaPlanoContaModel = new List<PlanoContaModel>();
            var listaPlanoContas = _myFinanceDbContext.PlanoConta;
            foreach (var planoConta in listaPlanoContas){
                var planoContaModel = new PlanoContaModel(){
                    Id = planoConta.Id,
                    Descricao = planoConta.Descricao,
                    Tipo = planoConta.Tipo
                };
                listaPlanoContaModel.Add(planoContaModel);
            }

            ViewBag.ListaPlanoConta = listaPlanoContaModel;

            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
            var planoConta = new PlanoContaModel();

            if(id != null){
                var planoContaDomain = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).FirstOrDefault();
                if(planoContaDomain != null){
                    planoConta.Id = planoContaDomain.Id;
                    planoConta.Descricao = planoContaDomain.Descricao;
                    planoConta.Tipo = planoContaDomain.Tipo;
                }
            }    
            
            return View(planoConta);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel input)
        {
            var planoConta = new PlanoConta(){
                Id = input.Id,
                Descricao = input.Descricao,
                Tipo = input.Tipo
            };

            if(planoConta.Id == null){
                _myFinanceDbContext.PlanoConta.Add(planoConta);
            }else{
                _myFinanceDbContext.PlanoConta.Attach(planoConta);
                _myFinanceDbContext.Entry(planoConta).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
    
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var planoConta = _myFinanceDbContext.PlanoConta.Find(id);
            if(planoConta != null){
                _myFinanceDbContext.PlanoConta.Remove(planoConta);
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

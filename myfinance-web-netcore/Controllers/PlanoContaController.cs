using System.Diagnostics;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers {

    [Route("[controller]")]
    public class PlanoContaController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IObterPlanoContaUseCase _obterPlanoContaUseCase;
        private readonly ICadastrarPlanoContaUseCase _cadastrarPlanoContaUseCase;

        public PlanoContaController(ILogger<HomeController> logger, MyFinanceDbContext myFinanceDbContext,
        IObterPlanoContaUseCase obterPlanoContaUseCase,
        ICadastrarPlanoContaUseCase cadastrarPlanoContaUseCase)
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
            _obterPlanoContaUseCase = obterPlanoContaUseCase;
            _cadastrarPlanoContaUseCase = cadastrarPlanoContaUseCase;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.ListaPlanoConta = _obterPlanoContaUseCase.GetListaPlanoContaModel();
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
            _cadastrarPlanoContaUseCase.CadastrarPlanoContaModel(input);
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

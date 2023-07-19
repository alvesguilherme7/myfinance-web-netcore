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
        private readonly IExcluirPlanoContaUseCase _excluirPlanoContaUseCase;
        private readonly IBuscarPlanoContaUseCase _buscarPlanoContaUseCase;

        public PlanoContaController(ILogger<HomeController> logger, MyFinanceDbContext myFinanceDbContext,
        IObterPlanoContaUseCase obterPlanoContaUseCase,
        ICadastrarPlanoContaUseCase cadastrarPlanoContaUseCase,
        IExcluirPlanoContaUseCase excluirPlanoContaUseCase,
        IBuscarPlanoContaUseCase buscarPlanoContaUseCase)
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
            _obterPlanoContaUseCase = obterPlanoContaUseCase;
            _cadastrarPlanoContaUseCase = cadastrarPlanoContaUseCase;
            _excluirPlanoContaUseCase = excluirPlanoContaUseCase;
            _buscarPlanoContaUseCase = buscarPlanoContaUseCase;
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
            var planoConta = _buscarPlanoContaUseCase.buscarPlanoConta(id);
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
            _excluirPlanoContaUseCase.ExcluirPlanoContaModel(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

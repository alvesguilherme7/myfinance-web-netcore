using System.Diagnostics;   
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers;

public class PlanoContaController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyFinanceDbContext _myFinanceDbContext;

    public PlanoContaController(ILogger<HomeController> logger, MyFinanceDbContext myFinanceDbContext)
    {
        _logger = logger;
        _myFinanceDbContext = myFinanceDbContext;
    }

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

    public IActionResult Cadastro()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

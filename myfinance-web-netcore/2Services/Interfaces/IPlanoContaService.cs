using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services.Interfaces
{
    public interface IPlanoContaService
    {
        List<PlanoContaModel> ListaPlanoContaModel();
        void cadastrarPlanoConta(PlanoContaModel planoContaModel);
        PlanoContaModel buscarPlanoConta(int? Id);
        void excluirPlanoConta(int Id);
    }
}
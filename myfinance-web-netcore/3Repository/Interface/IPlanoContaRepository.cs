using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Repository.Interface
{
    public interface IPlanoContaRepository
    {
        List<PlanoConta> PlanoContas();
        void SalvarPlanoConta(PlanoConta planoConta);

        void ExcluirPlanoConta(PlanoConta planoConta);

        PlanoConta BuscarPlanoConta(PlanoConta planoConta);
    }
}
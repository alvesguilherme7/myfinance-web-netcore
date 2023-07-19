using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Controllers;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Repository.Interface;

namespace myfinance_web_netcore.Repository.Repositories
{
    public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
    {

        public PlanoContaRepository(MyFinanceDbContext myFinanceDbContext) : base(myFinanceDbContext)
        {
        }

        public PlanoConta BuscarPlanoConta(PlanoConta planoConta)
        {
            return base.RetornarRegistro(planoConta.Id);
        }

        public List<PlanoConta> PlanoContas()
        {
            return base.ListarRegistros();
        }

        public void SalvarPlanoConta(PlanoConta planoConta)
        {
            base.Cadastrar(planoConta);
        }

        void IPlanoContaRepository.ExcluirPlanoConta(PlanoConta planoConta)
        {
            if(planoConta.Id != null){
                base.ExcluirRegistro(planoConta.Id);
            }
        }
    }
}
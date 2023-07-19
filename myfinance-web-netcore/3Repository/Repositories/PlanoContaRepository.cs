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
    public class PlanoContaRepository : IPlanoContaRepository
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;

        public PlanoContaRepository(MyFinanceDbContext myFinanceDbContext)
        {
            _myFinanceDbContext = myFinanceDbContext;
        }

        public List<PlanoConta> PlanoContas()
        {
            return _myFinanceDbContext.PlanoConta.ToList<PlanoConta>();
        }

        public void SalvarPlanoConta(PlanoConta planoConta)
        {
            _myFinanceDbContext.PlanoConta.Add(planoConta);
            _myFinanceDbContext.SaveChanges();
            commit();
        }

        public void AtualizarPlanoConta(PlanoConta planoConta)
        {
            _myFinanceDbContext.PlanoConta.Attach(planoConta);
            _myFinanceDbContext.Entry(planoConta).State = EntityState.Modified;
            commit();
        }

        public void commit()
        {
           _myFinanceDbContext.SaveChanges();
        }
    }
}
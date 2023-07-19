using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.ExcluirPlanoContaUseCase
{
    public class ExcluirPlanoContaUseCase : IExcluirPlanoContaUseCase
    {
        private readonly IPlanoContaService _planoContaService;
        public ExcluirPlanoContaUseCase(IPlanoContaService planoContaService){
            _planoContaService = planoContaService;
        }
        
        public void ExcluirPlanoContaModel(int Id)
        {
            _planoContaService.excluirPlanoConta(Id);
        }
    }
}
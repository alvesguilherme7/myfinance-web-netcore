using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.ObterPlanoContaUseCase
{
    public class CadastrarPlanoContaUseCase : ICadastrarPlanoContaUseCase
    {
        private readonly IPlanoContaService _planoContaService;
        public CadastrarPlanoContaUseCase(IPlanoContaService planoContaService){
            _planoContaService = planoContaService;
        }

        public void CadastrarPlanoContaModel(PlanoContaModel input)
        {
            _planoContaService.cadastrarPlanoConta(input);
        }
    }
}
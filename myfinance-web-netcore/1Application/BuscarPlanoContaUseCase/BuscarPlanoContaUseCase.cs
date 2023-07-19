using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.BuscarPlanoContaUseCase
{
    public class BuscarPlanoContaUseCase : IBuscarPlanoContaUseCase
    {
        private readonly IPlanoContaService _planoContaService;
        public BuscarPlanoContaUseCase(IPlanoContaService planoContaService){
            _planoContaService = planoContaService;
        }

        public PlanoContaModel buscarPlanoConta(int? id)
        {
            return _planoContaService.buscarPlanoConta(id);
        }
    }
}

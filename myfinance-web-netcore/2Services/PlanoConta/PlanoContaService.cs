using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Repository.Interface;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Services.PlanoConta
{
    public class PlanoContaService : IPlanoContaService
    {

        private readonly IPlanoContaRepository _planoContaRepository;

        public PlanoContaService(IPlanoContaRepository planoContaRepository){
            _planoContaRepository = planoContaRepository;
        }

        public void cadastrarPlanoConta(PlanoContaModel planoContaModel)
        {
            var planoConta = new Domain.PlanoConta(){
                Id = planoContaModel.Id,
                Descricao = planoContaModel.Descricao,
                Tipo = planoContaModel.Tipo
            };

            if(planoConta.Id == null){
                _planoContaRepository.SalvarPlanoConta(planoConta);
            }else{
                _planoContaRepository.AtualizarPlanoConta(planoConta);
            }
        }

        public List<PlanoContaModel> ListaPlanoContaModel()
        {
            var listaPlanoContaModel = new List<PlanoContaModel>();
            foreach (var planoConta in  _planoContaRepository.PlanoContas()){
                var planoContaModel = new PlanoContaModel(){
                    Id = planoConta.Id,
                    Descricao = planoConta.Descricao,
                    Tipo = planoConta.Tipo
                };
                listaPlanoContaModel.Add(planoContaModel);
            }
            return listaPlanoContaModel;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Repository.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Cadastrar(TEntity Entidade);
        void ExcluirRegistro(int? Id);
        List<TEntity> ListarRegistros();
        TEntity RetornarRegistro(int? Id);
        void commit();
        
    }
}
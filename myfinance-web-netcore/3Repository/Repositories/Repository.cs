using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Repository.Repositories;

namespace myfinance_web_netcore.Repository.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected DbContext Db;
        protected DbSet<TEntity> DbSetContext;

        protected Repository(DbContext dbContext){
            Db = dbContext;
            DbSetContext = Db.Set<TEntity>();
        }


        public void Cadastrar(TEntity Entidade)
        {
            if(Entidade.Id == null){
                DbSetContext.Add(Entidade);
            }else{
                DbSetContext.Attach(Entidade);
                Db.Entry(Entidade).State = EntityState.Modified;
            }
            commit();
        }

        public void ExcluirRegistro(int? Id)
        {
            var entidade = new TEntity(){Id = Id};
            Db.Attach(entidade);
            Db.Remove(entidade);
            commit();
        }

        public List<TEntity> ListarRegistros()
        {
            return DbSetContext.ToList();
        }

        public TEntity RetornarRegistro(int? Id)
        {
            return DbSetContext.Where(x => x.Id == Id).First();
        }

        public void commit()
        {
            Db.SaveChanges();
        }
    }
}
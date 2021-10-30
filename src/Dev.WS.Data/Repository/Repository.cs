﻿using Dev.WS.Business.Interfaces;
using Dev.WS.Business.Models;
using Dev.WS.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dev.WS.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        private readonly DbSet<TEntity> DbSet;

        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {            
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}

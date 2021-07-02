﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Interfaces.Repository;
using talycapglobalPrueba.Infraestructure.Data;

namespace talycapglobalPrueba.Infraestructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
       
        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<List<T>> AddRange(List<T> Listentity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddRangeAsync(Listentity);
            await _dbContext.SaveChangesAsync();
            return Listentity;
        }
        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public IQueryable<T> ListAsync()
        {
            return _dbContext.Set<T>();
        }
        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }
        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
        public async Task UpdateRange(List<T> Listentity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().UpdateRange(Listentity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

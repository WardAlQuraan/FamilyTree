﻿using ENTITIES.BASE_ENTITY;
using SHARED.COMMON_REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.COMMON_SERVICES
{
    public class CommonService<T> : ICommonService<T> where T :BaseEntity
    {
        private readonly ICommonRepo<T> _repo;

        public CommonService(ICommonRepo<T> repo)
        {
            _repo = repo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            return await _repo.InsertAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _repo.UpdateAsync(entity);
        }
    }
}
﻿using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQ.DataAccess.Q
{
    public class StoreQueueDataAccessObject
    {
        //private Context _context;

        public StoreQueueDataAccessObject()
        {
            /*_context = new Context()*/;
        }

        #region C

        public void Create(StoreQueue storeQueue)
        {
            using var _context = new Context();
            _context.StoreQueues.Add(storeQueue);
            _context.SaveChanges();

        }

        public async Task CreateAsync(StoreQueue storeQueue)
        {
            using var _context = new Context();
            await _context.StoreQueues.AddAsync(storeQueue);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region R

        public StoreQueue Read(Guid id)
        {
            using var _context = new Context();
            return _context.StoreQueues.FirstOrDefault(x => x.Id == id);

        }

        public async Task<StoreQueue> ReadAsync(Guid id)
        {
            using var _context = new Context();
            return await
                new Task<StoreQueue>(() => _context.StoreQueues.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(StoreQueue storeQueue)
        {
            using var _context = new Context(); 
            _context.Entry(storeQueue).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Database.CloseConnection();

        }

        public async Task UpdateAsync(StoreQueue storeQueue)
        {
            using var _context = new Context();
            _context.Entry(storeQueue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(StoreQueue storeQueue)
        {
            storeQueue.IsDeleted = true;
            Update(storeQueue);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(StoreQueue storeQueue)
        {
            storeQueue.IsDeleted = true;
            await UpdateAsync(storeQueue);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List
        public List<StoreQueue> List()
        {
            using var _context = new Context();
            return _context.Set<StoreQueue>().ToList();
        }
        public async Task<List<StoreQueue>> ListAsync()
        {
            using var _context = new Context();
            return await _context.Set<StoreQueue>().ToListAsync();
        }
        #endregion

    }

}

using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQ.DataAccess.Q
{
    public class QueueDataAccessObject
    {
        private Context _context;

        public QueueDataAccessObject()
        {
            _context = new Context();
        }

        #region C

        public void Create(StoreQueue queue)
        {
            _context.Queues.Add(queue);
            _context.SaveChanges();

        }

        public async Task CreateAsync(StoreQueue queue)
        {
            await _context.Queues.AddAsync(queue);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public StoreQueue Read(Guid id)
        {
            return _context.Queues.FirstOrDefault(x => x.Id == id);

        }

        public async Task<StoreQueue> ReadAsync(Guid id)
        {
            return await
                new Task<StoreQueue>(() => _context.Queues.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(StoreQueue queue)
        {
            _context.Entry(queue).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(StoreQueue queue)
        {
            _context.Entry(queue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(StoreQueue queue)
        {
            queue.IsDeleted = true;
            Update(queue);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(StoreQueue queue)
        {
            queue.IsDeleted = true;
            await UpdateAsync(queue);

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
            return _context.Set<StoreQueue>().ToList();
        }
        public async Task<List<StoreQueue>> ListAsync()
        {
            return await _context.Set<StoreQueue>().ToListAsync();
        }
        #endregion

    }

}

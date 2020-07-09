using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQ.DataAccess.Q
{
    public class ReservedQueueDataAccessObject
    {
        private Context _context;

        public ReservedQueueDataAccessObject()
        {
            _context = new Context();
        }

        #region C

        public void Create(ReservedQueue queue)
        {
            _context.ReservedQueues.Add(queue);
            _context.SaveChanges();

        }

        public async Task CreateAsync(ReservedQueue queue)
        {
            await _context.ReservedQueues.AddAsync(queue);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public ReservedQueue Read(Guid id)
        {
            return _context.ReservedQueues.FirstOrDefault(x => x.Id == id);

        }

        public async Task<ReservedQueue> ReadAsync(Guid id)
        {
            return await
                new Task<ReservedQueue>(() => _context.ReservedQueues.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(ReservedQueue queue)
        {
            _context.Entry(queue).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(ReservedQueue queue)
        {
            _context.Entry(queue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(ReservedQueue queue)
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

        public async Task DeleteAsync(ReservedQueue queue)
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

        public List<ReservedQueue> List()
        {
            return _context.Set<ReservedQueue>().ToList();
        }
        public async Task<List<ReservedQueue>> ListAsync()
        {
            return await _context.Set<ReservedQueue>().ToListAsync();
        }

        #endregion

    }

}

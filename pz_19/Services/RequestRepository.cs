using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_19.Services
{
    public class RequestRepository : IRequestRepository
    {
        private readonly LastBd1Context _context = new LastBd1Context();

        public async Task<Request> AddRequestAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task DeleteRequestAsync(int requestId)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.RequestId == requestId);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Request> GetRequestByIdAsync(int requestId)
        {
            return _context.Requests.FirstOrDefaultAsync(x => x.RequestId == requestId);
        }

        public Task<List<Request>> GetRequestsAsync()
        {
            return _context.Requests.ToListAsync();
        }

        public async Task<Request> UpdateRequestAsync(Request request)
        {
            if (!_context.Requests.Local.Any(x => x.RequestId == request.RequestId))
            {
                _context.Requests.Attach(request);
            }
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return request;
        }
    }
}

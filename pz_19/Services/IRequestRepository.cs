using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_19.Services
{
    public interface IRequestRepository
    {
        Task<List<Request>> GetRequestsAsync();
        Task<Request> GetRequestByIdAsync(int requestId);
        Task<Request> UpdateRequestAsync(Request request);
        Task DeleteRequestAsync(int requestId);
        Task<Request> AddRequestAsync(Request request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelayAnnouncement.Domain.Contracts
{
    public interface ITripEstimateService
    {
        Task<int> GetEstimate();
    }
}

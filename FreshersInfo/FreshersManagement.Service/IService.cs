using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresher;

namespace FreshersManagement.Service
{
    public interface IService
    {
        IEnumerable<FresherDetail> GetAllFreshers();

        int SaveFresher(FresherDetail fresher);

        void DeleteFresher(int id);
    }
}

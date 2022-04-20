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

        FresherDetail GetFresher(int id);

        int SaveFresher(FresherDetail fresher);

        int DeleteFresher(int id);
    }
}

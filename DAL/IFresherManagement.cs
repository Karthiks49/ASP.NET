using Fresher;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    interface IFresherManagement
    { 
        IEnumerable<FresherDetail> GetFreshers();

        int SaveFreshers(FresherDetail fresher);

        int DeleteFresher(int id);
    }
}

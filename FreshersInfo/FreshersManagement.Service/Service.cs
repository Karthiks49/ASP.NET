using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Fresher;

namespace FreshersManagement.Service
{
    public class FresherService : IService
    {
        private Freshermanagement freshermanagement = new Freshermanagement();

        public IEnumerable<FresherDetail> GetAllFreshers()
        {
            List<FresherDetail> freshersList = freshermanagement.GetFreshers().ToList();

            return freshersList;
        }

        public int SaveFresher(FresherDetail fresher)
        {
            return freshermanagement.SaveFreshers(fresher);
        }

        public int DeleteFresher(int id)
        {
            return freshermanagement.DeleteFresher(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS
{
    public class MasterDetailPageCASFlyoutMenuItem
    {
        public MasterDetailPageCASFlyoutMenuItem()
        {
            TargetType = typeof(MasterDetailPageCASFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
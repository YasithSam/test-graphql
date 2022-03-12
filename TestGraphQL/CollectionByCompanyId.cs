using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGraphQL
{
    public class CollectionByCompanyId
    {
        public collectionByCompanyId collectionByCompanyId;

    }
    public class collectionByCompanyId
    {
        public int collectionId { get; set; }
        public int companyId { get; set; }
        public List<DomainResult> Domains { get; set; }
    }
    public class DomainResult
    {
        public string Domain { get; set; }
        public List<string> Ips { get; set; }
    }

}

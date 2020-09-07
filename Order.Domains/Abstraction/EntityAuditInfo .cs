using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.Abstraction
{
    public class EntityAuditInfo
    {
        protected EntityAuditInfo()
        {

        }

        public EntityAuditInfo(OperationLog created)
        {
            Created = created ?? throw new ArgumentNullException(nameof(created));
        }

        public int Id { get; set; }

        public OperationLog Created { get; protected set; }
        public OperationLog Updated { get; set; }
        public OperationLog Deleted { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.Abstraction
{
    public interface IAuditable
    {
        EntityAuditInfo EntityModificationInfo { get; set; }
    }

}

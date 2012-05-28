using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETS.ClientPortal.Core
{
    public class EntityBase<IdT>
    {

        public virtual IdT Id { get; protected set; }
    }
}

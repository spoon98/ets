using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETS.ClientPortal.Core
{
    public class EntityChangeSet : EntityBase<Int32>
    {
        public System.Collections.Generic.List<ETS.ClientPortal.Core.FieldChange> FieldChanges
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ETS.ClientPortal.Core.EntityChangeTypes EntityChangeType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}

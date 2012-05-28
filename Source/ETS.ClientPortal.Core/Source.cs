using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETS.ClientPortal.Core
{
    public class Source : EntityBase<Int32>
    {
        public string SourceName
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int SourceDescription
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<FeedConfig> Feeds
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

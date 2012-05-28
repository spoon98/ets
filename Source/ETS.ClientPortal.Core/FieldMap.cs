using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETS.ClientPortal.Core
{
    public class FieldMap
    {
        private FeedField _feedField;

        public FeedField FeedField
        {
            get { return _feedField; }
            set { _feedField = value; }
        }

        public CommonFormatField Format
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public FieldTransform FieldTransform
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

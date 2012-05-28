using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETS.ClientPortal.Core.Interface.Service
{
    public interface IServiceFactory
    {
        T Create<T>();

        void Release(object service);
    }
}

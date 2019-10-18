using System;
using System.Collections.Generic;
using System.Text;

namespace RestTest.Core.Interfaces
{
    public interface IOutputPort<TResponse>
    {
        void Handle(TResponse response);
    }
}

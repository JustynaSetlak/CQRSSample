using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSSample.Common.Query
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}

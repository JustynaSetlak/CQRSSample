using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSSample.Common.Events
{
    public class BaseEvent: INotification
    {
        public BaseEvent()
        {
            OccuredOn = DateTime.Now;
        }

        public DateTime OccuredOn { get; private set; }
    }
}

using CQRSSample.Common.Events;
using MediatR;
using System;

namespace CQRSSample.Events
{
    public class NewProductAddedEvent: BaseEvent
    {
        public NewProductAddedEvent(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

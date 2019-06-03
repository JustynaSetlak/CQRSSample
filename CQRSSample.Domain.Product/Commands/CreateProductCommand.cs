using CQRSSample.Common.Command;
using System;

namespace CQRSSample.Commands
{
    public class CreateProductCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

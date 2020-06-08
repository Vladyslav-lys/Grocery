using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetTareChangeResponse
    {
        public List<TareChange> TareChanges { get; set; }

        public GetTareChangeResponse(List<TareChange> tareChanges)
        {
            this.TareChanges = tareChanges;
        }
    }
}

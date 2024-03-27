using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Filters.Application.Filters.Commands.UpdateFilter
{
    public class UpdateFilterCommand : IRequest
    {
        public Guid FilterId { get; set; }
       public string ModelFilter { get; set; }
        public double ActiveAreaSectional { get; set; }
        public double TotalAreaSectional { get; set; }
        public double FilterLength { get; set; }
        public double FilterWidth { get; set; }
        public double FilterHeight { get; set; }
        public double FilterWeight { get; set; }
    }
}

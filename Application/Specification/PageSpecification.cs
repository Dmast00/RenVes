using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specification
{
    public class PageSpecification<T> : Specification<T>
    {

        public PageSpecification(int pageSize, int PageNumber)
        {
            Query.Skip((PageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}

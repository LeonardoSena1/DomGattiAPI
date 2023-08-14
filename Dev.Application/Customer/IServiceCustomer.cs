using Dev.Application.Shared.Customer;
using Dev.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Application.Customer
{
    public interface IServiceCustomer
    {
        int Create(CreateModel Model, BaseRequest baseRequest);
    }
}

using APIProduct.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProduct.Services
{
    public interface IHttpClientServiceImplementation
    {
        Task<List<Products>> Execute();
    }
}

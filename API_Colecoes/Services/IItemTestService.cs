using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Colecoes.Models;

namespace API_Colecoes.Services
{
    interface IItemTestService
    {
        IEnumerable<Item> GetItems(PaginacaoItens paginacao);
        Item GetItem(int id);

    }
}

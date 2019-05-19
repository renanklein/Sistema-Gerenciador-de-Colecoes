using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Colecoes.Models;

namespace API_Colecoes.Services
{
    public class ItemServiceFake : IItemTestService
    {

        private readonly List<Item> _itensFake;

        public ItemServiceFake()
        {
            _itensFake = new List<Item>()
            {
                new Item {ItemId = 1,Tipo = "Livro",Nome="Dom Casmurro",Categoria= "Romance",Autor="Machado de Assis"},
                new Item {ItemId = 2,Tipo = "DVD",Nome="Os Vingadores",Categoria= "Ação",Autor="Marvel Studios"},
                new Item {ItemId = 3,Tipo = "CD",Nome="Raça Negra",Categoria= "Pagode",Autor="Raça Negra"}
            };
        }
        public IEnumerable<Item> GetItems(PaginacaoItens paginacao)
        {
            return _itensFake;

        }

        public Item GetItem(int id)
        {
            return _itensFake.Where(i => i.ItemId == id).FirstOrDefault();
        }
    }
}

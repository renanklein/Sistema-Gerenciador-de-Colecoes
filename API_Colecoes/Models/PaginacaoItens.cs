using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Colecoes.Models
{
    public class PaginacaoItens
    {
        public int Pagina { get; set; } = 1;
        public int Itens { get; } = 5;
        public int TotalPaginas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Colecoes.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImgPath { get; set; }
        public string Categoria { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Autor { get; set; }
        public string Nome_emprestado { get; set; }
        public string Contato_emprestado { get; set; }


        
    }
}

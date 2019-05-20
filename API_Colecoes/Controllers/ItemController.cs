using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using API_Colecoes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Colecoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy")]
    public class ItemController : ControllerBase
    {
        private readonly ItemContext _repositorio;  
  
        public ItemController(ItemContext repositorio)
        {
            _repositorio = repositorio;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems([FromQuery] PaginacaoItens paginacao)
        {

            int count = await _repositorio.Items.CountAsync();
            int pagina_atual = paginacao.Pagina;
            int itens_por_pagina = paginacao.Itens;

            int total_paginas = (int) Math.Ceiling(count /(double) itens_por_pagina);

            paginacao.TotalPaginas = total_paginas;

            string pagina_anterior = pagina_atual > 1 ? "Sim" : "Nao";

            string proxima_pagina = pagina_atual < total_paginas ? "Sim" : "Nao";

            var items = await _repositorio.Items.Skip((pagina_atual - 1) * itens_por_pagina).Take(itens_por_pagina).ToListAsync();

            var paginacao_detalhes = new
            {
                anterior = pagina_anterior,
                proximo = proxima_pagina,
                total = total_paginas,
                pagina = pagina_atual
            };

            HttpContext.Response.Headers.Add("paginacao", JsonConvert.SerializeObject(paginacao_detalhes));

            return items;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _repositorio.Items.FindAsync(id);

            if(item  == null)
            {
                return BadRequest();
            }

            return item;
        }
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem([FromForm(Name ="tipo")] string Tipo,[FromForm(Name ="nome")] string Nome, 
            [FromForm(Name ="descricao")] string Descricao,[FromForm(Name = "autor")] string Autor, 
            [FromForm(Name ="categoria")] string Categoria)
        {
            Item item = new Item();
            item.Tipo = Tipo;
            item.Nome = Nome;
            item.Descricao = Descricao;
            item.Autor = Autor;
            item.Categoria = Categoria;
            item.Status = "Disponivel";

            await _repositorio.Items.AddAsync(item);
            await _repositorio.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("emprestar")]
        public async Task<ActionResult<Item>> PutEmprestadoItem([FromQuery(Name ="id")]int id,[FromForm(Name ="rua")] string rua,
            [FromForm(Name ="numero")] string numero,[FromForm(Name ="complemento")] string complemento,
            [FromForm(Name ="estado")] string estado, [FromForm(Name ="cidade")] string cidade,
            [FromForm(Name ="nome")] string nome_emp,[FromForm(Name ="contato")] string contato_emp)
        {
            Item item = await _repositorio.Items.FindAsync(id);

            if (item == null)
            {
                return BadRequest();
            }
            item.Rua = rua;
            item.Numero = Convert.ToInt32(numero);
            item.Complemento = complemento;
            item.Estado = estado;
            item.Cidade = cidade;
            item.Nome_emprestado = nome_emp;
            item.Contato_emprestado = contato_emp;
            item.Status = "Emprestado";

            _repositorio.Entry(item).State = EntityState.Modified;
            await _repositorio.SaveChangesAsync();

            return NoContent();
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> PutItem(int id,Item item)
        {
            _repositorio.Entry(item).State = EntityState.Modified;
            await _repositorio.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItems(int id)
        {
            var item = await _repositorio.Items.FindAsync(id);
            if(item == null)
            {
                return BadRequest();
            }

            _repositorio.Items.Remove(item);
            await _repositorio.SaveChangesAsync();
            return NoContent();
        }
    }
}

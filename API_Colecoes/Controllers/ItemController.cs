using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _repositorio.Items.ToListAsync();
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
            [FromForm(Name ="estado")] string estado, [FromForm(Name ="cidade")] string cidade)
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
            item.Status = "Emprestado";

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

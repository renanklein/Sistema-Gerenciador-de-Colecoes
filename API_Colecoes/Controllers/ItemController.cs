using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using API_Colecoes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Colecoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            [FromForm(Name ="descricao")] string Descricao, [FromForm(Name ="img")] IFormFile Imagem, [FromForm(Name = "autor")] string Autor, 
            [FromForm(Name ="categoria")] string Categoria)
        {
            Item item = new Item();
            item.Tipo = Tipo;
            item.Nome = Nome;
            item.Descricao = Descricao;
            item.Autor = Autor;
            item.Categoria = Categoria;


            // var caminhoFile = Path.Combine(Directory.GetCurrentDirectory(),"../Imagens",Imagem.FileName);
            var CaminhoTemp = Path.GetTempFileName();
            using (var stream = new FileStream(CaminhoTemp,FileMode.Create))
            {
                await Imagem.CopyToAsync(stream);
            }
            item.ImgPath = CaminhoTemp;

            await _repositorio.Items.AddAsync(item);
            await _repositorio.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> PutEmprestadoItem([FromBody] string EmprestimoJson ,int id)
        {
            Item item = await _repositorio.Items.FindAsync(id);

            if(item == null)
            {
                return BadRequest();
            }

            var json = JObject.Parse(EmprestimoJson);
            item.Rua = json.GetValue("rua").ToString();
            item.Numero = Convert.ToInt32(json.GetValue("numero").ToString());
            item.Complemento = json.GetValue("complemento").ToString();
            item.Cidade = json.GetValue("cidade").ToString();
            item.Estado = json.GetValue("estado").ToString();
            item.Nome_emprestado = json.GetValue("nome_emprestado").ToString();
            item.Contato_emprestado = json.GetValue("contato_empretado").ToString();
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

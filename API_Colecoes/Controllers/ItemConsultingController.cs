using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ItemConsultingController : ControllerBase
    {
        private readonly ItemContext _repositorio;
        public ItemConsultingController(ItemContext contexto)
        {
            _repositorio = contexto;
        }
       [HttpGet]
       [Route("name")]
       public async Task<ActionResult<IEnumerable<Item>>> GetItemsByName()
        {
            return await _repositorio.Items.OrderBy(i => i.Nome).ToListAsync();
        }
        [HttpGet]
        [Route("categoria")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsByCategory()
        {
            return await _repositorio.Items.OrderBy(i => i.Categoria).ToListAsync();
        }
        [HttpGet]
        [Route("autor")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsByAutor()
        {
            return await _repositorio.Items.OrderBy(i => i.Autor).ToListAsync();

        }
        [HttpGet]
        [Route("key")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsByKeyword([FromQuery(Name ="palavra")]string chave)
        {
            chave = chave.Replace('+', ' ');
            return await _repositorio.Items.Where(i => i.Tipo.Contains(chave) || i.Nome.Contains(chave) || i.Categoria.Contains(chave) || i.Autor.Contains(chave)).ToListAsync();
        }

        [HttpGet("{status}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsByStatus(string status)
        {
            return await _repositorio.Items.Where(i => i.Status.Contains(status)).OrderBy(i => i.Nome).ToListAsync();
        }
    }
}

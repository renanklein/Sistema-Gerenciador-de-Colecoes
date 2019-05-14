using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Colecoes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Colecoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemConsultingController : ControllerBase
    {
        private readonly ItemContext _repositorio;
        public ItemConsultingController(ItemContext contexto)
        {
            _repositorio = contexto;
        }
       [HttpGet]
       [Route("name")]
       public async Task<ActionResult<IEnumerable<Item>>> GetItemsByName(string ordernacao)
        {
            if(ordernacao == "crescente")
            {
                return await _repositorio.Items.OrderBy(i => i.Nome).ToListAsync();

            }
            else
            {
                return await _repositorio.Items.OrderByDescending(i => i.Nome).ToListAsync();
            }
        }
        [HttpGet]
        [Route("categoria")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsByCategory(string ordenacao)
        {
            if(ordenacao == "crescente")
            {
                return  await _repositorio.Items.OrderBy(i => i.Categoria).ToListAsync();
            }
            else
            {
                return await _repositorio.Items.OrderByDescending(i => i.Categoria).ToListAsync();
            }
        }
        [HttpGet]
        [Route("autor")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsByAutor(string ordenacao)
        {
            if(ordenacao == "crescente")
            {
                return await _repositorio.Items.OrderBy(i => i.Autor).ToListAsync();
            }
            else
            {
                return await _repositorio.Items.OrderByDescending(i => i.Autor).ToListAsync();
            }

        }
        [HttpGet]
        [Route("key")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsByKeyWord(string KeyWord)
        {
            return await _repositorio.Items.Where(i => i.Nome.StartsWith(KeyWord)).OrderBy(i => i.Nome).ToListAsync();
        }
    }
}

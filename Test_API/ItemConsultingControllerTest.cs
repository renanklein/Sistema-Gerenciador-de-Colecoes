using System.Threading.Tasks;
using System.Collections.Generic;
using API_Colecoes.Models;
using API_Colecoes.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test_API
{
    public class ItemConsultingControllerTest
    {
        [Fact]
        public async Task GetItemsByKeyword_ReturnList()
        {
            var optionBuilder = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase("Teste");
            ItemContext contexto = new ItemContext(optionBuilder.Options);
            var controladorConsulting = new ItemConsultingController(contexto);
            //await controladorItem.PostItem("Livro", "seila", "clássico literário", "Alguem", "Drama");


            var resultado = await controladorConsulting.GetItemsByKeyword("Drama");

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Item>>>(resultado);

            Assert.IsType<ActionResult<IEnumerable<Item>>>(actionResult);
            Assert.IsType<List<Item>>(actionResult.Value);

        }

    }
}

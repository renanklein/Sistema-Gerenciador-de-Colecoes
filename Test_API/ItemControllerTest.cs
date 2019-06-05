using System.Threading.Tasks;
using API_Colecoes.Models;
using API_Colecoes.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test_API
{
    public class ItemControllerTest
    {
       
        [Fact]
        public async Task PostItemTest_OK()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase("Teste");
            ItemContext context = new ItemContext(optionsBuilder.Options);
            var controlador = new ItemController(context);

            var resultado = await controlador.PostItem("Livro", "seila", "clássico literário", "Alguem", "Drama");

            var actionResult = Assert.IsType<ActionResult<Item>>(resultado);
            Assert.IsType<ActionResult<Item>>(actionResult);
            Assert.IsType<OkResult>(actionResult.Result);
        }
        [Fact]
        public async Task Put_Emprestado_NoContent()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase("Teste");
            ItemContext context = new ItemContext(optionsBuilder.Options);
            var controlador = new ItemController(context);
            var resultado = await controlador.PutEmprestadoItem(1,"Avenida Rio Brando","302","Andar 32","Rio","Rio","João","219895712424");

            var actionResult = Assert.IsType<ActionResult<Item>>(resultado);
            Assert.IsType<ActionResult<Item>>(actionResult);
            Assert.IsType<NoContentResult>(actionResult.Result);
        }
        [Fact]
        public async Task Put_Emprestado_BadRequest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase("Teste");
            ItemContext context = new ItemContext(optionsBuilder.Options);
            var controlador = new ItemController(context);

            var resultado = await controlador.PutEmprestadoItem(34, "Avenida Rio Brando", "302", "Andar 32", "Rio", "Rio", "João", "219895712424");

            var actionResult = Assert.IsType<ActionResult<Item>>(resultado);
            Assert.IsType<ActionResult<Item>>(actionResult);
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }


    }
}


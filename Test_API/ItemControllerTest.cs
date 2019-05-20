using System.Linq;
using System.Threading.Tasks;
using API_Colecoes.Models;
using API_Colecoes.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Test_API
{
    public class ItemControllerTest
    {
        private ItemContext GetTestSession()
        {
            DbContextOptions<ItemContext> options = new DbContextOptions<ItemContext>();
            ItemContext _contexto = new ItemContext(options);

            return _contexto;
        }
        [Fact]
        public async Task PostItemTest_OK()
        {
            var mock = new Mock<ItemContext>();
            mock.Setup(repo => repo).Returns(GetTestSession());
            var controlador = new ItemController(mock.Object);


            var resultado = await controlador.PostItem("Livro", "seila", "clássico literário", "Alguem", "Drama");

            var ok = Assert.IsType<OkResult>(resultado);
            Assert.IsType<OkResult>(ok);


        }
        [Fact]
        public async Task Put_Emprestado_NoContent()
        {
            var mock = new Mock<ItemContext>();
            mock.Setup(repo => repo).Returns(GetTestSession());
            var controlador = new ItemController(mock.Object);

            var resultado = await controlador.PutEmprestadoItem(13,"Avenida Rio Brando","302","Andar 32","Rio","Rio","João","219895712424");

            var noContent = Assert.IsType<NoContentResult>(resultado);
            Assert.IsType<NoContentResult>(noContent);
        }
    }
}


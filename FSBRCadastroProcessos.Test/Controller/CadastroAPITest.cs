using FSBRCadastroProcessos.API.Application.Interfaces;
using FSBRCadastroProcessos.API.Controllers;
using FSBRCadastroProcessos.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FSBRCadastroProcessos.Tests.Controllers
{
    public class CadastroControllerTests
    {
        private readonly Mock<ICadastroService> _cadastroServiceMock;
        private readonly CadastroController _controller;

        public CadastroControllerTests()
        {
            _cadastroServiceMock = new Mock<ICadastroService>();
            _controller = new CadastroController(_cadastroServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfCadastros()
        {
            // Arrange
            var cadastros = new List<Cadastro> { new Cadastro { Id = 1, NomeProcesso = "Processo 1", NPU = "1111111-11.1111.1.11.1111", DataCadastro = DateTime.Now, UF = "SP", Municipio = "São Paulo" } };
            _cadastroServiceMock.Setup(service => service.GetAll()).ReturnsAsync(cadastros);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Cadastro>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithCadastro()
        {
            // Arrange
            var cadastro = new Cadastro { Id = 1, NomeProcesso = "Processo 1", NPU = "1111111-11.1111.1.11.1111", DataCadastro = DateTime.Now, UF = "SP", Municipio = "São Paulo" };
            _cadastroServiceMock.Setup(service => service.GetById(1)).ReturnsAsync(cadastro);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Cadastro>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenCadastroDoesNotExist()
        {
            // Arrange
            _cadastroServiceMock.Setup(service => service.GetById(1)).ReturnsAsync((Cadastro)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction_WithNewCadastro()
        {
            // Arrange
            var cadastro = new Cadastro { Id = 1, NomeProcesso = "Processo 1", NPU = "1111111-11.1111.1.11.1111", DataCadastro = DateTime.Now, UF = "SP", Municipio = "São Paulo" };
            _cadastroServiceMock.Setup(service => service.Create(cadastro)).ReturnsAsync(cadastro);

            // Act
            var result = await _controller.Create(cadastro);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Cadastro>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenCadastroIsNull()
        {
            // Act
            var result = await _controller.Create(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedCadastro()
        {
            // Arrange
            var cadastro = new Cadastro { Id = 1, NomeProcesso = "Processo Atualizado", NPU = "1111111-11.1111.1.11.1111", DataCadastro = DateTime.Now, UF = "SP", Municipio = "São Paulo" };
            _cadastroServiceMock.Setup(service => service.Update(cadastro)).ReturnsAsync(cadastro);

            // Act
            var result = await _controller.Update(1, cadastro);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Cadastro>(okResult.Value);
            Assert.Equal("Processo Atualizado", returnValue.NomeProcesso);
        }

        [Fact]
        public async Task Update_ReturnsBadRequest_WhenIdsDoNotMatch()
        {
            // Arrange
            var cadastro = new Cadastro { Id = 2, NomeProcesso = "Processo Atualizado", NPU = "1111111-11.1111.1.11.1111", DataCadastro = DateTime.Now, UF = "SP", Municipio = "São Paulo" };

            // Act
            var result = await _controller.Update(1, cadastro);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDeletionIsSuccessful()
        {
            // Arrange
            _cadastroServiceMock.Setup(service => service.Delete(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenCadastroDoesNotExist()
        {
            // Arrange
            _cadastroServiceMock.Setup(service => service.Delete(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
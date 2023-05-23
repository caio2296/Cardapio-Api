using Cardapio.Application.Contratos;
using Cardapio.Application.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardapio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(
            IProdutoService produtoService,
            IWebHostEnvironment hostEnvironment)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produto = await _produtoService.GetAllProdutosAsync();
                if (produto == null) return NoContent();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar os produtos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var produto = await _produtoService.GetProdutoByIdAsync(id);
                if (produto == null) return NoContent();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Produto não encontrada. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoDto model)
        {
            try
            {
                var produto = await _produtoService.AddProduto(model);
                if (produto == null) return NoContent();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar um produto. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProdutoDto model)
        {
            try
            {
                var produto = await _produtoService.UpdateProduto(id, model);
                if (produto == null) return NoContent();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar produto. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pedido = await _produtoService.GetProdutoByIdAsync(id);
                if (pedido == null) return NoContent();

                if (await _produtoService.DeleteProduto(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema ao deletar o produto.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar o produto. Erro: {ex.Message}");
            }
        }
    }
}

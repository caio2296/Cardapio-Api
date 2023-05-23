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
    public class PedidoItemController : ControllerBase
    {
        private readonly IPedidoItemService _pedidoService;

        public PedidoItemController(
            IPedidoItemService pedidoItemService,
            IWebHostEnvironment hostEnvironment)
        {
            _pedidoService = pedidoItemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidoItem = await _pedidoService.GetAllPedidosItensAsync();
                if (pedidoItem == null) return NoContent();

                return Ok(pedidoItem);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar os itens do pedido. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pedidoItem = await _pedidoService.GetPedidoItemByIdAsync(id);
                if (pedidoItem == null) return NoContent();
                return Ok(pedidoItem);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Item do Pedido não encontrada. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PedidoItemDto model)
        {
            try
            {
                var pedidoItem = await _pedidoService.AddPedidoItem(model);
                if (pedidoItem == null) return NoContent();
                return Ok(pedidoItem);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar um item ao pedido. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PedidoItemDto model)
        {
            try
            {
                var pedidoItem = await _pedidoService.UpdatePedidoItem(id, model);
                if (pedidoItem == null) return NoContent();
                return Ok(pedidoItem);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o item do pedido. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pedidoItem = await _pedidoService.GetPedidoItemByIdAsync(id);
                if (pedidoItem == null) return NoContent();

                if (await _pedidoService.DeletePedidoItem(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema ao deletar o item do pedido.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar o item do pedido. Erro: {ex.Message}");
            }
        }
    }
}

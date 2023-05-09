using Cardapio.Application;
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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(
            IPedidoService jobService,
            IWebHostEnvironment hostEnvironment)
        {
            _pedidoService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedido = await _pedidoService.GetAllPedidosAsync();
                if (pedido == null) return NoContent();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar os pedidos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetPedidoByIdAsync(id);
                if (pedido == null) return NoContent();
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Pedido não encontrada. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PedidoDto model)
        {
            try
            {
                var pedido = await _pedidoService.AddPedido( model);
                if (pedido == null) return NoContent();
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar um pedido. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PedidoDto model)
        {
            try
            {
                var pedido = await _pedidoService.UpdatePedido(id, model);
                if (pedido == null) return NoContent();
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar pedido. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetPedidoByIdAsync(id);
                if (pedido == null) return NoContent();

                if (await _pedidoService.DeletePedido(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema ao deletar o pedido.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar o pedido. Erro: {ex.Message}");
            }
        }
    }
}

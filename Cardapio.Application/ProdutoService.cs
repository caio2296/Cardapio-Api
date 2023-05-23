using AutoMapper;
using Cardapio.Application.Contratos;
using Cardapio.Application.Dtos;
using Cardapio.Domain;
using Cardapio.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Application
{
    public class ProdutoService:IProdutoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IProdutoPersist _produtoPersist;
        private readonly IMapper _mapper;
        public ProdutoService(
            IGeralPersist geralPersist,
            IProdutoPersist produtoPersist,
            IMapper mapper)
        {
            _geralPersist = geralPersist;
            _produtoPersist = produtoPersist;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> AddProduto(ProdutoDto model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);
                _geralPersist.Add(produto);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var produtoRetorno = await _produtoPersist.GetProdutoByIdAsync(produto.Id);
                    return _mapper.Map<ProdutoDto>(produtoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduto(int produtoId)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null) throw new Exception("Erro ao excluir o produto. Produto não encontrado!");

                _geralPersist.Delete(produto);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto[]> GetAllProdutosAsync()
        {
            try
            {
                var produto = await _produtoPersist.GetAllProdutosAsync();
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto[]>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> GetProdutoByIdAsync(int produtoId)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> UpdateProduto(int produtoId, ProdutoDto model)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null) return null;

                model.Id = produto.Id;

                _mapper.Map(model, produto);
                _geralPersist.Update(produto);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var produtoRetorno = await _produtoPersist.GetProdutoByIdAsync(produto.Id);
                    return _mapper.Map<ProdutoDto>(produtoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

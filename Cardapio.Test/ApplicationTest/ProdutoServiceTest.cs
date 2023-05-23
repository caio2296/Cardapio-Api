using AutoFixture;
using AutoMapper;
using Cardapio.Application;
using Cardapio.Domain;
using Cardapio.Persistence.Contratos;
using FluentAssertions;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Cardapio.Test
{
    public class ProdutoServiceTest
    {
        private readonly IProdutoPersist _produtoPersist;
        
        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;
        

        private readonly ProdutoService _sproduto;
        

        public ProdutoServiceTest()
        {
            _produtoPersist = Substitute.For<IProdutoPersist>();
            _geralPersist = Substitute.For<IGeralPersist>();
            _mapper = Substitute.For<IMapper>();
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _sproduto = new ProdutoService(_geralPersist, _produtoPersist, _mapper);
            
        }


        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduto()
        {
            //Arrange
            var produtoId = _fixture.Create<int>();
            var produto = _fixture.Create<Produto>();
            //var tag = new Tag() { Id =  tagId, Title = "title", UserId = int, User = new User(){ FullName="name",ImagemURL = "url", UserRoles ="role" } , Jobs = new List<Job>() };
            _produtoPersist.GetProdutoByIdAsync(produtoId).Returns(produto);
            //_tagPersist.GetAllTagsAsync(userId).Returns(tag);
            var produtoService = new ProdutoService(_geralPersist, _produtoPersist, _mapper);

            //Act
            //var result = await tagService.GetTagByIdAsync(userId,tagId);

            var result = await produtoService.GetProdutoByIdAsync(produtoId);


            //Assert
            
            //result.Should().Be(produto);
            result.Id.Should().Be(produto.Id);
            //result.Title.Should().Be(tag.Title);
            //result.UserId.Should().Be(tag.UserId);
            //result.Jobs.Should().BeEmpty(null);
        }
    }
}

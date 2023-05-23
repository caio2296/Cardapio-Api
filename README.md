# Cardapio-Api
Api de Cardapio utilizando a arquitetura Clean
O objetivo dessa api é para estudo e aplicação na pratica de um sistema de cardapio de um restaurante, escolhi usar a arquitetura clean por algumas de suas vantagens como: separação de responsabilidades, organização do código, flexibilidade, facilidade de manutenção entre outras.

# Tecnologias utilizadas
ASP.NET Core 5.0
Microsoft.EntityFrameworkCore.InMemory 5.0.8
Microsoft.EntityFrameworkCore.SqlServer 5.0.8
Microsoft.EntityFrameworkCore.Design 5.0.8
Swagger
SQL Server
Pré-requisitos
Visual Studio 2019 ou superior .NET 5.0 SDK SQL Server

# Executando a API
1. Clone o repositório:
git clone [https://github.com/caio2296/Cardapio-Api.git]
2. Abra o projeto no Visual Studio

3. Configurando o banco de dados com 2 opções

3.1 Usando o banco em memória:
basta descomentar o código

services.AddDbContext<CardapioContext>(options => options.UseInMemoryDatabase("CardapioDb"));
e comentar o código

 //services.AddDbContext<CardapioContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
3.2 Usando o banco do sql Server
Abra o arquivo appsettings.Development.json e configure a string de conexão com o banco de dados. Exemplo:

"ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CardapioDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
 }

4. Use alguma ferramenta como o Postman ou o Swagger para testar os endpoints.

Alguns dos Endpoints disponíveis GET /api/produto - Retorna todas os produtos. POST /api/produto - Cria uma nova categoria. GET /api/pedidoItem - Retorna todos os ppedidos itens. POST /api/pedidoItem - Cria um novo produto item.

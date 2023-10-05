# Projeto Prático de Desenvolvimento de Software Visual

## Justificativa
Demonstrar, por meio da condução de um projeto prático, as habilidades e competências adquiridas no decorrer da disciplina. Neste trabalho, os alunos serão desafiados a criar uma aplicação web completa. O back-end será uma Web API em C#, com acesso a dados persistidos em SQLite e manipulados por meio do Entity Framework (EF). O front-end será desenvolvido em Angular.
## Objetivo Geral
O objetivo é desenvolver operações CRUD (Create, Read, Update, Delete) para diferentes entidades de dados e implementar regras de negócio específicas. O trabalho será realizado em equipes de, no mínimo três integrantes humanos, com o Chat GPT atuando como um membro extra para auxiliar no desenvolvimento dos CRUDs básicos.

## Tema
### Sistema de Clientes e Prestadores de Serviços

#### Requisitos da Aplicação
1. Utilizar alguma ferramenta para compartilhamento do código;
2. O sistema deve conter pelo menos duas entidades/modelos/tabelas para cada integrantes da equipe, ou seja, um CRUD de uma entidade por integrante, sendo que o ChatGPT é considerado um dos integrantes;
3. Todas as entidades devem conter a inserção, remoção, alteração e listagem das informações em banco de dados;
4. Uma das entidades deve ter relacionamento com algo já cadastrado no banco. Exemplo: supondo um sistema de e-commerce, primeiro fazemos o cadastro de uma categoria, para depois cadastrar o produto, fazendo o vínculo com uma categoria já existente;
5. O sistema não poderá apenas ter apenas cadastros básicos, ou seja, a partir dos inputs no sistema, os dados devem ser aproveitados para uma funcionalidade que dê sentido ao aplicativo. Exemplo: após os produtos e usuário cadastrado no sistema, o usuário deve ser capaz de gerar um carrinho de compras, para depois gerar uma venda no sistema;

#### Arquitetura implementada na aplicação

Se baseando um pouco nos princípios do SOLID e do clean architecture tentei fazer o mesmo para esse sistema, onde teriamos para cada entidade da nossa aplicação a seguinte infraestrutura

1 Model -> 1 IModelRepository -> 1 ModelRepository -> 1 Controller

Fazendo com que os controllers não tivessem ligados exclusivamente com a regra de negócio da aplicação e trazendo mais segurança para nossa aplicação e maior capacidade de manutenbilidade.

#### Responsabilidades dos integrantes

###### KEMUEL

[x] - Responsável por estruturar a aplicação e organizar a maneira da implementação da arquitetura a ser seguida no projeto
[x] - Responsável por implementar o Token JWT e o sistema de autenticação na aplicação
[x] - Responsável por criar o CRUD dos clientes e pedidos

###### GUILHERME

[x] - Responsável por criar o CRUD dos Prestadores e CategoriaServicos
[x] - Responsável pela estrutura inicial da estrutura do banco de dados
[x] - Responsável por criar o diagrama UML do sistema
[x] - Idealizador da aplicação junto com a Kawany

###### KAWANY

[x] - Responsável por criar o CRUD dos Servicos e Avaliações
[x] - Responsável pela estrutura inicial da estrutura do banco de dados
[x] - Idealizador da aplicação junto com o Guilherme

#### Diagrama de Classes da aplicação
![image](https://github.com/Kemuel-Batista/projeto_desenvolvimento_software_visual/assets/62821098/fe70c46c-ab60-430c-aa24-36c494d49f01)

#### Diagrama de UML da aplicação
![UML](https://github.com/Kemuel-Batista/projeto_desenvolvimento_software_visual/assets/62821098/b6a8b0d8-03be-4688-9790-ef7aeff1eacf)

#### Controllers

1 - AuthController -> Responsável por fazer a autenticação do cliente e do prestador.
2 - ClienteController -> Responsável pelo CRUD dos clientes que estarão utilizando nossa aplicação.
3 - PrestadoresController -> Responsável pelo CRUD dos prestadores que estarão utilizando nossa aplicação.
4 - CategoriaServicoController -> Responsável pelo CRUD das categorias de serviços de nossa aplicação.
5 - ServicosController -> Responsável pelo CRUD dos serviços de nossa aplicação.
6 - PedidoController -> Responsável pelo CRUD dos pedidos de nossa aplicação.
7 - AvaliacaoController -> Responsável pelo CRUD das avaliações dos prestadores e clientes envolvidos no pedido.

#### Como rodar esse projeto?

Siga os passos abaixo para que esse projeto seja executado

1 - Clone o repositório abaixo e o abra com o Visual Studio ou Visual Studio Code

```
git clone https://github.com/Kemuel-Batista/projeto_desenvolvimento_software_visual.git
```

2 - Crie um novo banco de dados com o POSTGRES e edite o arquivo DB/ConnectionContext

```
optionsBuilder.UseNpgsql(
  "Server=localhost;" +
  "Port=5432;" +
  "Database=database;" +
  "User Id=postgres;" +
  "Password=password;"
);
```

3 - Instale as dependências do projeto

```
dotnet dev-certs https --trust
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.AspNetCore.Authentication.Negotiate
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
dotnet add package Microsoft.IdentityModel.Tokens
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Swashbuckle.AspNetCore
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet tool install --global dotnet-ef
```

4 - Execute as migrations

```
dotnet ef database update
```

5 - Execute a aplicação

```
dotnet run --launch-profile https
```
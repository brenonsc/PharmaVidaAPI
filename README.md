# PharmaVidaAPI :pill:

Este repositório contém o código-fonte e a documentação para um projeto de criação de uma API RESTful para uma farmácia fictícia. Esta API permite a gestão de produtos farmacêuticos e suas categorias relacionadas. O projeto foi desenvolvido como requisito para conclusão do Bloco 2 do programa de formação da Generation Brasil.

<br>

## Funcionalidades

A API oferece as seguintes funcionalidades:

### Produtos
- **GetAll**: Obter todos os produtos.
- **GetByID**: Obter um produto pelo seu ID.
- **GetByTitulo**: Obter produtos por título.
- **Create**: Criar um novo produto.
- **Update**: Atualizar informações de um produto existente.
- **Delete**: Excluir um produto.

### Categorias
- **GetAll**: Obter todos os produtos.
- **GetByID**: Obter um produto pelo seu ID.
- **GetByTipo**: Obter categorias por tipo.
- **Create**: Criar um novo produto.
- **Update**: Atualizar informações de um produto existente.
- **Delete**: Excluir um produto.

<br>

## Pré-requisitos

Para rodar este projeto em sua máquina, você precisará do seguinte:

- [Visual Studio](https://visualstudio.microsoft.com/) ou outra IDE compatível com ASP.NET.
- [.NET SDK](https://dotnet.microsoft.com/download) instalado.
- Conexão com banco de dados SQL Server 

<br>

## Configuração do Projeto

1. Clone este repositório em sua máquina local usando o comando:

   ```
   git clone https://github.com/brenonsc/PharmaVidaAPI.git
   ```

2. Abra o projeto no Visual Studio ou na sua IDE preferida.

3. Configuração do Banco de Dados:
   - Abra o arquivo `appsettings.json` e atualize a string de conexão com o seu banco de dados SQL Server:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "sua-connection-string-aqui"
   }
   ```

4. Execute o projeto. A API estará disponível no endereço `https://localhost:5000`


<br>

## Uso da API

Você pode usar ferramentas como [Postman](https://www.postman.com/) ou [Insomnial](https://insomnia.rest/) para interagir com a API. Aqui estão alguns exemplos de como usar os endpoints:

### Produtos

- **GET /api/produtos**: Obter todos os produtos.
- **GET /api/produtos/{id}**: Obter um produto por ID.
- **GET /api/produtos/titulo/{titulo}**: Obter produtos por título.
- **POST /api/produtos**: Criar um novo produto (enviar dados no corpo da solicitação).
- **PUT /api/produtos**: Atualizar um produto existente (enviar dados no corpo da solicitação).
- **DELETE /api/produtos/{id}**: Excluir um produto por ID.

### Categorias

- **GET /api/categorias**: Obter todas as categorias.
- **GET /api/categorias/{id}**: Obter uma categoria por ID.
- **GET /api/categorias/tipo/{tipo}**: Obter categorias por tipo.
- **POST /api/categorias**: Criar uma nova categoria (enviar dados no corpo da solicitação).
- **PUT /api/categorias**: Atualizar uma categoria existente (enviar dados no corpo da solicitação).
- **DELETE /api/categorias/{id}**: Excluir uma categoria por ID.

<br>

## Contribuições

Contribuições são bem-vindas! Se você deseja contribuir com melhorias, correções de bugs ou novos recursos, siga os passos usuais de fork, branch e pull request.

<br>

## Autor

Este projeto foi desenvolvido por Breno Henrique como parte do programa de formação da Generation Brasil.

---

Aproveite o uso da API da PharmaVida! Se você tiver alguma dúvida ou precisar de assistência, sinta-se à vontade para abrir uma issue neste repositório.
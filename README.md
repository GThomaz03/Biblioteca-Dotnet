# Biblioteca API

## Descrição

Esta é uma API RESTful para gerenciar uma biblioteca de livros. A API permite criar, ler, atualizar e excluir informações sobre livros e seus autores. Os dados são armazenados em um banco de dados MongoDB Atlas.

## Tecnologias Utilizadas

*   ASP.NET Core 9.0
*   C#
*   MongoDB Atlas
*   Swashbuckle/Swagger (para documentação e testes da API)

## Pré-requisitos

*   .NET SDK 9.0
*   Uma conta no MongoDB Atlas (para hospedar o banco de dados)
*   Visual Studio (ou outro editor de código C#)

## Configuração

1.  **Clone o repositório:**

    ```bash
    git clone <URL_do_seu_repositório>
    cd Biblioteca
    ```

2.  **Configurar o MongoDB Atlas:**

    *   Crie uma conta no [MongoDB Atlas](https://www.mongodb.com/atlas/database).
    *   Crie um novo projeto e um cluster (você pode usar o cluster gratuito).
    *   Configure o acesso à rede para permitir conexões do seu endereço IP.
    *   Crie um usuário de banco de dados com permissões de leitura e escrita.
    *   Obtenha a string de conexão do seu cluster.

3.  **Configurar a string de conexão:**

    *   Abra o arquivo `appsettings.json`.
    *   Substitua os placeholders `<seu_usuario>`, `<sua_senha>` e `<seu_cluster>` na string de conexão `MongoDBSettings:ConnectionString` com os seus dados do MongoDB Atlas.

    ```json
    {
      "MongoDBSettings": {
        "ConnectionString": "mongodb+srv://<seu_usuario>:<sua_senha>@<seu_cluster>.mongodb.net/?retryWrites=true&w=majority",
        "DatabaseName": "LibraryDB"
      },
      // ...
    }
    ```

4.  **Restaurar os pacotes NuGet:**

    *   Se você estiver usando o Visual Studio, ele deve restaurar automaticamente os pacotes NuGet.
    *   Caso contrário, você pode restaurar os pacotes usando o seguinte comando:

        ```bash
        dotnet restore
        ```

## Execução

1.  **Executar a aplicação:**

    *   No Visual Studio, clique no botão "Executar".
    *   Ou, execute o seguinte comando no terminal:

        ```bash
        dotnet run
        ```

2.  **Acessar o Swagger UI:**

    *   Abra o seu navegador e navegue para `http://localhost:<porta>/swagger`, onde `<porta>` é a porta em que a aplicação está sendo executada (geralmente 5000 ou 5001).

## Utilização da API

A API fornece os seguintes endpoints para gerenciar livros:

*   **`GET /api/Livros`**: Retorna uma lista de todos os livros.
*   **`GET /api/Livros/{id}`**: Retorna um livro específico pelo seu ID.
*   **`POST /api/Livros`**: Cria um novo livro. O corpo da requisição deve ser um objeto JSON com as informações do livro:

    ```json
    {
      "Titulo": "Título do Livro",
      "AnoPublicacao": 2025,
      "Autores": [
        {
          "Nome": "Nome do Autor",
          "Nacionalidade": "Nacionalidade do Autor"
        }
        // Adicione mais autores conforme necessário
      ]
    }
    ```

*   **`PUT /api/Livros/{id}`**: Atualiza um livro existente. O corpo da requisição deve ser um objeto JSON com as informações atualizadas do livro.
*   **`DELETE /api/Livros/{id}`**: Exclui um livro pelo seu ID.

## Modelos de Dados

*   **Livro:**

    ```json
    {
      "Id": "string", // ID gerado pelo MongoDB
      "Titulo": "string",
      "AnoPublicacao": int,
      "Autores": [
        {
          "Nome": "string",
          "Nacionalidade": "string"
        }
      ]
    }
    ```

*   **Autor:**

    ```json
    {
      "Nome": "string",
      "Nacionalidade": "string"
    }
    ```

## Notas

*   Esta API usa o MongoDB Atlas como banco de dados.
*   A API está documentada usando o Swagger UI, que pode ser acessado através do endereço `/swagger` da aplicação.
*   Certifique-se de proteger sua string de conexão do MongoDB Atlas e não a compartilhe publicamente.
*   Em um ambiente de produção, considere usar HTTPS e autenticação/autorização para proteger a API.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e enviar pull requests.

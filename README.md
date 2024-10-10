
# FSBR - Cadastros de Processos

Este projeto é um exemplo de um simples CRUD utilizando C#, .NET Core e Entity Framework Core, com uma arquitetura baseada em DDD (Domain-Driven Design). Tambem utiliza-se da API do IBGE para preencher informações sobre UF e municipios na tela de cadastro

## 🛠️ Tecnologias Utilizadas
- **.NET Core 8**: Framework principal para o desenvolvimento da aplicação.
- **Entity Framework Core**: ORM para manipulação do banco de dados.
- **SQL Server**: Banco de dados para armazenar os cursos coletados.
- **xUnit**: Para testes unitários e de integração.
  
## 🎯 Arquitetura
Este projeto foi desenvolvido seguindo os princípios de Domain-Driven Design (DDD) e aplica padrões de Clean Code e SOLID, visando uma estrutura modular, reutilizável e de fácil manutenção. O projeto está dividido em duas principais camadas:
1. **API**
- **Domain**: Contém as entidades e regras de negócio.
- **Application**: Contém os serviços e lógica de aplicação.
- **Infrastructure**: Contém a implementação de repositórios e a integração com o banco de dados e serviços externos.
- **IntegrationTests**: Contém a implementação de testes de integração da aplicação, validando diferentes componentes do sistema
2. **WebAPP**
- **Models**: Contém as modelos que refletem as entidades de persistencia na camada do usuário.
- **Services**: Contém os serviços responsáveis por acionar os endpoits do controlador da API.
- **Pages**: Contém todas as páginas da aplicação WebApp. Ela contém os componentes Razor que compõem a interface do usuário.


### Como Configurar e Rodar o Projeto
1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/xxlucaslima/FSBRCadastroProcessos.git
   cd FSBRCadastroProcessos
   ```

2. **Configure a String de Conexão**
   - Abra o arquivo `appsettings.json` e configure a string de conexão com seu banco de dados SQL Server:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=fsbr_db;User Id=<seuUsuario>;Password=<suaSenha>;"
     }
   }
   ```

3. **Restaurar os Pacotes NuGet**
   Sera necessario restaurar os pacotes nugets antes de inicializar o projeto. Execute este comando no terminal:

   ```bash
   dotnet restore
   ```

4. **Criar e Aplicar Migrações no Banco de Dados**
   Para criar e aplicar as migrações necessárias, execute os seguintes comandos no terminal:
   ```bash
   dotnet ef migrations add InitialMigration -p FSBRCadastroProcessos.API
   dotnet ef database update -p FSBRCadastroProcessos.API
   ```

   > **Nota**: Certifique-se de que o `dotnet-ef` está instalado globalmente:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

5. **Executar o Projeto**
   Para executar o projeto da API (FSBRCadastroProcessos.API) navegue até a pasta do projeto da API, abra um terminal e execute o comando: 
   
     ```bash
      dotnet run --project FSBRCadastroProcessos.API
      ```
   Para executar o projeto da WebApp  (FSBRCadastroProcessos.WebApp ) navegue até a pasta do projeto da API, abra um terminal e execute o comando: 

     ```bash
      dotnet run --project FSBRCadastroProcessos.WebApp
      ```
1. Para rodar todos os testes, execute:
   ```bash
   dotnet test
   ```

5. **Possivel Erro de Building (migration)**

Foi identificado que, ao tentar gerar os arquivos de migration por meio do Package Manager Console dentro do Visual Studio, foi gerado o erro abaixo em algumas ocasiões:

```The specified deps.json [C:\Users\Lucas\Desktop\FSBRCadastroProcessos-master\FSBRCadastroProcessos.WebApp\bin\Debug\net8.0\FSBRCadastroProcessos.WebApp.deps.json] does not exist```

Uma alternativa pra evitar que isso aconteça é, antes de gerar o migration, mudar o StartupProject de FSBRCadastroProcessos.WebApp para FSBRCadastroProcessos.API. Os arquivos de migration devem ser criados normalmente.



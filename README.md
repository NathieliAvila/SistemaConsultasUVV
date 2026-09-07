SISTEMA DE GESTÃO DE CONSULTAS UVV
Aplicação Web desenvolvida em ASP.NET Core MVC para a disciplina de Desenvolvimento Web Back-end, permitindo o cadastro de usuários e o gerenciamento de consultas médicas/profissionais, com persistência via Entity Framework Core e autenticação por cookie.

DESCRIÇÃO
O sistema permite que um usuário crie uma conta, faça login e gerencie suas próprias consultas (criar, listar, editar e excluir). Cada usuário só tem acesso às consultas que ele mesmo cadastrou, com isolamento total entre os dados de diferentes usuários.

TECNOLOGIAS UTILIZADAS
- C# / .NET 10
- ASP.NET Core MVC
- Entity Framework Core 10 (Code First)
- SQL Server (LocalDB)
- Autenticação via Cookies + hash de senha (`PasswordHasher`)

COMO EXECUTAR
1. Clone o repositório e abra o arquivo `.sln` no Visual Studio.
2. Verifique a connection string em `appsettings.json` (já configurada para o LocalDB padrão).
3. No Console do Gerenciador de Pacotes, rode:
```
   Update-Database
```
   Isso cria o banco `SistemaConsultasUVV` com as tabelas necessárias.
4. Pressione F5 para rodar o projeto.
5. Acesse `/Usuarios/Cadastro` para criar uma conta.

FUNCIONALIDADES
- Cadastro e login de usuário 
- Criar, listar, editar e excluir consultas
- Cada usuário só acessa as próprias consultas (rotas protegidas com `[Authorize]`)

VÍDEO DE DEMONSTRAÇÃO
https://www.loom.com/share/e046e690aa994b91ae145ef8ed6f7f2b

Nathieli Avila dos Santos

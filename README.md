W5i - Task Manager
Sistema de controle de atendimentos desenvolvido com ASP.NET Core (Razor Pages), permitindo o gerenciamento de chamados, setores e prioridades, incluindo controle de tempo e status.

Como rodar o projeto localmente

1. Clonar o repositório

No terminal:
-> git clone https://github.com/Thiigot/W5i---Task-Manager.git
-> cd W5i---Task-Manager

Ou utilize a opção de clonar diretamente pelo Visual Studio.

2. Restaurar dependências

Este projeto utiliza .NET, então certifique-se de tê-lo instalado em sua máquina.

No terminal:
-> dotnet restore

3. Configurar conexão com o banco de dados

Abra o arquivo appsettings.json e configure a ConnectionString de acordo com seu ambiente:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=SeuBanco;Username=seu_user;Password=sua_senha"
}

4. Criar o banco de dados

No terminal:

-> psql -U postgres

-> CREATE DATABASE "SeuBanco";

ATENÇÃO: O nome do banco deve ser exatamente o mesmo definido na ConnectionString.

5. Criar as tabelas

O projeto já está configurado para criar automaticamente as tabelas ao iniciar, através do código:

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

Alternativa (manual)

Caso necessário, você também pode aplicar as migrations manualmente:
dotnet tool install --global dotnet-ef
dotnet ef database update

Observações
Certifique-se de que o PostgreSQL está rodando
Verifique se usuário e senha estão corretos no appsettings.json
O banco de dados precisa existir antes de rodar a aplicação

Funcionalidades
Cadastro de setores
Cadastro de prioridades com tempo estimado
Abertura e gerenciamento de chamados
Controle de status (Aberto / Finalizado)
Cálculo de tempo de atendimento
Destaque visual para chamados atrasados

Tecnologias utilizadas
ASP.NET Core (Razor Pages)
Entity Framework Core
PostgreSQL
C#



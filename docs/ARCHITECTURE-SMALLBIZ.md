# Arquitetura - AssetControl.SmallBiz

Visão geral

O projeto segue um estilo modular simples (monolito modular) para facilitar extração de plugins no futuro.

Estrutura principal

- `Modules/<ModuleName>/Models` — entidades EF Core.
- `Modules/<ModuleName>/Dtos` — DTOs para entrada/saída (onde aplicável).
- `Modules/<ModuleName>/Pages` — Razor Pages do módulo.
- `Modules/<ModuleName>/Services` — serviços (interfaces + implementações) que encapsulam o acesso ao `AppDbContext`.
- `AppDbContext` — DbContext central que referencia as entidades dos módulos.

Dependências

- .NET 9, EF Core 9, SQLite (desenvolvimento), Swashbuckle (Swagger).

Padrões adotados

- Injeção de dependência (DI) para serviços por módulo.
- Serviços finos (thin services) que expõem operações básicas (GetAll/GetById/Create/Update/Delete).
- Seed de desenvolvimento para criar um cliente padrão (`Consumidor Final` id=1).

Migrações

Migrations estão sob a pasta `Migrations/` no projeto.

Observações

- Preferi manter `AppDbContext` único para simplicidade no MVP; módulos comunicam-se via serviços.
- Futuro: cada módulo pode ter um projeto separado (plugin) e expor uma interface pública para o host.

# Roadmap - AssetControl.SmallBiz

Fases previstas (prioridade):

1) Boas práticas básicas (agora) — validação e services
   - Adicionar DataAnnotations nas entidades e/ou DTOs.
   - Implementar FluentValidation para regras complexas.
   - Separar DTOs de entrada/saída e mapear com AutoMapper.

2) Testes
   - Unit tests para services (xUnit).
   - Integration tests com TestServer para endpoints e flows (create -> list -> read).

3) Observabilidade e env
   - Logging estruturado e health checks.
   - Configurações por ambiente (appsettings.Development.json).

4) CI/CD e containers
   - `Dockerfile` e workflow GitHub Actions build+push.
   - Regras de proteção de branch (force PR + CI green).

5) Segurança
   - Implementar autenticação JWT e claims.
   - Proteger rotas de escrita (POST/PUT/DELETE) e adicionar roles.

6) Modularização avançada
   - Transformar módulos em projects/plugins, cada um com seu assembly e tests.

Checkpoints e milestones
- Commit atual: modularização + services + pages.
- Próximo checkpoint: validação + DTOs + AutoMapper + novos testes unitários.

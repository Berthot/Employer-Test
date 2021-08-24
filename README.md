# Employer Test

## Desafio Employer 48h para ser desenvolvido
------------------------------------------------------------

Projeto utilizando C#, .NET 5.0, Postgres, EntityFrameworkCore.

```
https://docs.microsoft.com/en-gb/dotnet/core/install/linux
```


O Projeto possui BackEnd independente.

```
Employer.API
Employer.Domain
Employer.Infra
```
O Projeto possui FrontEnd (CLI) independente.

```
Employer.CLI
```
DER criado
![alt text](https://i.imgur.com/TgzGjoe.png)

Antes de rodar em sua maquina lembre-se:

```
Atualizar sua string de conexão do banco de dados;
Realize sua migration 😀 no terminal vá até a pasta Employer.Infra e digite "dotnet ef database update"
Abra o terminar vá a até Employer.API e então execute "dotnet watch run" para deixar sua API ativa.
Para abrir sua CLI, caso não use IDE, abra seu terminal vá até a pasta Employer.CLI e digite "dotnet run".
```

Aluno Regras:
```
  1. Todos os campos são orbigatórios;
  2. O campo nome só poderá receber letras;
  3. O campo sobrenome pode receber qualquer caracter;
  4. O campo data de nascimento não pode ser maior que 01/01/2002;
  5. O campo cpf deverá ser apenas numérico;
  6. O campo curso deverá receber qualquer caracter;
  7. A opção 01 é responsável por voltar ao menu;
  8. A opção 02 é responsável por salvar o registro;
  9. A opção 03 é responsável por excluir o registro;
```

Materias Regras:
```
  1. Todos os campos são orbigatórios;
  2. O campo descricao só poderá receber letras;
  3. O campo data de cadastro não pode ser maior que a data atual;
  4. O campo situação deverá receber ativo ou inativo;
  5. A opção 01 é responsável por voltar ao menu;
  6. A opção 02 é responsável por salvar o registro;
  7. A opção 03 é responsável por excluir o registro;
```

Notas Regras:
```
  1. Todos os campos são orbigatórios;
  2. O campo aluno só poderá receber um aluno cadastrado;
  3. O campo matéria só poderá receber uma matéria cadastrada;
  4. O campo nota deverá receber numéricos de 0 a 100;
  5. A opção 01 é responsável por voltar ao menu;
  6. A opção 02 é responsável por salvar o registro;
  7. A opção 03 é responsável por excluir o registro;
```


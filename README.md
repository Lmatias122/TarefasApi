# 📋 API de Tarefas

API RESTful desenvolvida em **ASP.NET Core** com **Entity Framework Core**, que permite o gerenciamento de tarefas e categorias.  
Cada tarefa pertence a **uma categoria**, e uma categoria pode conter **várias tarefas**.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Swagger (opcional)
- Visual Studio / VS Code

---

## 📁 Estrutura do Projeto

```
📁 Models
   ├── Tarefa.cs
   └── Categoria.cs
📁 Controllers
   ├── TarefaController.cs
   └── CategoriaController.cs
📁 Data
   └── AppDbContext.cs
Program.cs
```

---

## ⚙️ Como Executar o Projeto

1. Clone este repositório:
```bash
git clone https://github.com/seu-usuario/api-tarefas.git
cd api-tarefas
```

2. Restaure os pacotes NuGet:
```bash
dotnet restore
```

3. Execute as migrações e crie o banco de dados:
```bash
dotnet ef database update
```

4. Inicie a aplicação:
```bash
dotnet run
```

A API estará disponível em `https://localhost:5001` ou `http://localhost:5000`.

---

## 📌 Funcionalidades

- ✅ Cadastro, edição e exclusão de tarefas
- ✅ Marcar tarefas como concluídas
- ✅ Atribuir categorias às tarefas
- ✅ Filtrar tarefas por prioridade ou status
- ✅ Visualizar tarefas de uma categoria específica

---

## 🧪 Endpoints Principais

| Método | Rota                        | Ação                        |
|--------|-----------------------------|-----------------------------|
| GET    | `/tarefas`                  | Listar todas as tarefas     |
| GET    | `/tarefas/{id}`             | Buscar uma tarefa por ID    |
| POST   | `/tarefas`                  | Criar nova tarefa           |
| PUT    | `/tarefas/{id}`             | Atualizar uma tarefa        |
| PATCH  | `/tarefas/{id}/concluir`    | Marcar como concluída       |
| DELETE | `/tarefas/{id}`             | Deletar tarefa              |
| GET    | `/categorias`               | Listar categorias           |
| GET    | `/categorias/{id}/tarefas`  | Listar tarefas por categoria|

---

## 📝 Exemplo de JSON para Criar uma Tarefa

```json
{
  "titulo": "Estudar EF Core",
  "descricao": "Finalizar vídeo sobre migrations",
  "concluida": false,
  "prioridade": "Alta",
  "prazo": "2025-08-10",
  "categoriaId": 1
}
```

---

## 📦 Pacotes Utilizados

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Swashbuckle.AspNetCore` *(se usar Swagger)*

---

## 👨‍💻 Autor

Desenvolvido por **Leonardo Matias**  
🔗 [GitHub](https://github.com/Lmatias122) • [LinkedIn](https://www.linkedin.com/in/leonardo-matias122/)

---

## 📄 Licença

Este projeto está licenciado sob a licença MIT.

```
MIT License

Copyright (c) 2025 Leonardo Matias

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

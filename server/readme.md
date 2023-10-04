## Rotas da Aplicação

#### ClienteController

- O ClienteController é responsável por gerenciar os clientes da aplicação.

Endpoints

POST /api/clientes - Adiciona um novo cliente.
PUT /api/clientes - Atualiza um cliente existente.
PATCH /api/cliente - Muda a senha de um cliente existente.
GET /api/clientes - Lista todos os clientes.
DELETE /api/clientes - Remover um cliente existente.

Autenticação
Todos os endpoints, exceto o POST /api/clientes, requerem autenticação. Para se autenticar, é necessário enviar um token JWT no header Authorization.

- Exemplos

Adicionar um novo cliente
```
curl -X POST \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "John Doe",
    "cpf": "12345678900",
    "email": "john.doe@example.com",
    "telefone": "(12) 3456-7890",
    "password": "senha123"
  }' \
  http://localhost:5000/api/clientes
```

Atualizar um cliente existente
```
curl -X PUT \
  -H "Authorization: Bearer <token>" \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Jane Doe",
    "email": "jane.doe@example.com",
    "telefone": "(12) 9876-5432"
  }' \
  http://localhost:5000/api/clientes
```

Mudar a senha de um cliente existente
```
curl -X PATCH \
  -H "Authorization: Bearer <token>" \
  -H "Content-Type: application/json" \
  -d '{
    "password": "novaSenha123"
  }' \
  http://localhost:5000/api/clientes
```

Listar todos os clientes
```
curl -X GET \
  -H "Authorization: Bearer <token>" \
  http://localhost:5000/api/clientes
```
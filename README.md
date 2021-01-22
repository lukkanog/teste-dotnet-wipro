# Locadora API
API para gerencimento básico de locadora.

## Endpoints


### Filmes
Cadastrar Filme: POST /api/filmes
Listar Filmes : GET /api/filmes  

### Clientes
Cadastrar Cliente: POST /api/clientes  

### Locações
Alugar Filme: POST /api/locacoes  
Devolver Filme : PUT /api/locacoes/{idFilme}  
Listar Locacoes: GET /api/locacoes  
Listar locacoes de filme: GET /api/locacoes/{idFilme}  
Listar locacoes de cliente: GET /api/locacoes/{idCliente}  
Buscar locação por id: GET /api/locacoes/{idLocacao}  


# Trabalho de Microcontainers
## Professor José Castillo Lema

### Utilização

```bash
# Listar
curl -X 'GET' \
  'http://127.0.0.1:5000/notas/listar' \
  -H 'accept: application/json'

# Inserir
curl -X 'POST' \
  'http://127.0.0.1:5000/nota/inserir' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "rm": "1234567",
  "nome": "João da Silva",
  "materia": "tecnologia",
  "nota": 8
}'
```

### Alunos
* Igor Vandré Marcelo - RM 340629
* Raphael Rodrigues - RM 340434
* Julia Cafalchio - RM 340982
* Thiago Serrano - RM 341989

# 📦 NCM
O projeto foi desenvolvido para fazer busca de NCM, na tabela em formato JSON fornecida no site da Receita Federal.

---

## 🚀 Tecnologias utilisadas

- .NET (net9.0)
-  Swagger
- Moq
- Xunit

## 📁 Estrutura do Projeto

- `Controllers/` – Endpoints das APIs
- `Models/` – Classes de domínio
- `Services/` – Lógica de negócio

## 🧪 Como Executar o Projeto Localmente

### Clone o repositório
```
git clone https://github.com/mathpss/NCM.git
```
### Navegue até o diretório do projeto
```
cd NCM
```
### Restaure os pacotes
```
dotnet restore
```
### Rode a aplicação
```
dotnet run
```

##🌐 Swagger API

Acesse ``` http://localhost:5084/swagger/index.html ``` para visualizar a documentação interativa da API.

## 📦 Endpoints

GET ``` /api/NCM/{ncm} ``` Para fazer a busca de uma descrição de uma NCM

- Exemplo: ``` /api/NCM/8201.40.00 ``` é preciso passar no formato da NCM: 4 digitos ponto, 2 digitos ponto, 2 digitos ponto. 

GET ``` /api/NCM/Palavra/{texto} ``` Para fazer a busca da NCM baseado em alguma palavra chave do produto

- Exemplo: ``` /api/NCM/Palavra/tesoura ``` sugestão: use substantivos.

GET ``` /api/NCM/4Digitos/{texto} ``` Para fazer a busca de uma descrição de uma NCM baseado nos 4 primeiro digitos

- Exemplo: ``` /api/NCM/4Digitos/8201 ```



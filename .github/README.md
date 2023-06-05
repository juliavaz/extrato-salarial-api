# Api de Extrato Salarial

<p align="center">
  <a href="#about">Sobre o projeto</a> �
  <a href="#packages-tech">Pacotes e tecnologias utilizados no projeto</a> �
  <a href="#installation">Instala��o</a> �
  <a href="#build-exec">Build e Execu��o</a> �
  <a href="#references">Refer�ncias e Links</a> �
  <a href="#author">Autor</a>
</p>


## <a name="about"></a>Sobre o projeto
O projeto consiste em desenvolver uma Web Api respons�vel por criar o extrato da folha salarial dos funcion�rios, incluindo o sal�rio l�quido e os descontos.

## <a name="packages-tech"></a>Pacotes e tecnologias utilizadas no projeto

- Docker
- Github Actions
- Moq (4.18.4)
- XUnit (2.4.2)
- .Net Core (6.0) 
- MongoDB.Driver (2.19.2)
- FluentValidation (11.5.2)
- Swagger - Swashbuckle.AspNetCore (6.2.3)

## <a name="installation"></a>Instala��o

### 1. Clone do projeto

Realize a instala��o do GIT para conseguir executar as pr�ximas etapas de instala��o:

* **[GIT](https://git-scm.com/downloads)**

Ser� necess�rio realizar o clone do reposit�rio para a execu��o em sua m�quina local. Digite o comando abaixo em seu terminal:

```
git clone https://github.com/juliavaz/extrato-salarial-api.git
```

### 2. Download Docker

Realize a instala��o do Docker seguindo a [documenta��o oficial](https://www.docker.com/).


## <a name="build-exec"></a> Build e Execu��o

O comando a seguir ir� inicializar um container docker, no qual � respons�vel por instalar todas as depend�ncias necess�rias, junto a outro container de banco de dados para a utiliza��o da api.

Digite o comando abaixo em seu terminal, dentro do diret�rio `src/`
```
docker compose up -d
```

![comando-docker-compose](docker-compose.png "comando docker-compose via terminal")

Para executar a api, entre na url [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)

Para uma melhor experi�ncia, inicie criando um funcion�rio pelo `POST - api/employees` dessa forma ter� acesso aos outros endpoints.

![web-api](web-api.png "web api em execu��o")

## <a name="references"></a> Refer�ncias e Links

- [Docker Compose](https://docs.docker.com/get-started/02_our_app/)
- [MongoDB Driver](https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#create-a-mongodb-cluster)
- [Fluent Validation](https://docs.fluentvalidation.net/en/latest/index.html#example)
- [Aprimorando a documenta��o com anota��es - I, II ](https://macoratti.net/22/04/swagger_aprdoc1.htm)
- [Al�m do Fact com xUnit](https://medium.com/thiagobarradas/alem-do-fact-com-xunit-dotnet-6a52b69a50d2)
- [Code Coverage Summary - Github Actions](https://github.com/marketplace/actions/code-coverage-summary)
- [An�lise local de cobertura de testes - Extension Fine Code Coverage](https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage2022)

## <a name="author"></a>Autor
<table>
  <tr>
    <td align="center">
        <a href="https://github.com/juliavaz">
            <img src="https://avatars.githubusercontent.com/u/50247060?v=4" width="100px;" alt="" /><br/>
            <sub><b>J�lia Vaz</b></sub>
        </a><br />
    </td>
  </tr>
</table>
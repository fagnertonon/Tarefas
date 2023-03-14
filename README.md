# Tarefas

Projeto para controle de tarefas, utilizando Angular, Api .net 6, Worker Service com comunicação RabbitMq e MSSQL.

## Antes de usar

Para utilizar este projeto você precisar ter conhecimento prêvio em node, angular 2 em diante, C# api e worker service, e também RabbitMQ.

Na máquina onde o projeto será executa você precisa ter as seguintes ferramentas.
* front-end
    * node
    * angular cli
* back end
    * .net6
    * RabbitMq
    * MSSQL (Opcional, haverá uma string de conexão remoto para facilitar os testes)

## Como usar

Para utilizar este projeto você precisa seguir os seguintes passos

* Clonar o projeto localmente
* Para o front-end
    * Entrar na pasta front-end
    * executar o comando
        ```
        npm install
        ng serve
        ```
    * acesar via http://localhost:4200/home 
* Para o back-end Api e Worker Service
    * Abrir o arquivo Tarefas.sln da pasta do backend
    **Importante utilizar VS 2022 para melhor uso do .net6** 

    * Configurar o projeto para **"Multiple startup projects"** e utilizar os projetos (1)Tarefas.API e (2)Tarefas.WS
    * acessar via https://localhost:7202/swagger/index.html
    
    > Para a API será aberto uma página de navegação do swagger para utilizar diretamente os endponts da API
    
    > Para o Worker Service, ele se comunica somente com o RabbitMq, recebendo as mensagens da API tratando e gravando do banco de dados


* Para o banco de dados
    * precisa ter o banco de dados MSSQL SERVER instalado na máquina, após a instação ajustar caso necessário a string de conexão. **a string de conexão deve ser alterada tando para o projeto Tarefas.API e também para o projeto Tarefas.WS**
    
         > Como alternativa para utilização do banco estou deixando um banco de dados remoto provisório para utilização dos testes. Para utilizar basta alterar a connection string no arquivo ***appsettings.Development.json***

```
Para usar o banco de dados remoto trocar de :
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TarefasDb;Trusted_Connection=True;"
  },
 Para (Banco de dados remoto)
   "ConnectionStrings": {
    "DefaultConnection": "Data Source=SQL5102.site4now.net;Initial Catalog=db_a77998_tarefasdb;User Id=db_a77998_tarefasdb_admin;Password=!Tarefa123"
  },
```
> Lembrar de alterar ***appsettings.Development.json*** para os dois projetos ***Tarefas.API*** e ***Tarefas.WS***
    
    


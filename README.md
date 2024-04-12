<h1 align="center">Geek Shopping Microsserviços</h1>
<p align="center"><i>O GeekShopping é um projeto de e-commerce completo, desenvolvido com microsserviços e tecnologias de ponta. Esta documentação visa fornecer uma visão geral da arquitetura do projeto, funcionalidades dos microsserviços e instruções para instalação e configuração.</i></p>

<p align="center">
  <img src="http://img.shields.io/badge/Licença-MIT-green"/>
  <img src="https://img.shields.io/github/languages/top/igormorantos/Ecommercer-microsservicos"/>
  <img src="http://img.shields.io/badge/.NET-8-blue"/>
  <img src="https://img.shields.io/github/last-commit/igormorantos/Ecommercer-microsservicos"/>
  <img src="http://img.shields.io/badge/Status-Em Desenvolvimento-green "/>
  <img src ="https://img.shields.io/github/commit-activity/t/igormorantos/Ecommercer-microsservicos"/>
  <img src="https://img.shields.io/github/languages/count/igormorantos/Ecommercer-microsservicos"/>

</p>

## Objetivo

Criar uma ecommercer utilizando a arquitetura de microserviços, deixando cada função totalmente segregada podendo cada serviço ser deployado individualmente.

## Arquitetura

A arquitetura do GeekShopping é composta por diversos microsserviços interligados, cada um com uma responsabilidade específica. A comunicação entre os serviços é realizada através de APIs RESTful e barramento de mensagens.

### Tecnologias
<p display="inline-block">
  <img width="48" src="https://www.freeiconspng.com/uploads/c-logo-icon-18.png" alt="csharp-logo"/>
  <img width="48" src="https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/16/2019/04/BrandBlazor_nohalo_1000x.png" alt="Blazor-logo"/>
  <img width="48" src="https://avatars.githubusercontent.com/u/67868775?s=200&v=4" alt="IdentityServer-logo"/>
  <img width="48" src="https://api.nuget.org/v3-flatcontainer/ocelot/23.2.2/icon" alt="Ocelot-logo"/>
  <img width="48" src="https://static-00.iconduck.com/assets.00/rabbitmq-icon-484x512-s9lfaapn.png" alt="rabbitMQ-logo"/>
  <img width="48" src="https://e7.pngegg.com/pngimages/924/1009/png-clipart-mysql-relational-database-management-system-logo-php-others-orange-logo-thumbnail.png" alt="MySQL-logo"/>
</p>

## Microsserviços e Funcionalidades

### Frontend:

`GeekShopping.Web`:
- Interface do e-commerce desenvolvida com ASP.NET Core MVC e Razor Pages.
- Consome APIs dos demais microsserviços para apresentar produtos, gerenciar carrinho de compras, realizar pedidos e acompanhar entregas.
- Gerenciamento de Usuários e Autenticação:
![1](https://github.com/igormorantos/Ecommercer-microsservicos/assets/94862012/ab129320-5530-4afe-a413-b11a0148e045)

`GeekShopping.IdentityServer`:
- Serviço de autenticação e autorização baseado em IdentityServer4.
- Gerencia usuários e suas credenciais, tokens de acesso e garante a segurança do sistema.
![2](https://github.com/igormorantos/Ecommercer-microsservicos/assets/94862012/c4bc454e-c293-4239-9cd2-b65e738d1cba)

`GeekShopping.ProductAPI`:
- Gerencia o catálogo de produtos, incluindo CRUD, pesquisa e filtros.
- Permite adicionar, editar, excluir e obter detalhes de produtos.
![3](https://github.com/igormorantos/Ecommercer-microsservicos/assets/94862012/11dc7575-4645-45d1-9f9f-cf604cee4aa6)

`GeekShopping.CartAPI`:
- Gerencia o carrinho de compras do usuário.
- Permite adicionar, remover e atualizar itens, obter o total do carrinho e limpá-lo.
![5](https://github.com/igormorantos/Ecommercer-microsservicos/assets/94862012/3c2fe3b8-e4f8-4d54-bda6-8dd7c7e171d8)

`GeekShopping.CouponAPI`:
- Gerencia cupons de desconto.
- Permite criar, validar e aplicar cupons em pedidos.
![6](https://github.com/igormorantos/Ecommercer-microsservicos/assets/94862012/95eeea02-145d-4859-b5b0-0d95f7fb590e)

`GeekShopping.OrderAPI`:
- Gerencia pedidos, incluindo criação, pagamento e acompanhamento.
- Permite criar pedidos, gerenciar pagamentos e acompanhar o status dos pedidos.
- Não possui controller pois faz o gerenciamento de forma interna, sem a nescessidade de um controller
![7](https://github.com/igormorantos/Ecommercer-microsservicos/assets/94862012/09183fe4-4379-4c13-a175-573615de19e7)

`GeekShopping.PaymentAPI`:
- Implementação futura: Processa pagamentos online através de integração com provedores de pagamento.
- Atualmente é um mock onde os pagamentos sempre são aprovados
- Não possui controller pois faz o gerenciamento de forma interna, sem a nescessidade de um controller
  ![8](https://github.com/igormorantos/Ecommercer-microsservicos/assets/94862012/26dcdff4-22a5-4bcb-996b-baf882f3af3d)

`GeekShopping.Email`:
- Implementação futura: Envia emails transacionais como confirmação de pedido e recuperação de senha.
- Atualmente é um Mock com informações da compra mas o email não é enviado.
![8](https://github.com/igormorantos/Ecommercer-microsservicos/assets/94862012/d0e7ea9f-ad23-488d-a527-5f74c05c83f8)

`GeekShopping.MessageBus`:
- Barramento de mensagens que utiliza RabbitMQ para comunicação assíncrona entre os microsserviços.
- Permite que serviços se comuniquem sem bloquear uns aos outros.

`GeekShopping.PaymentProcessor`:
- Mock em que todos os pagamentos como true
- Implementaçções futuras: Integra-se com gateways de pagamento e sistemas financeiros para concluir transações.
- Implementaçções futuras: Efetua transações financeiras de forma segura e eficiente.
  
## Instalação e Configuração

Pré-requisitos:

- .NET 6.0
- Docker
- Banco de dados MySQL
- Container de rabbitMQ com interface grafica rodando nas portas `15672:15672` e `5672:5672`


## Como rodar o Projeto

- Não esqueça de inserir as suas credenciais de banco de dados no `appsettings.json` de cada projeto.
- Faça o download do Docker na sua maquina
- rie o container rabbitMQ com interface ```docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management```

No projeto `GeekShopping.web` rode o comando:
```
dotnet run
```




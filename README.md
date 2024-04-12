<h1 align="center">Geek Shopping Microsserviços</h1>
<p align="center"><i>O GeekShopping é um projeto de e-commerce completo, desenvolvido com microsserviços e tecnologias de ponta. Esta documentação visa fornecer uma visão geral da arquitetura do projeto, funcionalidades dos microsserviços e instruções para instalação e configuração.</i></p>

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

`GeekShopping.IdentityServer`:
- Serviço de autenticação e autorização baseado em IdentityServer4.
- Gerencia usuários e suas credenciais, tokens de acesso e garante a segurança do sistema.

`GeekShopping.ProductAPI`:
- Gerencia o catálogo de produtos, incluindo CRUD, pesquisa e filtros.
- Permite adicionar, editar, excluir e obter detalhes de produtos.

`GeekShopping.CartAPI`:
- Gerencia o carrinho de compras do usuário.
- Permite adicionar, remover e atualizar itens, obter o total do carrinho e limpá-lo.

`GeekShopping.CouponAPI`:
- Gerencia cupons de desconto.
- Permite criar, validar e aplicar cupons em pedidos.

`GeekShopping.OrderAPI`:
- Gerencia pedidos, incluindo criação, pagamento e acompanhamento.
- Permite criar pedidos, gerenciar pagamentos e acompanhar o status dos pedidos.

`GeekShopping.PaymentAPI`:
- Processa pagamentos online através de integração com provedores de pagamento.
- Permite processar pagamentos com cartão de crédito, PayPal e outros métodos.
  
`GeekShopping.Email`:
- Envia emails transacionais como confirmação de pedido e recuperação de senha.

`GeekShopping.MessageBus`:
- Barramento de mensagens que utiliza RabbitMQ para comunicação assíncrona entre os microsserviços.
  
## Instalação e Configuração

Pré-requisitos:

- .NET 6.0
- Banco de dados MySQL

## Running
dotnet run



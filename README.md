# Geek-Hunter_Microservice_Eccomerce

## Objetivo

O GeekShopping é um projeto de e-commerce completo, desenvolvido com microsserviços e tecnologias de ponta. Esta documentação visa fornecer uma visão geral da arquitetura do projeto, funcionalidades dos microsserviços e instruções para instalação e configuração.

## Arquitetura

A arquitetura do GeekShopping é composta por diversos microsserviços interligados, cada um com uma responsabilidade específica. A comunicação entre os serviços é realizada através de APIs RESTful e barramento de mensagens.

## Microsserviços

- `GeekShopping.Web`: Frontend do projeto, desenvolvido com ASP.NET Core MVC e Razor Pages. Consome APIs dos demais microsserviços para apresentar a interface do e-commerce.
- `GeekShopping.APIGateway`: Gateway de API que serve como intermediário entre o frontend e os demais microsserviços. Intercepta solicitações, aplica validações e roteia para o serviço correto.
- `GeekShopping.IdentityServer`: Serviço de autenticação e autorização, baseado em IdentityServer4. Gerencia tokens de acesso e garante a segurança do sistema.
- `GeekShopping.CatalogAPI`: Gerencia o catálogo de produtos, incluindo CRUD, pesquisa e filtros.
- `GeekShopping.CartAPI`: Gerencia o carrinho de compras do usuário, permitindo adicionar, remover e atualizar itens.
- `GeekShopping.OrderAPI`: Gerencia pedidos, incluindo criação, pagamento e acompanhamento.
- `GeekShopping.PaymentProcessor`: Processa pagamentos online através de integração com provedores de pagamento.
- `GeekShopping.CouponAPI`: Gerencia cupons de desconto, incluindo criação, validação e aplicação em pedidos.
- `GeekShopping.Email`: Envia emails transacionais, como confirmação de pedido e recuperação de senha.
- `GeekShopping.MessageBus`: Barramento de mensagens que utiliza RabbitMQ para comunicação assíncrona entre os microsserviços.

## Tecnologias

ASP.NET Core
Docker
RabbitMQ
Ocelot
IdentityServer4
Entity Framework Core
MySQL

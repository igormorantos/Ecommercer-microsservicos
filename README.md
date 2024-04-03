# Ecommerce-Microsserviços

## Objetivo

O GeekShopping é um projeto de e-commerce completo, desenvolvido com microsserviços e tecnologias de ponta. Esta documentação visa fornecer uma visão geral da arquitetura do projeto, funcionalidades dos microsserviços e instruções para instalação e configuração.

## Arquitetura

A arquitetura do GeekShopping é composta por diversos microsserviços interligados, cada um com uma responsabilidade específica. A comunicação entre os serviços é realizada através de APIs RESTful e barramento de mensagens.

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

## Tecnologias
- C#/.NET
- ASP.NET Core
- Docker
- RabbitMQ
- Ocelot
- IdentityServer4
- Entity Framework Core
- MySQL

  
## Instalação e Configuração

Pré-requisitos:

- Docker instalado e configurado
- Banco de dados MySQL

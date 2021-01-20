# RabbitMQ-Identity-ASP.NET-Core-WebAPI

Projeto comunicando duas API's com RabbitMQ.

Nesse projeto pude criar uma solução de comunicação entre duas API simulando um cadastro de cliente, com duas webapi uma com Identity responsável pela criação da conta e autenticação do usuário que quando devidamente identificado devolve um objeto json contendo um JWT token e a outra é um cadastro simplificado de usuário.
Ambas usam um conceito de DDD aplicando uma camada de Shared Kernel para compartilhar informações comuns entre os projetos, onde podemos encontrar: 

- IAggregateRoot (raiz de agregação lembrando que é um repositório por raiz.)
- Cpf e Email (Objeto de valor cada um com suas respectivas validações.)
- EntityBase 
- Mediator (Uma abstração do MediatR)
- Messages (Marcações para os eventos, comandos e eventos de integração) 

Também há a aplicação de CQRS com comandos para a criação do usuários e manipulados pelo MediatR.

O controle do acesso a dados ficou por conta do Entity Framework; quando criado o _Mapping_ das entidades com _OwnsOne_ mesmo adicionado a chamada para o _IsRequired_ não estava criando a coluna com _Not Null_ depois de pesquisar descobri que há um falha no EF reportada aqui https://github.com/dotnet/efcore/issues/18445 com isso foi preciso realizar a alteração manualmente na Migrations criada.

A comunicação entre as API foi utilizando o RabbitMQ e a biblioteca EasyNetQ com suporte a RPC (Remote Procedure Call) dessa forma quando houvesse uma falha na criação do cliente(Customer.API) é enviado uma mensagem através da fila (Bus) com o erro e então dá-se inicio a exclusão do usuário(Identity.API) caso contrário é entregue para quem solicitou o StatusCode 200.

# create-csharp-worker-rabbitmq-mongodb

## Overview:
Creating a C# .NET Core Worker based on Clean Architecture.

This example is an implementation where I adapted a Worker layer to work together clean architecture layers. Read [readme file ](https://github.com/andrebianco-net/andrebianco-net#readme) in order to obtain more details about the finality of this solution.

In order to know more aboute my career check my Linkedin profile, please.

https://www.linkedin.com/in/andrebianco-net/

## General Scope:

Sales Order Sender implementation propose a small example of how to create a Worker service using C#.

C# .NET Core Worker based on Clean Architecture, using Worker, Repository and xUnit to test the implementation. It will use MongoDB database and RabbitMQ/Docker as an integration queue.  

The Solution will be a Worker which record purchases into MongoDB database (SalesOrders collection) and use RabbitMQ/Docker as an integration queue where the sales orders (messages) will be taken from an extremity to other.

## How to run this project

#### 1. Clone project:

$ git clone https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb.git

#### 2. Update file appsettings.json with a valid:

First rename the file appsettings.template to appsettings.json.

"MongoDB": {
    "ConnectionURI": "YOUR MONGODB URI",
    "DatabaseName": "YOUR DATABASE NAME",
    "CollectionName": "SalesOrders"
},
"RabbitMQ": {
    "Uri": "amqp://YOUR USER:YOUR PASSWORD@YOUR HOST:5672",
    "ClientProvidedName": "Sales Order Sender",
    "ExchangeName": "ExchangeSalesOrder",
    "RoutingKey": "sales-order-01",
    "QueueName": "SalesOrder"
  }

#### 3. Compile project:

$ dotnet build

#### 4. Test project:

$ dotnet test

#### 5. Run project:

$ dotnet run --project SalesOrderSender.Worker/SalesOrderSender.Worker.csproj

#### 6. MongoDB document

As an example, use the JSon document bellow to insert into the SalesOrders collection.

{
  "_id": {
    "$oid": "65577e42b9ca0bb418c6c43f"
  },
  "CustomerId": 1,
  "CategoryId": 1,
  "ListProductId": [1, 3, 4, 7],
  "PaymentTypeId": 2,
  "Total": 100,
  "SoldAt": "2023-11-16 18:49:00",
  "createdAt": "2023-11-16 18:59:00",
  "AcceptedOrder": true
}

#### 7. Set the log folder

Define a real path to the log.

"Serilog": {
    "Folder": "Log",
    "File": "SalesOrderSenderServiceWorker.log",
    "Size": 5242880
},

#### 8. RabbitMQ/Docker

Useful commands:

$ sudo systemctl status docker

$ docker run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3-management

$ sudo docker container ls --all --quiet --no-trunc --filter "name=rabbit-server"

$ sudo docker start FULL-CONTAINER-ID

$ sudo docker stop FULL-CONTAINER-ID

Access to http://localhost:8080/#/ and consider use guest/guest to access if it's the case

# create-csharp-worker-rabbitmq-mongodb

## Overview:
Creating a C# .NET Core Worker based on Clean Architecture.

This example is an implementation where I adapted a Worker layer to work together clean architecture layers. Read [readme file ](https://github.com/andrebianco-net/andrebianco-net#readme) in order to obtain more details about the finality of this solution.

In order to know more aboute my career check my Linkedin profile, please.

https://www.linkedin.com/in/andrebianco-net/

## General Scope:

Sales Order Sender implementation propose a small example of how to create a Worker service using C#.

C# .NET Core Worker based on Clean Architecture, using Worker, Repository and xUnit to test the implementation. It will use MongoDB database and RabbitMQ/Docker as an integration queue.  

The Solution will be a Worker which records purchases into MongoDB database (SalesOrders collection) and use RabbitMQ/Docker as an integration queue where the sales orders (messages) will be taken from an extremity to other.

## How to run this project

#### 1. Clone project:

```bash
$ git clone https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb.git
```

#### 2. Update file appsettings.json with a valid:

First rename the file appsettings.template to appsettings.json.

```json
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
```

#### 3. Compile project:

```bash
$ dotnet build
```

#### 4. Test project:

```bash
$ dotnet test
```

#### 5. Run project:

```bash
$ dotnet run --project SalesOrderSenderService.Worker/SalesOrderSenderService.Worker.csproj
```

#### 6. MongoDB document

As an example, use the JSon document bellow to insert into the SalesOrders collection.

```json
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
```

#### 7. Set the log folder

Define a real path to the log.

```json
"Serilog": {
    "Folder": "Log",
    "File": "SalesOrderSenderServiceWorker.log",
    "Size": 5242880
},
```

#### 8. RabbitMQ/Docker (Localhost)

<ins>Useful commands:</ins>

```bash
$ sudo systemctl status docker
```

```bash
$ docker run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3-management
```

```bash
$ sudo docker container ls --all --quiet --no-trunc --filter "name=rabbit-server"
```

```bash
$ sudo docker start FULL-CONTAINER-ID
```

```bash
$ sudo docker stop FULL-CONTAINER-ID
```

Access to http://localhost:8080/#/ and consider use guest/guest to access if it's the case

#### 9. From Docker to Azure Container

```bash
$ docker build -t salesorder-sender-service .
```

```bash
[$ docker run -it salesorder-sender-service]
```

```bash
$ docker login youruricreatedinazurecontainerregistry.azurecr.io
```

```bash
$ docker tag salesorder-sender-service youruricreatedinazurecontainerregistry.azurecr.io/salesorder-sender-service
```

```bash
$ docker push youruricreatedinazurecontainerregistry.azurecr.io/salesorder-sender-service
```

```bash
[$ docker pull youruricreatedinazurecontainerregistry.azurecr.io/salesorder-sender-service]
```

#### 10. Created in Azure Cloud Computing

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb/assets/453193/e8b37bae-d0f9-466e-a6d9-a120c5e976df)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb/assets/453193/1a3bf638-af39-42fc-bb43-59e1bfc1e3f5)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb/assets/453193/db69f6c7-e867-4e26-9bfc-a9d5e6406b0b)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb/assets/453193/b965fae7-422f-40c7-ab0d-2070f2922fb9)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb/assets/453193/b824813c-9b2c-4ded-9e17-369ca77e26e0)


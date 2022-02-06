# Microservis mimari ile Rehber back-end çalışması

## Contents
- [Teknolojiler](#teknolojiler)
  - [Framework](#framework)
  - [ORM](#orm)
  - [DB](#db)
  - [Message Broker](#message-broker)
- [Portlar](#portlar)
- [Yapılması Gerekenler](#yapılması-gerekenler)
  - [ContactDB](#contactdb)
  - [ReportDB IntegrationEventDB](#reportdb-integrationeventdb)
- [Postman](#postman)
- [License](#license)

## Teknolojiler  
###  Framework
.NET Core 5
###  ORM  
Entity Framework Core (5.0.7 - 5.0.13)
### DB
Postgres (3 veritabanı var.)
### Message Broker
RabbitMQ 3.8

## Portlar

- APIGateway : 7000
- ContactAPI : 5000 
- ReportAPI : 5010 




## Yapılması Gerekenler

### ContactDB

StartUp Project ContactAPI seçili iken;

Package Manager Console ile Default Project "ContactCore" seçilerek aşağıdaki komutlar çalıştırılır.(Migrationlar hazır)

- Add-Migration Contact_20220206
- update-database

### ReportDB IntegrationEventDB

StartUp Project ReportAPI seçili iken;

Package Manager Console ile Default Project "ReportCore" seçilerek aşağıdaki komutlar çalıştırılır.(Migrationlar hazır)

- Add-Migration Report_20220206 -context ApplicationDbContext
- update-database -context ApplicationDbContext

Package Manager Console ile Default Project "IntegrationEventLogEF" seçilerek aşağıdaki komutlar çalıştırılır.(Migrationlar hazır)

- Add-Migration IntegrationEvent_20220206 -context IntegrationEventLogContext
- update-database -context IntegrationEventLogContext

## Postman 

RISE.postman_collection json dosyası postmana import edilip ilgili sorgulamalar yapılabilir.

Genelde işlemler Gateway üzerinden yapılıyor.

## License 

MSTask is [MIT licensed](./LICENSE).





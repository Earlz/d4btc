drop table config;
drop table products;
drop table productimages;
drop table transactions;

CREATE TABLE Config
(
   Id serial primary key, --not really needed, but for easy editing
   RpcUser varchar(512),
   RpcPassword varchar(512),
   RpcUrl varchar(512),
   Confirmations int default 6,
   RedownloadWindow int default 6000, --an amount in seconds
   SiteName varchar(64) default 'd4btc store'
);
--todo:defaults
create table Products
(
    Id serial primary key,
    Created timestamp not null default now(),
    OrderId int unique,
    Name varchar(64) not null default '',
    Description text not null default '',
    MinPrice decimal(8,8) not null default 0.0,
    MaxPrice decimal(8,8),
    Download varbit, --allow for null for "staging"
    CallbackUrl varchar,
    Refundable boolean default false,
    Staging boolean default true,
    Deleted boolean default false
);

create table ProductImages
(
    Id serial primary key,
    ProductId int not null,
    Image varbit,
    PrimaryImage boolean not null default false
);

create table Transactions
(
    Id serial primary key,
    Created timestamp not null default now(),
    ProductId int not null,
    ToAddress varchar(50) not null,
    FromAddress varchar(50),
    Pending boolean not null default true,
    Refunded boolean not null default false,
    AvailableFrom timestamp not null, --the time when the balance is seen as met and verified and the DLC becomes downloadable
    DownloadedAt timestamp,
    SecretId uuid not null,
    Price decimal(8,8) not null --denormalize so if price changes, this transaction is still valid
);

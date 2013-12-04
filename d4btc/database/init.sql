CREATE TABLE Config
(
   rpcuser varchar(512),
   rpcpassword varchar(512),
   rpcurl varchar(512),
   confirmations int,
   
);

create table Products
(
    id serial primary key,
    orderid int unique,
    name varchar(64),
    description text,
    min_price decimal(8,8) not null,
    max_price decimal(8,8),
    download varbit,
    callback_url varchar
);


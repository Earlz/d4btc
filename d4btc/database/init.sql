CREATE TABLE Config
(
   rpcuser varchar(512),
   rpcpassword varchar(512),
   rpcurl varchar(512),
   confirmations int,
   redownload_window int, --an amount in seconds
);
--todo:defaults
create table Products
(
    id serial primary key,
    orderid int unique,
    name varchar(64),
    description text,
    min_price decimal(8,8) not null,
    max_price decimal(8,8),
    download varbit,
    callback_url varchar,
    refundable boolean
);

create table Transactions
(
    id serial primary key,
    product_id int not null,
    to_address varchar(50) not null,
    from_address varchar(50),
    pending boolean not null,
    refunded boolean not null,
    available_from timestamp,
    downloaded_at timestamp,
    secret_id uuid not null,
    
    
);

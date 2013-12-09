using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace Earlz.d4btc
{
    public class Product
    {
        public int Id{get;set;}
        public DateTime Created{get;set;}
        public int OrderId{get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public decimal MinPrice{get;set;}
        public decimal? MaxPrice{get;set;}
        //download
        public string CallbackUrl{get;set;}
        public bool Refundable{get;set;}
        public bool Staging{ get; set; }
        public bool Deleted{get;set;}
        public List<int> Pictures{get;set;}
    }
    public class ProductData
    {
        public const int PageSize=20;
        public static List<Product> ProductList(int page)
        {
            using (var c=DataLayer.Connection())
            {
                int offset = (page / 10) - 1;
                return c.Query<Product>(@"
                    select Id, Created, OrderId, Name, Description, MinPrice, MaxPrice,
                        Refundable, Staging, Deleted
                    from Products offset @off limit @lim", new {off=offset, lim=PageSize}).ToList(); //manually filter deleted/staging
            }
        }
    }
}


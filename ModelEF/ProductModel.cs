using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF
{
    public class ProductModel
    {
        private NguyenNhaTrucContext context = null;
        public ProductModel()
        {
            context = new NguyenNhaTrucContext();
        }
        public List<Product> ListAll()
        {
            var list = context.Database.SqlQuery<Product>("Product_ListOption").ToList();
            return list;
        }
    }
}

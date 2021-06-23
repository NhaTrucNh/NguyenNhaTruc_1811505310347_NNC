using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;
namespace ModelEF
{
    public class UserAccountModel
    {
        private NguyenNhaTrucContext context = null;
        public UserAccountModel()
        {
            context = new NguyenNhaTrucContext();
        }
        public bool Login(string userName, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", password),
            };
            var res = context.Database.SqlQuery<bool>("Account_Login @UserName, @Password", sqlParams).SingleOrDefault();
            return res;
        }


        public int Create(string UserName, string Password, string Status)
        {
            object[] parameters =
            {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@Password", Password),
                new SqlParameter("@Status", Status)
            };
            int res = context.Database.ExecuteSqlCommand("UserAccount_Insert @UserName, @Password, @Status", parameters);
            return res;
        }
    }
}

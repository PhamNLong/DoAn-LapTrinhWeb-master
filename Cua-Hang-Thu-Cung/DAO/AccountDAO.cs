using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Cua_Hang_Thu_Cung.Models;

namespace Cua_Hang_Thu_Cung.DAO
{
    public class AccountDAO
    {

        private DataClasses1DataContext data = null;

        public AccountDAO()
        {
            data = new DataClasses1DataContext();
        }
        public bool Login(string email, string pw)
        {
            if (email == null || pw == null)
            {
                return false;
            }
            else
            {
                var res = data.tblUsers.SingleOrDefault(a => a.email == email && a.pw == pw && a.trang_thai == 1);
                if (res != null) return true;
                return false;
            }
        }
    }
}
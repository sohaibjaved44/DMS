using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class UserViewModel
    {
        public USER_TBL user = new USER_TBL();
        public ROLE_TBL role = new ROLE_TBL();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWeb.Entities.AdminUserEntity
{
    public class AdminUser
    {
        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// LoginName
        /// </summary>		
        private string _loginname;
        public string LoginName
        {
            get;
            set;
        }
        /// <summary>
        /// Password
        /// </summary>		
        private string _password;
        public string Password
        {
            get;
            set;
        }
        /// <summary>
        /// Status
        /// </summary>		
        private bool _status;
        public bool Status
        {
            get;
            set;
        }
        /// <summary>
        /// Email
        /// </summary>		
        private string _email;
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// DateTime
        /// </summary>		
        private DateTime _datetime;
        public DateTime DateTime
        {
            get;
            set;
        }

        private DateTime? _birthday;
        public DateTime? Birthday
        {
            get;
            set;
        }

        private string  _phone;
        public string  Phone
        {
            get;
            set;
        }


    }
}

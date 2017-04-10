using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjM.Sessions
{
    public class MySession
    {

        // private constructor
        private MySession()
        {
            Data1 = "default value";
        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        // **** add your session properties here, e.g like this:
        public string Data1 { get; set; }
        public DateTime MyDate { get; set; }
        public int LoginId { get; set; }


    }
}
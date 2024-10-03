using System;
namespace StudentBrain.Common
{
    public class User_Rol
    {
        public User_Rol()
        {
            Pk_User_Rol = 0;
            Fk_User = 0;
            Fk_Rol = 0;
            User_Created = "";
            Date_Created = Convert.ToDateTime("1900-01-01");
            User_Updated = "";
            Date_Updated = Convert.ToDateTime("1900-01-01");
            Active = false;
        }
        public Int32 Pk_User_Rol { get; set; }
        public Int32 Fk_User { get; set; }
        public Int32 Fk_Rol { get; set; }
        public String User_Created { get; set; }
        public DateTime Date_Created { get; set; }
        public String User_Updated { get; set; }
        public DateTime Date_Updated { get; set; }
        public Boolean Active { get; set; }
    }
}

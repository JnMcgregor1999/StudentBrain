using System;
namespace StudentBrain.Common
{
    public class Permissions
    {
        public Permissions()
        {
            Pk_Permissions = 0;
            Fk_Rol = 0;
            Allows_Inserted = false;
            Allows_Updated = false;
            Allows_Deleted = false;
            Allows_Selected = false;
            User_Created = "";
            Date_Created = Convert.ToDateTime("1900-01-01");
            User_Updated = "";
            Date_Updated = Convert.ToDateTime("1900-01-01");
            Active = false;
        }
        public Int32 Pk_Permissions { get; set; }
        public Int32 Fk_Rol { get; set; }
        public Boolean Allows_Inserted { get; set; }
        public Boolean Allows_Updated { get; set; }
        public Boolean Allows_Deleted { get; set; }
        public Boolean Allows_Selected { get; set; }
        public String User_Created { get; set; }
        public DateTime Date_Created { get; set; }
        public String User_Updated { get; set; }
        public DateTime Date_Updated { get; set; }
        public Boolean Active { get; set; }
    }
}

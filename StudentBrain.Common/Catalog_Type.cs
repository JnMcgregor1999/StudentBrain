﻿using System;
namespace StudentBrain.Common
{
    public class Catalog_Type
    {
        public Catalog_Type()
        {
            Pk_Catalog_Type = 0;
            Name = "";
            Description = "";
            User_Created = "";
            Date_Created = Convert.ToDateTime("1900-01-01");
            User_Updated = "";
            Date_Updated = Convert.ToDateTime("1900-01-01");
            Active = false;
        }
        public Int32 Pk_Catalog_Type { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String User_Created { get; set; }
        public DateTime Date_Created { get; set; }
        public String User_Updated { get; set; }
        public DateTime Date_Updated { get; set; }
        public Boolean Active { get; set; }
    }
}

﻿using System;
using static StudentBrain.Common.Enum;

namespace StudentBrain.Common
{
    public class Message
    {
        #region Region [Propiedades]
        public string MessageInfo { get; set; }
        public Status Status { get; set; }
        public string Result { set; get; }
        public Operation Operation { set; get; }
        public String BusinessLogic { set; get; }
        public String Proceso { set; get; }
        public String Accion { set; get; }
        public String Connection { set; get; }
        public int draw { set; get; }
        public int start { set; get; }
        public int length { set; get; }
        public Int64 Total { set; get; }

        #endregion

        #region Region [Constructor]
        public Message() { }
        public Message(string xResult)
        {
            Result = xResult;

            if (string.IsNullOrEmpty(Result))
                Status = Status.Failed;
            else
                Status = Status.Success;
        }
        public Message(Exception xCurrentException)
        {
            MessageInfo = xCurrentException.Message;
            Status = Status.Failed;
        }
        #endregion
    }
}

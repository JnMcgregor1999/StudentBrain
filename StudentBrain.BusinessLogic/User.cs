using StudentBrain.Common;
using StudentBrain.DataAccess;
using StudentBrain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentBrain.Common.Enum;

namespace StudentBrain.BusinessLogic
{
    public class User : IBusinessLogic
    {
        #region  [Methods]
        /// <summary>
        /// Nombre: DoWork
        /// Descripcion: Metodo encargado de orquestar las solicitudes de operaciones para el objeto "User".
        /// Fecha de creación: 7/26/2019.
        /// Autor: Erick Sibaja.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<Common.Message> DoWork(Message message)
        {
            try
            {
                switch (message.Operation)
                {
                    case Operation.List:
                        return await List(message);
                    case Operation.Get:
                        return await Get(message);
                    case Operation.Save:
                        return await Save(message);
                    case Operation.Delete:
                        return await Delete(message);
                    default:
                        var resultMessage = new Message();
                        resultMessage.Status = Status.Failed;
                        resultMessage.Result = "Operación no soportada";
                        resultMessage.MessageInfo = string.Empty;
                        return resultMessage;
                }
            }
            catch (Exception ex)
            {
                var resultMessage = new Message();
                resultMessage.Status = Status.Failed;
                resultMessage.Result = string.Format("{0}", ex.Message);
                resultMessage.MessageInfo = string.Empty;
                return resultMessage;
            }
        }
        public async virtual Task<Message> List(Message message)
        {
            try
            {
                var resultMessage = new Common.Message();
                var model = message.DeSerializeObject<Common.User>();
                using (var repository = new User_Repository(message.Connection))
                {
                    var returnObject = await repository.List(model);
                    resultMessage.Status = Status.Success;
                    resultMessage.Result = "Proceso efectuado satisfactoriamente...";
                    resultMessage.MessageInfo = returnObject.SerializeObject();
                    return resultMessage;
                }
            }
            catch (Exception ex)
            {
                var resultMessage = new Common.Message();
                resultMessage.Status = Status.Failed;
                resultMessage.Result = string.Format("{0}", ex.Message);
                resultMessage.MessageInfo = string.Empty;
                return resultMessage;
            }
        }
        public async virtual Task<Message> Get(Message message)
        {
            try
            {
                var resultMessage = new Message();
                var model = message.DeSerializeObject<Common.User>();
                using (var repository = new User_Repository(message.Connection))
                {
                    var returnObject = await repository.Get(model);
                    resultMessage.Status = Status.Success;
                    resultMessage.Result = "Proceso efectuado satisfactoriamente...";
                    resultMessage.MessageInfo = returnObject.SerializeObject();
                    return resultMessage;
                }
            }
            catch (Exception ex)
            {
                var resultMessage = new Message();
                resultMessage.Status = Status.Failed;
                resultMessage.Result = string.Format("{ 0}", ex.Message);
                resultMessage.MessageInfo = string.Empty;
                return resultMessage;
            }
        }
        public async virtual Task<Message> Save(Message message)
        {
            try
            {
                var resultMessage = new Message();
                var model = message.DeSerializeObject<Common.User>();
                using (var repository = new User_Repository(message.Connection))
                {
                    await repository.Save(model);
                    resultMessage.Status = Status.Success;
                    resultMessage.Result = "Proceso efectuado satisfactoriamente...";
                    resultMessage.MessageInfo = model.SerializeObject();
                    return resultMessage;
                }
            }
            catch (Exception ex)
            {
                var resultMessage = new Message();
                resultMessage.Status = Status.Failed;
                resultMessage.Result = string.Format("{0}", ex.Message);
                resultMessage.MessageInfo = string.Empty;
                return resultMessage;
            }
        }
        public async virtual Task<Common.Message> Delete(Message message)
        {
            try
            {
                var resultMessage = new Message();
                var model = message.DeSerializeObject<Common.User>();
                using (var repository = new User_Repository(message.Connection))
                {
                    await repository.Delete(model);
                    resultMessage.Status = Status.Success;
                    resultMessage.Result = "Proceso efectuado satisfactoriamente...";
                    resultMessage.MessageInfo = String.Empty;
                    return resultMessage;
                }
            }
            catch (Exception ex)
            {
                var resultMessage = new Common.Message();
                resultMessage.Status = Status.Failed;
                resultMessage.Result = string.Format("{0}", ex.Message);
                resultMessage.MessageInfo = string.Empty;
                return resultMessage;
            }
        }
        #endregion

        #region Region [Dispose]
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
        }
        ~User()
        {
            this.Dispose(false);
        }
        #endregion
    }
}

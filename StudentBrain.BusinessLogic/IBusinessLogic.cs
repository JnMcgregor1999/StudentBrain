using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBrain.BusinessLogic
{
    public interface IBusinessLogic : IDisposable
    {
        Task<Common.Message> DoWork(Common.Message message);
        Task<Common.Message> List(Common.Message message);
        Task<Common.Message> Get(Common.Message message);
        Task<Common.Message> Save(Common.Message message);
        Task<Common.Message> Delete(Common.Message message);
    }
}

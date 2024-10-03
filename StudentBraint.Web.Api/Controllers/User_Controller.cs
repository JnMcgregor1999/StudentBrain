using System;
using Microsoft.AspNetCore.Mvc;
using StudentBrain.BusinessLogic;
using StudentBrain.Common;
using StudentBrain.Utilities;
using static StudentBrain.Common.Enum;
namespace StudentBrain.Wep.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {
        private IConfiguration configuration;
        public UserController(IConfiguration iConfiguration)
        {
            configuration = iConfiguration;
        }
        #region Region [Methods]
        /// <summary>
        /// Nombre: ListarUser
        /// Descripcion: Metodo utilizado para ontener una lista de modelos USER y retornar un objeto datatable
        /// Fecha de creacion: 10/2/2024
        /// Autor: JnMcGregor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Route("List")]
        [HttpPost]
        public async Task<IActionResult> List([FromBody] Common.User model)
        {
            try
            {
                var message = new Message();
                message.BusinessLogic = configuration.GetValue<string>("AppSettings:BusinessLogic:User");
                message.Connection = configuration.GetValue<string>("ConnectionStrings:StudentBrainConnection");
                message.Operation = Operation.List;
                message.MessageInfo = model.SerializeObject();
                using (var businessLgic = new DoWorkService())
                {
                    var result = await businessLgic.DoWork(message);
                    if (result.Status == Status.Failed)
                    {
                        return BadRequest(result.Result);
                    }
                    var list = result.DeSerializeObject<IEnumerable<Common.User>>();
                    var dataSuccess = new
                    {
                        Data = list,
                        MessageResult = Status.Success,
                        Message = string.Empty,
                        RegisterType = string.Empty
                    };
                    return Ok(dataSuccess);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Nombre: ObtenerUser
        /// Descripcion: Metodo utilizado para ontener una lista de modelos USER y retornar un objeto datatable
        /// Fecha de creacion: 10/2/2024
        /// Autor:JnMcGregor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Route("Get")]
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] Common.User model)
        {
            try
            {
                var message = new Message();
                message.BusinessLogic = configuration.GetValue<string>("AppSettings:BusinessLogic:User");
                message.Connection = configuration.GetValue<string>("ConnectionStrings:StudentBrainConnection");
                message.Operation = Operation.Get;
                message.MessageInfo = model.SerializeObject();
                using (var businessLgic = new DoWorkService())
                {
                    var result = await businessLgic.DoWork(message);
                    if (result.Status == Status.Failed)
                    {
                        return BadRequest(result.Result);
                    }
                    var resultModel = result.DeSerializeObject<Common.User>();
                    var dataSuccess = new
                    {
                        Data = resultModel,
                        MessageResult = Status.Success,
                        Message = string.Empty,
                        RegisterType = string.Empty
                    };
                    return Ok(dataSuccess);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Nombre: GuardarUser
        /// Descripcion: Metodo utilizado para ontener una lista de modelos USER y retornar un objeto datatable
        /// Fecha de creacion: 10/2/2024
        /// Autor:JnMcGregor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Common.User model)
        {
            try
            {
                var message = new Message();
                message.BusinessLogic = configuration.GetValue<string>("AppSettings:BusinessLogic:User");
                message.Connection = configuration.GetValue<string>("ConnectionStrings:StudentBrainConnection");
                message.Operation = Operation.Save;
                message.MessageInfo = model.SerializeObject();
                using (var businessLgic = new DoWorkService())
                {
                    var result = await businessLgic.DoWork(message);
                    if (result.Status == Status.Failed)
                    {
                        return BadRequest(result.Result);
                    }
                    var resultModel = result.DeSerializeObject<Common.User>();
                    var dataSuccess = new
                    {
                        Data = resultModel,
                        MessageResult = Status.Success,
                        Message = string.Empty,
                        RegisterType = string.Empty
                    };
                    return Ok(dataSuccess);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion Region [Methods]
    }
}

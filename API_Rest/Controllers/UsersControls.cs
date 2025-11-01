using API_Rest.Context;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest.Controllers
{
    [Route("api/UsersControls")]
    public class UsersControls: Controller
    {
        ///<summary>
        ///Авторизация пользователя
        /// </summary>
        /// <remarks>Данный метод авторизирует пользователя, находит пользователя в базе данных</remarks>
        /// <response code="200">Пользователь успешно авторизован</response>
        /// <response code="500">При выполнении задачи на стороне сервера возникли ошибки</response>
        [Route("Auth")]
        [HttpPost]
        [ProducesResponseType(typeof(List<Users>), 200)]
        [ProducesResponseType (500)]
        public ActionResult Auth([FromForm]string Login, [FromForm] string Password)
        {
            if(Login == null && Password == null)
                return StatusCode(403);
            try
            {
                Users users = new GeneralContext().Users.Where(x => x.Login == Login && x.Password == Password).First();
                return Json(users);
            }
            catch
            {
                return Json(500);
            }
        }
        ///<summary>
        ///Регистрация пользователя пользователя
        /// </summary>
        /// <remarks>Данный метод добавляет пользователя в базу данных</remarks>
        /// <response code="200">Пользователь успешно зарегистрирован</response>
        /// <response code="500">При выполнении задачи на стороне сервера возникли ошибки</response>
        [Route("Reg")]
        [HttpPost]
        [ProducesResponseType(typeof(List<Users>), 200)]
        [ProducesResponseType(500)]
        public ActionResult Reg([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null && Password == null)
                return StatusCode(403);
            try
            {
                using(GeneralContext context = new GeneralContext())
                {
                    Users users = new Users()
                    {
                        Login = Login,
                        Password = Password
                    };
                    context.Users.Add(users);
                    context.SaveChanges();
                    return Json(users);
                }
            }
            catch
            {
                return Json(500);
            }
        }
    }
}

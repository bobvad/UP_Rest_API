using API_Rest.Context;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest.Controllers
{
    public class UsersPuzzleController : Controller
    {
        /// <summary>
        /// Начать сборку пазла
        /// </summary>
        [HttpPost]
        [Route("StartPuzzle")]
        public IActionResult StartPuzzle([FromForm] int userId, [FromForm] int puzzleId) 
        {
            try
            {
                using (GeneralContext context = new GeneralContext())
                {
                    var userPuzzle = new UserPuzzle
                    {
                        UserId = userId,
                        PuzzleId = puzzleId,
                        CreatedDate = DateTime.Now
                    };

                    context.UsersPuzzles.Add(userPuzzle);
                    context.SaveChanges();

                    return Json(new
                    {
                        success = true,
                        message = "Сборка пазла начата",
                        userPuzzleId = userPuzzle.Id
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при начале сборки: {ex.Message}");
            }
        }

        /// <summary>
        /// Получить все начатые пазлы пользователя
        /// </summary>
        [HttpGet]
        [Route("GetUserPuzzles")]
        public IActionResult GetUserPuzzles(int userId)
        {
            try
            {
                using (GeneralContext context = new GeneralContext())
                {
                    var userPuzzles = context.UsersPuzzles
                        .Where(x => x.UserId == userId)
                        .Join(context.Puzzles,
                            up => up.PuzzleId,
                            p => p.Id,
                            (up, p) => new
                            {
                                UserPuzzleId = up.Id,
                                PuzzleId = p.Id,
                                PuzzleName = p.Name,
                                FullImage = p.FullImage,
                                TotalPieces = p.TotalPieces,
                                CreatedDate = up.CreatedDate
                            })
                        .ToList();

                    return Json(new
                    {
                        success = true,
                        data = userPuzzles
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при получении пазлов: {ex.Message}");
            }
        }
    }
}
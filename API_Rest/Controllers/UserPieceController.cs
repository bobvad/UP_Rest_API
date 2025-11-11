using API_Rest.Context;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest.Controllers
{
    public class UserPieceController : Controller
    {
        /// <summary>
        /// Добавление кусочка пазла
        /// </summary>
        [HttpPost]
        [Route("AddPiece")]
        public IActionResult AddPiece([FromForm] int userPuzzleId, [FromForm] int pieceNumber)
        {
            try
            {
                using (GeneralContext context = new GeneralContext())
                {
                    var userPiece = new UserPiece
                    {
                        UserPuzzleId = userPuzzleId,
                        PieceNumber = pieceNumber,
                        CollectedDate = DateTime.Now
                    };

                    context.UserPieces.Add(userPiece);
                    context.SaveChanges();

                    return Json(new
                    {
                        success = true,
                        message = "Кусочек пазла добавлен"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при добавлении кусочка: {ex.Message}");
            }
        }
    }
}
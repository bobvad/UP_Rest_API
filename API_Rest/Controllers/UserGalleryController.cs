using API_Rest.Context;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest.Controllers
{
    public class UserGalleryController : Controller
    {
        /// <summary>
        /// Получить галерею пользователя
        /// </summary>
        [HttpGet]
        [Route("GetUserGallery")]
        public IActionResult GetUserGallery(int userId)
        {
            try
            {
                using (GeneralContext context = new GeneralContext())
                {
                    var gallery = context.UsersGallerys
                        .Where(x => x.UserId == userId)
                        .Join(context.Puzzles,
                            ug => ug.PuzzleId,
                            p => p.Id,
                            (ug, p) => new
                            {
                                GalleryId = ug.Id,
                                PuzzleId = p.Id,
                                PuzzleName = p.Name,
                                FullImage = p.FullImage,
                                CompletedDate = ug.CompletedDate,
                                SelectedDays = ug.SelectedDays,
                                MissedDays = ug.MissedDays
                            })
                        .ToList();

                    return Json(new
                    {
                        success = true,
                        data = gallery
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при получении галереи: {ex.Message}");
            }
        }

        /// <summary>
        /// Добавить пазл в галерею после сборки
        /// </summary>
        [HttpPost]
        [Route("AddToGallery")]
        public IActionResult AddToGallery(int userPuzzleId)
        {
            try
            {
                using (GeneralContext context = new GeneralContext())
                {
                    var userPuzzle = context.UsersGallerys
                        .FirstOrDefault(x => x.Id == userPuzzleId);

                    if (userPuzzle == null)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Запись о пазле не найдена"
                        });
                    }

                    var existingGallery = context.UsersGallerys
                        .FirstOrDefault(x => x.UserPuzzleId == userPuzzleId);

                    if (existingGallery != null)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Пазл уже в галерее"
                        });
                    }

                    var galleryItem = new UserGallery
                    {
                        UserId = userPuzzle.UserId,
                        PuzzleId = userPuzzle.PuzzleId,
                        UserPuzzleId = userPuzzleId,
                        CompletedDate = DateTime.Now,
                        MissedDays = 0, 
                        SelectedDays = 0,
                        CreatedDate = DateTime.Now
                    };

                    context.UsersGallerys.Add(galleryItem);
                    context.SaveChanges();

                    return Json(new
                    {
                        success = true,
                        message = "Пазл добавлен в галерею"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при добавлении в галерею: {ex.Message}");
            }
        }
    }
}
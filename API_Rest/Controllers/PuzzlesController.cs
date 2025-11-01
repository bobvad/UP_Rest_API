﻿using API_Rest.Context;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest.Controllers
{
    public class PuzzlesController: Controller
    {
        ///<summary>
        ///Добавление пазла администратором
        /// </summary>
        /// <remarks>Данный метод добавляет пазл в базу данных</remarks>
        /// <response code="200">Пазл успешно добавлен</response>
        /// <response code="403">Неверные данные администратора</response>
        /// <response code="500">При выполнении задачи на стороне сервера возникли ошибки</response>
        [Route("AddPuzzle")]
        [HttpPost]
        [ProducesResponseType(typeof(Puzzles), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult AddPuzzle(
            [FromForm] string AdminLogin,
            [FromForm] string AdminPassword,
            [FromForm] string Name,
            [FromForm] string Description,
            [FromForm] string PreviewImage,
            [FromForm] string FullImage,
            [FromForm] int TotalPieces)
        {
            try
            {
                using (GeneralContext context = new GeneralContext())
                {
                    Puzzles puzzle = new Puzzles()
                    {
                        Name = Name,
                        Description = Description,
                        FullImage = FullImage,
                        TotalPieces = TotalPieces,
                        IsActive = true,
                        CreatedDate = DateTime.Now
                    };

                    context.Puzzles.Add(puzzle);
                    context.SaveChanges();


                    return Json(new
                    {
                        success = true,
                        message = "Пазл успешно добавлен"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при добавлении пазла: {ex.Message}");
            }
        }

        ///<summary>
        ///Удаление пазла и его описания и всех остальных элементов администратором
        /// </summary>
        /// <remarks>Данный метод добавляет пазл в базу данных</remarks>
        /// <response code="200">Пазл успешно добавлен</response>
        /// <response code="403">Неверные данные администратора</response>
        /// <response code="500">При выполнении задачи на стороне сервера возникли ошибки</response>
        [Route("DeletePuzzle")]
        [HttpPost]
        [ProducesResponseType(typeof(Puzzles), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult DeletePuzzle(
            int id)
        {
            try
            {
                using (GeneralContext context = new GeneralContext())
                {
                    var idPuzzle = context.Puzzles.Where(x => x.Id == id).First();
                    context.Puzzles.Remove(idPuzzle);
                    context.SaveChanges();
                    return Json(new
                    {
                        success = true,
                        message = "Пазл успешно добавлен"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при добавлении пазла: {ex.Message}");
            }
        }


    }
}

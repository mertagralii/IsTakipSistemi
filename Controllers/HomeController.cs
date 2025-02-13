using System.Data;
using System.Diagnostics;
using Dapper;
using IsTakipSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbConnection _connection;

        public HomeController(IDbConnection connection) 
        {
            _connection = connection;
        }

        public IActionResult Index()
        {
            var worksList = _connection.Query<WorksLeftJoinModel>(
                                                     @"SELECT w.Id AS WorkId , w.Title , W.StatusId AS WorksDurumId , w.CalisanId , w.CreatedDate , s.Id AS DurumId , s.Durum , p.Id AS PeopleId , p.AdiSoyadi FROM Works w
                                                      LEFT JOIN Status s ON w.StatusId = s.Id
                                                      LEFT JOIN People p ON w.CalisanId = p.Id"
                                                    ).ToList();

            var peopleList = _connection.Query<People>("SELECT * FROM People").ToList();

            


            return View(worksList);
        }
        [HttpGet]
        public IActionResult UpdateWork(int Id) 
        {
            var selectedWork = _connection.QuerySingleOrDefault<Works>("SELECT * FROM Works WHERE Id=@Id", new {Id});
            var peopleList = _connection.Query<People>("SELECT * FROM People").ToList();
            var statusList = _connection.Query<Status>("SELECT * FROM Status").ToList();

            var model = new UpdateWorkViewModel()
            {
                Work = selectedWork,
                People = peopleList,
                Status = statusList
            };

           

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateWork(Works work) 
        {
            var updateWork = _connection.Execute(
                                                    @"UPDATE Works
                                                     SET
                                                     Title=@Title,
                                                     StatusId = @StatusId,
                                                     CalisanId = @CalisanId
                                                     WHERE Id=@Id", new 
                                                    {
                                                        Title = work.Title,
                                                        StatusId = work.StatusId,
                                                        CalisanId = work.CalisanId,
                                                        Id = work.Id
                                                    } 
                                                );

           return RedirectToAction("Index");
        }

        public IActionResult DeleteWork(int Id) 
        {
            var deleteWork = _connection.Execute("DELETE FROM Works WHERE Id=@Id", new {Id});
            return RedirectToAction("Index");
        }



    }
}

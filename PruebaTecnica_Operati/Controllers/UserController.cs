using BibliotecaClases_Operati;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_Operati.Data;
using PruebaTecnica_Operati.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace PruebaTecnica_Operati.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private MSQDbContext MSQcontext;

        public UserController(MSQDbContext context)
        {
            MSQcontext = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return (this.MSQcontext.User.ToList());
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User data)
        {
            using (var dbContextTransaction = MSQcontext.Database.BeginTransaction())
            {
                try
                {
                    MSQcontext.User.Add(data);
                    MSQcontext.SaveChanges();

                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return NotFound("Error, Revisar Datos");
                }
            }
        }

        [HttpGet]
        [Route("treeConstructor")]
        public bool TreeConstructor(string strArr)
        {
            strArr = strArr.Replace("['", "").Replace("']", "");
            string[] strs = Regex.Split(strArr, "','");
            var ClassLibrary = new ClassOperati();
            return ClassLibrary.TreeConstructor(strs);
        }

        [HttpGet]
        [Route("farthestNodes")]
        public int FarthestNodes(string strArr)
        {
            strArr = strArr.Replace("[", "").Replace("]", "");
            string[] strs = Regex.Split(strArr, ",");
            var ClassLibrary = new ClassOperati();
            return ClassLibrary.FarthestNodes(strs);
        }
    }
}

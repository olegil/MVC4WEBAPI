using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class WebApiController : ApiController
    {
        private readonly TestDB _db;
        public WebApiController()
        {
            _db = new TestDB();
            _db.Configuration.ProxyCreationEnabled= false;
        }

        // GET api/webapi
        public IEnumerable<TestModel> GetAllTests()
        {
            return _db.Test;
        }

        // GET api/webapi/5
        public TestModel GetTest(int id)
        {
            var test = _db.Test.Find(id);
            if(test == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return test;
        }

        // POST api/webapi
        public void Post(string value)
        {
        }

        // PUT api/webapi/5
        public HttpResponseMessage PutTest(int id, TestModel test)
        {
            if(ModelState.IsValid && id==test.Id)
            {
                _db.Entry(test).State = EntityState.Modified;
                try
                {
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, test);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/webapi/5
        public void Delete(int id)
        {
        }
    }
}

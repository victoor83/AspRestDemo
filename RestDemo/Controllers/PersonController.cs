using BusinessLayer;
using RestDemo.Models;
using System.Collections.Generic;

using System.Web.Http;

namespace RestDemo.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Person/5
        //[Route(/GibtMirdasGeld")]
        [HttpGet]
        public PersonDto GetFirstPersonByCity(string city)
        {
            var dataProvider = new DataProvider();
            var persons = dataProvider.GetPersonsByCity(city);
            return persons[0];
        }
        //[Route("GetPersonsByCityInJson/{cityy}")]
        [HttpGet]
        public string GetPersonsByCityInJson(string city)
        {
            var dataProvider = new DataProvider();
            return dataProvider.GetPersonsByCityInJson(city);
        }

        // POST: api/Person
        [HttpPost]
        public void Post(Person person)
        {

            var dataProvider = new DataProvider();
            dataProvider.InsertPerson(new PersonDto() { Name = person.Name, City =  person.City, Zip = person.Zip });
        }


        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}

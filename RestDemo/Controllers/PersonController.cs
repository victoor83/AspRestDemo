using BusinessLayer;
using RestDemo.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace RestDemo.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        public PersonDto GetFirstPersonByCity(string city)
        {
            var dataProvider = new DataProvider();
            var persons = dataProvider.GetPersonsByCity(city);
            if (persons.Count == 0)
                return null;
            return persons[0];
        }
        //[Route("GetPersonsByCityInJson/{cityy}")]
        [HttpGet]
        public string GetPersonsByCityInJson(string city)
        {
            var dataProvider = new DataProvider();
            return dataProvider.GetPersonsByCityInJson(city);
        }

        [HttpGet]
        public List<PersonDto> GetAllPersons()
        {
            var dataProvider = new DataProvider();
            return dataProvider.GetAllPersons();
        }

        // POST: api/Person
        [HttpPost]
        public void Post(Person person)
        {
            var dataProvider = new DataProvider();
            dataProvider.InsertPerson(new PersonDto() { Name = person.Name, City =  person.City, Zip = person.Zip, Country = person.Country});
        }


        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        [HttpDelete]
        public void DeleteLastPerson()
        {
            var dataProvider = new DataProvider();
            dataProvider.DeleteLastPerson();
        }
    }
}

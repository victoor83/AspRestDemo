using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class DataProvider
    {
        SqlConnection _connection;
        const string _connectString = @"Data Source=localhost\SQLExpress; Database=Kunden; Trusted_Connection=True";
        public DataProvider()
        {

        }

        public List<PersonDto> GetPersonsByCity(string city)
        {
            return GetPersonsFromDB($"EXEC SelectCustomersFromCity @City = '{city}'", true);
        }

        public string GetPersonsByCityInJson(string city)
        {
            var persons = GetPersonsFromDB($"SELECT CustomerName, City, PostalCode FROM Data WHERE City= '{city}'");
            return JsonConvert.SerializeObject(persons);
        }

        public void InsertPerson(PersonDto person)
        {
            _connection = new SqlConnection(_connectString);
            string sqlCommand = $"INSERT INTO Data(CustomerName, City, PostalCode) VALUES('{person.Name}', '{person.City}', '{person.Zip}')";

            using (_connection)
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, _connection);
                cmd.ExecuteNonQuery();
            }
        }


        private List<PersonDto> GetPersonsFromDB(string sqlCommand, bool isStoredProcedure = false)
        {
            var indexes = new List<ushort>();
            if (isStoredProcedure)
                indexes.AddRange(new ushort[3] { 1, 4, 5 });
            else
                indexes.AddRange(new ushort[3] { 0, 1, 2 });

            List<PersonDto> persons = new List<PersonDto>();

            _connection = new SqlConnection(_connectString);
            using (_connection)
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, _connection);

                SqlDataReader reader = cmd.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    if (reader[i].ToString() == string.Empty)
                        break;

                    var person = new PersonDto();
                    person.Name = reader[indexes[0]].ToString();
                    person.City = reader[indexes[1]].ToString();
                    person.Zip = (int)reader[indexes[2]];
                    persons.Add(person);
                }
                reader.Close();
            }

            return persons;
        }

 
    }
}

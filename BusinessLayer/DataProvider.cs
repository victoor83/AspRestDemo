using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class DataProvider
    {
        SqlConnection _connection;
        const string _connectString = @"workstation id=KundenDB.mssql.somee.com;packet size = 4096; user id = victoor83_SQLLogin_2; pwd=t4fd8jycga;data source = KundenDB.mssql.somee.com; persist security info=False;initial catalog = KundenDB";
            //@"Data Source=localhost\SQLExpress; Database=Kunden; Trusted_Connection=True";
        public DataProvider()
        {

        }

        public List<PersonDto> GetPersonsByCity(string city)
        {
            return GetPersonsFromDB($"EXEC SelectCustomersFromCity @City = '{city}'", true);
        }

        public string GetPersonsByCityInJson(string city)
        {
            var persons = GetPersonsFromDB($"SELECT CustomerName, City, PostalCode, Country FROM Data WHERE City= '{city}'");
            return JsonConvert.SerializeObject(persons);
        }

        public List<PersonDto> GetAllPersons()
        {
            return GetPersonsFromDB($"SELECT CustomerName, City, PostalCode, Country FROM Data");
        }

        public void InsertPerson(PersonDto person)
        {
            _connection = new SqlConnection(_connectString);
            string sqlCommand = $"INSERT INTO Data(CustomerName, City, PostalCode, Country) VALUES('{person.Name}', '{person.City}', '{person.Zip}', '{person.Country}')";

            using (_connection)
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, _connection);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// delete person with max id (last person)
        /// </summary>
        public void DeleteLastPerson()
        {
            _connection = new SqlConnection(_connectString);
            string sqlCommand = $"Delete from Data Where CustomerID = (select Max(CustomerID) From Data)";

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
                indexes.AddRange(new ushort[4] { 1, 4, 5, 6 });
            else
                indexes.AddRange(new ushort[4] { 0, 1, 2, 3 });

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
                    person.Country = reader[indexes[3]].ToString();
                    persons.Add(person);
                }
                reader.Close();
            }

            return persons;
        }

 
    }
}

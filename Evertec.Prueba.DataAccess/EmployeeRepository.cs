using Dapper;
using Dapper.Contrib.Extensions;
using Evertec.Prueba.Models;
using Evertec.Prueba.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Prueba.DataAccess
{
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(string connectionString):base(connectionString){}

        public async  Task<IEnumerable<EmployeeDto>> EmployeePagegList(int page, int rows)
        {
            var parameters = new DynamicParameters();
                parameters.Add("@page", page);
                parameters.Add("@rows",rows);

            using(var connection =  new SqlConnection(_connectionString))
            {
                return  await connection.QueryAsync<EmployeeDto>("dbo.EmployeePagedList",
                                                      parameters,
                                                      commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Employee>> InsertEmployeeAsync(Employee entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                byte[] image = ConvertImageToByte(entity.Photo);

                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@name", entity.Name);
                parameters.Add("@lastname", entity.LastName);
                parameters.Add("@birthday", entity.BirthDate);
                parameters.Add("@photo",image);
                parameters.Add("@maritalstatus",entity.MaritalStatus);
                parameters.Add("@hassiblings", entity.HasSiblings);

                return await connection.QueryAsync<EmployeeDto>("dbo.EmployeeInsert",
                                                      parameters,
                                                      commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return await connection.QueryAsync<EmployeeDto>("dbo.EmployeeGetById",
                                                       parameters,
                                                       commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<Employee>> UpdateEmployeeAsync(Employee entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                byte[] image = ConvertImageToByte(entity.Photo);

                var parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@name", entity.Name);
                parameters.Add("@lastname", entity.LastName);
                parameters.Add("@birthday", entity.BirthDate);
                parameters.Add("@photo", image);
                parameters.Add("@maritalstatus", entity.MaritalStatus);
                parameters.Add("@hassiblings", entity.HasSiblings);
                return await connection.QueryAsync<Employee>("dbo.EmployeeUpdate",
                                                      parameters,
                                                      commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        private byte[] ConvertImageToByte(string imageBase64)
        {

            byte[] imageBytes = Convert.FromBase64String(imageBase64);

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);


            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            /*Paso la Imagen a Stream para guardarla en SQL*/
            MemoryStream ms1 = new MemoryStream();
            image.Save(ms1, ImageFormat.Bmp);

            return ms1.ToArray();

        }
    }
}

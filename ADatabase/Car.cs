using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration.Json;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace ADatabase
{
    public class Car
    {
        public int? Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }

        public void Create(Car carToBeCreated)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open(); using (SqlCommand cmd = new SqlCommand("INSERT INTO Car (Make, Model, Year, Description) " + "VALUES(@Make,@Model,@Year,@Description)" + "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@Make", SqlDbType.NVarChar).Value = carToBeCreated.Make; cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = carToBeCreated.Model;

                    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = carToBeCreated.Year; cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = carToBeCreated.Description; carToBeCreated.Id = Convert.ToInt32(cmd.ExecuteScalar()); cars.Add(carToBeCreated);
                }
            }
        }

        public Car? GetById(int id)
        {
            Car? car = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Make, Model, Year, Description FROM Car WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        car = new Car
                        {
                            Id = dr.GetInt32(0),
                            Make = (string)dr["Make"],
                            Model = (string)dr["Model"],
                            Year = (int?)dr["Year"],
                            Description = (string)dr["Description"]
                        };
                    }
                }
            }
            return car;
        }

        public List<Car> RetrieveAll()
        {
            List<Car> cars = new List<Car>(); using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open(); SqlCommand cmd = new SqlCommand("SELECT Id, Make, Model, Year, Description FROM Car", con); using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car car = new Car

                        { Id = dr.GetInt32(0), Make = (string)dr["Make"], Model = (string)dr["Model"], Year = (int?)dr["Year"], Description = (string)dr["Description"] }; cars.Add(car);
                    }
                }
            }
            return cars;
        }

        public void Update(Car carToBeUpdated) 
        { 
            using (SqlConnection con = new SqlConnection(ConnectionString)) 
            { 
                con.Open(); 
                SqlCommand cmd = new SqlCommand("UPDATE Car SET Make = @Make, Model = @Model, Year = @Year, Description = @Description WHERE Id = @Id", con); 
                cmd.Parameters.Add("@Make", SqlDbType.NVarChar).Value = carToBeUpdated.Make; 
                cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = carToBeUpdated.Model; 
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = carToBeUpdated.Year; 
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = carToBeUpdated.Description; 
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = carToBeUpdated.Id; 
                cmd.ExecuteNonQuery(); 
            } 
        }

        public void Delete(int? id) 
        {
            using (SqlConnection con = new SqlConnection(ConnectionString)) 
            { 
                con.Open(); 
                SqlCommand cmd = new SqlCommand("DELETE FROM Car WHERE Id = @Id", con); 
                cmd.Parameters.AddWithValue("@Id", id); 
                cmd.ExecuteNonQuery(); 
            } 
        }
    }
}

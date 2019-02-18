using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.DAL.Repositorio
{
    public class SeguridadRepositorio
    {
        public string ConsultarMenu()
        {
            string connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI";
            string conn2 = "Data Source=MSSQL1;Initial Catalog=AdventureWorks;Integrated Security=true;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    ////set stored procedure name
                    //string spName = @"dbo.[uspEmployeeInfo]";

                    ////define the SqlCommand object
                    //SqlCommand cmd = new SqlCommand(spName, conn);

                    ////Set SqlParameter - the employee id parameter value will be set from the command line
                    //SqlParameter param1 = new SqlParameter();
                    //param1.ParameterName = "@employeeID";
                    //param1.SqlDbType = SqlDbType.Int;
                    //param1.Value = int.Parse(args[0].ToString());

                    ////add the parameter to the SqlCommand object
                    //cmd.Parameters.Add(param1);

                    ////open connection
                    //conn.Open();

                    ////set the SqlCommand type to stored procedure and execute
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //SqlDataReader dr = cmd.ExecuteReader();

                    //Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    //Console.WriteLine("Retrieved records:");

                    ////check if there are records
                    //if (dr.HasRows)
                    //{
                    //    while (dr.Read())
                    //    {
                    //        empID = dr.GetInt32(0);
                    //        empCode = dr.GetString(1);
                    //        empFirstName = dr.GetString(2);
                    //        empLastName = dr.GetString(3);
                    //        locationCode = dr.GetString(4);
                    //        locationDescr = dr.GetString(5);

                    //        //display retrieved record
                    //        Console.WriteLine("{0},{1},{2},{3},{4},{5}", empID.ToString(), empCode, empFirstName, empLastName, locationCode, locationDescr);
                    //    }
                    //}

                    ////close data reader
                    //dr.Close();

                    ////close connection
                    //conn.Close();

                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
            return "funciona";
        }
    }
}

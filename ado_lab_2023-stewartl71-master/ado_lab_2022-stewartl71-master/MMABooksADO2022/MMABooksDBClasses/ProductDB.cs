using MMABooksBusinessClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.UnitPrice = (Nullable<decimal>)prodReader["UnitPrice"];
                    product.OnHandQuantity = (Nullable<int>)prodReader["OnHandQuantity"];
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@Description", product.Description);
            insertCommand.Parameters.AddWithValue(
                "@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue(
                "@OnHandQuantity", product.OnHandQuantity);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                // MySQL specific code for getting last pk value
                string selectStatement =
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                string productCode = Convert.ToInt32(selectCommand.ExecuteScalar()).ToString();
                return productCode;
                /*
                connection.Open();
                insertCommand.ExecuteNonQuery();
                // MySQL specific code for getting last pk value
                string selectStatement =
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                string productCode = (selectCommand.ExecuteScalar()).ToString();
                return productCode;
                */
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            // get a connection to the database
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @Description " +
                "AND UnitPrice = @UnitPrice " +
                "AND OnHandQuantity = @OnHandQuantity ";
            // set up the command object
            MySqlCommand deleteCommand =
                new MySqlCommand(deleteStatement, connection);

            try
            {
                // open the connection
                connection.Open();
                // execute the command
                int rows = deleteCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
                if (rows == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }

            return false;
        }

        public static bool UpdateProduct(Product oldProduct,
            Product newProduct)
        {
            // create a connection
            MySqlConnection connection = MMABooksDB.GetConnection();

            string updateStatement =
                "UPDATE Products SET " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity, " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND UnitPrice = @OldUnitPrice " +
                "AND OnHandQuantity = @OldOnHandQuantity ";
            // setup the command object
            MySqlCommand updateCommand =
                new MySqlCommand(updateStatement, connection);
            try
            {
                // open the connection
                connection.Open();
                // execute the command
                int rows = updateCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
                if (rows == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }

            return false;
        }
    }
}

// <copyright file="DBEngine.cs" company="Mazarin (Pvt) Ltd.">
// Copyright (c) Mazarin (Pvt) Ltd.. All Rights Reserved.
// .
// </copyright>

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Skylift.Core.DomainModels;
using Skylift.Core.Extensions;
using Skylift.Core.Utilities;

namespace Skylift.Infrastructure.Helpers
{
    /// <summary>
    /// DB Engine
    /// </summary>
    public class DBEngine
    {
        #region Instance Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="DBEngine"/> class.
        /// </summary>
        /// <param name="configuration">configuration</param>
        /// <param name="logger">logger</param>
        public DBEngine(IConfiguration configuration, ILogger logger)
        {
            this.IsSuccess = true;
            this.Configuration = configuration;
            this.Logger = logger;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        private ILogger Logger { get; }

        #endregion

        /// <summary>
        /// Gets the data adapter.
        /// </summary>
        /// <returns>Sql Data Adapter.</returns>
        public static MySqlDataAdapter GetDataAdapter()
        {
            MySqlDataAdapter adapter = null;
            adapter = new MySqlDataAdapter();
            return adapter;
        }

        /// <summary>
        /// Convert Data Tables
        /// </summary>
        /// <param name="dataTableList">The data table list</param>
        /// <param name="typelist">The type list</param>
        /// <returns>List of object lists</returns>
        public static List<List<object>> ConvertDataTablesToList(List<DataTable> dataTableList, List<Type> typelist)
        {
            int index = 0;
            List<List<object>> resultList = new List<List<object>>();
            foreach (DataTable item in dataTableList)
            {
                Type typeObject = typelist[index];

                Type ex = typeof(ObjectHelper);
                MethodInfo methodInfo = ex.GetMethod("MapDataTableToObject");
                MethodInfo methodInfoConstructed = methodInfo.MakeGenericMethod(typeObject);
                object[] args = { item };
                object resultObjectList = methodInfoConstructed.Invoke(null, args);

                resultList.Add((List<object>)resultObjectList);
                ++index;
            }

            return resultList;
        }

        /// <summary>
        /// Get the database connection
        /// </summary>
        /// <param name="connection">MySql Connection</param>
        /// <returns>True or False</returns>
        public bool GetConnection(ref MySqlConnection connection)
        {
            try
            {
                connection.ConnectionString = this.Configuration.GetConnectionString("DefaultConnection");

                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.IsSuccess = false;
                this.Logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                  FullName + ": " + "Creating the conection "));
                return false;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="requestParameterList">The request parameter list.</param>
        /// <returns>object typed list</returns>
        public PagedList<T> GetData<T>(string storedProcedureName, List<RequestParameter> requestParameterList)
        {
            List<DataTable> returnTables = this.GetDataToTable(storedProcedureName, requestParameterList);
            List<T> objectList = ObjectHelper.ConvertDataTable<T>(returnTables[0]);

            PagedList<T> resultList = new PagedList<T>
            {
                Items = objectList
            };

            if (returnTables.Count > 1 && returnTables[1] != null && returnTables[1].Rows.Count > 0)
            {
                resultList.TotalRecordCount = (int)returnTables[1].Rows[0][0];
            }

            return resultList;
        }

        /// <summary>
        /// Gets the data list.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="requestParameterList">The request parameter list.</param>
        /// <returns>object list</returns>
        public List<T> GetDataList<T>(string storedProcedureName, List<RequestParameter> requestParameterList)
        {
            List<DataTable> returnTables = this.GetDataToTable(storedProcedureName, requestParameterList);
            if (this.IsSuccess)
            {
                return ObjectHelper.ConvertDataTable<T>(returnTables[0]);
            }
            else
            {
                return new List<T>();
            }
        }

        /// <summary>
        /// Gets the data list without parameters.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <returns>
        /// object list
        /// </returns>
        public List<T> GetDataListWithoutParameters<T>(string storedProcedureName)
        {
            List<DataTable> returnTables = this.GetDataToTableWithOutParameters(storedProcedureName);
            if (this.IsSuccess)
            {
                return ObjectHelper.ConvertDataTable<T>(returnTables[0]);
            }
            else
            {
                return new List<T>();
            }
        }

        /// <summary>
        /// Saving data
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="requestParameterList">The request parameter list.</param>
        /// <returns>
        /// return update count
        /// </returns>
        public int SaveData(string storedProcedureName, List<RequestParameter> requestParameterList)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = new MySqlConnection();
            int rowCount = 0;
            int count = 0;

            if (requestParameterList != null && requestParameterList.Count > 0)
            {
                for (count = 0; count < requestParameterList.Count; count++)
                {
                    command.Parameters.Add(new MySqlParameter(
                        requestParameterList[count].ParameterName,
                        requestParameterList[count].ParameterValue));
                }
            }

            if (this.GetConnection(ref connection))
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.CommandTimeout = 0;
                    object identityValue = command.ExecuteScalar();
                    if (identityValue != DBNull.Value)
                    {
                        rowCount = Convert.ToInt32(identityValue, CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception ex)
                {
                    this.Exception = ex;
                    this.IsSuccess = false;
                    this.Logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                  FullName + ": " + "Failed saving"));
                }
                finally
                {
                    if (connection.State.Equals(ConnectionState.Open))
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return rowCount;
        }

        /// <summary>
        /// Saving data
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="requestParameterList">The request parameter list.</param>
        /// <returns>
        /// return update count
        /// </returns>
        public int SaveDataWithRetry(string storedProcedureName, List<RequestParameter> requestParameterList)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = new MySqlConnection();
            int rowCount = 0;
            int count = 0;
            int totalNumberOfTimesToTry = 4;
            int retryIntervalSeconds = 10;

            if (requestParameterList != null && requestParameterList.Count > 0)
            {
                for (count = 0; count < requestParameterList.Count; count++)
                {
                    command.Parameters.Add(new MySqlParameter(
                        requestParameterList[count].ParameterName,
                        requestParameterList[count].ParameterValue));
                }
            }

            for (int tries = 1; tries <= totalNumberOfTimesToTry; tries++)
            {
                if (tries > 1)
                {
                    System.Threading.Thread.Sleep(1000 * retryIntervalSeconds);
                    retryIntervalSeconds = Convert.ToInt32(retryIntervalSeconds * 1.5);
                }

                if (this.GetConnection(ref connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = storedProcedureName;
                        command.CommandTimeout = 0;
                        object identityValue = command.ExecuteScalar();
                        if (identityValue != DBNull.Value)
                        {
                            rowCount = Convert.ToInt32(identityValue, CultureInfo.InvariantCulture);
                            this.IsSuccess = true;
                        }

                        break;
                    }
                    catch (MySqlException ex)
                    {
                        this.Exception = ex;
                        this.IsSuccess = false;
                        this.Logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                        FullName + ": " + "Failed saving"));
                    }
                    catch (Exception ex)
                    {
                        this.Exception = ex;
                        this.IsSuccess = false;
                        this.Logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                      FullName + ": " + "Failed saving"));
                    }
                    finally
                    {
                        if (connection.State.Equals(ConnectionState.Open))
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                    }
                }
            }

            return rowCount;
        }

        /// <summary>
        /// Saving data with out put parameters
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="inputParameterList">The input parameter list.</param>
        /// <param name="outputParameterList">The output parameter list.</param>
        /// <returns>
        /// return output value list
        /// </returns>
        public Dictionary<string, object> SaveDataWithOutPutParameters(string storedProcedureName, List<RequestParameter> inputParameterList, List<RequestParameter> outputParameterList)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlTransaction transaction;
            MySqlConnection connection = new MySqlConnection();
            Dictionary<string, object> resultList = new Dictionary<string, object>();

            if (inputParameterList != null && inputParameterList.Count > 0)
            {
                foreach (RequestParameter inputParameter in inputParameterList)
                {
                    command.Parameters.Add(new MySqlParameter(
                        inputParameter.ParameterName, inputParameter.ParameterValue));
                }
            }

            if (outputParameterList != null && outputParameterList.Count > 0)
            {
                foreach (RequestParameter outputParameter in outputParameterList)
                {
                    MySqlParameter sqlParameter = new MySqlParameter(
                        outputParameter.ParameterName, outputParameter.ParameterValue)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(sqlParameter);
                }
            }

            if (this.GetConnection(ref connection))
            {
                transaction = connection.BeginTransaction();
                try
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    foreach (RequestParameter outputParameter in outputParameterList)
                    {
                        resultList.Add(outputParameter.ParameterName, command.Parameters[outputParameter.ParameterName].Value);
                    }
                }
                catch (Exception ex)
                {
                    if (connection.State.Equals(ConnectionState.Open))
                    {
                        transaction.Rollback();
                    }

                    this.Exception = ex;
                    this.IsSuccess = false;
                    this.Logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                  FullName + ": "));
                }
                finally
                {
                    if (connection.State.Equals(ConnectionState.Open))
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// Get Data With Output Parameters.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="inputParameterList">The input parameter list.</param>
        /// <param name="typelist">the type list</param>
        /// <param name="outputParameterList">The output parameter list.</param>
        /// <returns>object typed list</returns>
        public List<List<object>> GetDataWithOutputParameters(
            string storedProcedureName,
            List<RequestParameter> inputParameterList,
            List<Type> typelist,
            ref List<RequestParameter> outputParameterList)
        {
            List<List<object>> resultList = new List<List<object>>();
            List<DataTable> returnTables = this.GetDataToTableWithParameters(storedProcedureName, inputParameterList, ref outputParameterList);

            resultList = ConvertDataTablesToList(returnTables, typelist);

            return resultList;
        }

        /// <summary>
        /// Get results to a data table
        /// </summary>
        /// <param name="storedProcedureName">SP Name</param>
        /// <param name="requestParameterList">Parameter list</param>
        /// <returns>Data Table</returns>
        private List<DataTable> GetDataToTable(string storedProcedureName, List<RequestParameter> requestParameterList)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = new MySqlConnection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            int count = 0;
            List<DataTable> dataTables = null;

            if (requestParameterList != null && requestParameterList.Count > 0)
            {
                for (count = 0; count < requestParameterList.Count; count++)
                {
                    command.Parameters.Add(new MySqlParameter(
                        requestParameterList[count].ParameterName,
                        requestParameterList[count].ParameterValue));
                }
            }

            try
            {
                if (this.GetConnection(ref connection))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.CommandTimeout = 0;
                    DataSet dataSet = new DataSet();
                    dataAdapter = new MySqlDataAdapter(command);
                    dataAdapter.Fill(dataSet);
                    dataTables = new List<DataTable>(dataSet.Tables.Cast<DataTable>());
                }
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.IsSuccess = false;
                this.Logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                  FullName + ": "));
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return dataTables;
        }

        /// <summary>
        /// Get results to a data table
        /// </summary>
        /// <param name="storedProcedureName">SP Name</param>
        /// <param name="inputParameterList">input Parameter list</param>
        /// <param name="outputParameterList">output Parameter list</param>
        /// <returns>Data Table</returns>
        private List<DataTable> GetDataToTableWithParameters(
            string storedProcedureName,
            List<RequestParameter> inputParameterList,
            ref List<RequestParameter> outputParameterList)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = new MySqlConnection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            List<DataTable> dataTables = null;

            if (inputParameterList != null && inputParameterList.Count > 0)
            {
                foreach (RequestParameter inputParameter in inputParameterList)
                {
                    command.Parameters.Add(new MySqlParameter(inputParameter.ParameterName, inputParameter.ParameterValue));
                }
            }

            if (outputParameterList != null && outputParameterList.Count > 0)
            {
                foreach (RequestParameter outputParameter in outputParameterList)
                {
                    MySqlParameter sqlParameter = new MySqlParameter(
                        outputParameter.ParameterName,
                        outputParameter.ParameterValue)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(sqlParameter);
                }
            }

            try
            {
                if (this.GetConnection(ref connection))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.CommandTimeout = 0;
                    DataSet dataSet = new DataSet();
                    dataAdapter = new MySqlDataAdapter(command);
                    dataAdapter.Fill(dataSet);
                    dataTables = new List<DataTable>(dataSet.Tables.Cast<DataTable>());

                    foreach (RequestParameter outputParameter in outputParameterList)
                    {
                        outputParameter.ParameterValue = command.Parameters[outputParameter.ParameterName].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.IsSuccess = false;
                this.Logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                  FullName + ": "));
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return dataTables;
        }

        private List<DataTable> GetDataToTableWithOutParameters(string storedProcedureName)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = new MySqlConnection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            List<DataTable> dataTables = null;

            try
            {
                if (this.GetConnection(ref connection))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.CommandTimeout = 0;
                    DataSet dataSet = new DataSet();
                    dataAdapter = new MySqlDataAdapter(command);
                    dataAdapter.Fill(dataSet);
                    dataTables = new List<DataTable>(dataSet.Tables.Cast<DataTable>());
                }
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.IsSuccess = false;
                this.Logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                  FullName + ": "));
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return dataTables;
        }

        #endregion
    }
}

using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HourlySalesService
{
    public class DataAccess
    {
        /// <summary>
        /// Holds the connection string
        /// </summary>
        String strConnectionString = String.Empty;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataAccess()
        {
            loadConnectionString();
        }

        /// <summary>
        /// Adds or updates an HourlyRecord in the DB
        /// </summary>
        /// <param name="record"></param>
        public void addHourlyRecord(HourlyRecordModel record)
        {
            DynamicParameters paramaters = new DynamicParameters();
            paramaters.Add("@RestNum", record.RestNum);
            paramaters.Add("@BusinessHour", record.BusinessHour.ToString("yyyy-MM-dd HH:mm:ss.fff"), DbType.DateTime, ParameterDirection.Input);
            paramaters.Add("@Sales", record.Sales);
            paramaters.Add("@DestCode", record.DestCode);
            paramaters.Add("@PayType", record.PayType);

            using (IDbConnection db = new SqlConnection(strConnectionString))
            {
                db.Execute("LeeMiller.spInsertOrUpdate", paramaters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Loads connection string from the App.config.json file
        /// </summary>
        private void loadConnectionString()
        {
            strConnectionString = JsonConvert.DeserializeObject<ConfigurationModel>(File.ReadAllText(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "")) + "App.config.json")).TransactionsConnectionString;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace HourlySalesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HourlySalesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HourlySalesService.svc or HourlySalesService.svc.cs at the Solution Explorer and start debugging.
    
    /// <summary>
    /// HourlySalesService class
    /// </summary>
    public class HourlySalesService : IHourlySalesService
    { 
        DataAccess dataAccess = new DataAccess();

        /// <summary>
        /// Takes the received Retaurants Sales object, creates the HourlyRecordModel objects then sends them to the DataAccess layer
        /// </summary>
        /// <param name="sales">Incoming Sales object</param>
        /// <returns>The Restaurant # that was received</returns>
        public int UploadData(RestaurantSales sales)
        {
            foreach(Channel channel in sales.Channels)
            {
                foreach(Pay pay in channel.PayTypes)
                {
                    try
                    {
                        HourlyRecordModel hourlyRecord = new HourlyRecordModel();
                        hourlyRecord.RestNum = sales.RestNumber;
                        hourlyRecord.setBusinsessHourFromArray(sales.BusinessHour.ToArray());
                        hourlyRecord.Sales = Decimal.Parse(pay.Sales);
                        hourlyRecord.DestCode = channel.DestCode;
                        hourlyRecord.PayType = pay.PayType;
                        if(hourlyRecord.propertiesNotNull())
                        {
                            dataAccess.addHourlyRecord(hourlyRecord);
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            return sales.RestNumber;
        }
    }
}

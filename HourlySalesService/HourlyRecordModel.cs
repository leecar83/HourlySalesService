using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HourlySalesService
{
    /// <summary>
    /// Class holding sales data for an hourly period
    /// </summary>
    public class HourlyRecordModel
    {
        /// <summary>
        /// Holds the Restaurant Number
        /// </summary>
        public int RestNum { get; set; }

        /// <summary>
        /// Holds the business hour of the sales data (yyyy-MM-dd HH:mm:ss.fff). Since we are doing this by hour period they
        /// should always been an hour with no minutes or seconds. EX 2017-12-21 00:00:00.000 or 2017-12-21 23:00:00.000
        /// </summary>
        public DateTime BusinessHour { get; set; }

        /// <summary>
        /// Amount of sales for the hour
        /// </summary>
        public Decimal Sales { get; set; }

        /// <summary>
        /// Holds the code representing the destination or channel. Something like drive-thru, inhouse, delivery
        /// </summary>
        public String DestCode { get; set; }

        /// <summary>
        /// Holds the pay code. Represents something like Cash, Visa, Gift, or Uber
        /// </summary>
        public String PayType { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HourlyRecordModel()
        {

        }

        /// <summary>
        /// Takes in an array representing the year, month, day and hour and sets the BusinessHour property
        /// Example would be
        /// [0] Year
        /// [1] Month
        /// [2] Day
        /// [3] Hour
        /// </summary>
        /// <param name="businessHour">Array represting the business hour</param>
        public void setBusinsessHourFromArray(int [] businessHour)
        {
            DateTime hourPeriod = new DateTime(businessHour[0], businessHour[1], businessHour[2], businessHour[3], 0, 0);
            BusinessHour = hourPeriod;
        }

        /// <summary>
        /// Returns a Boolean value indicating if any of the properties of the object are NULL
        /// </summary>
        /// <returns>Boolean</returns>
        public bool propertiesNotNull()
        {
            bool bReturn = false;
            bReturn = this.GetType().GetProperties()
                            .All(p => p.GetValue(this) != null);
            return bReturn;
        }
    }
}
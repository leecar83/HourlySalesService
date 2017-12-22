using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace HourlySalesService
{
    /// <summary>
    /// IHourlySalesInterface contract
    /// </summary>
    [ServiceContract]
    public interface IHourlySalesService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/UploadData/", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        int UploadData(RestaurantSales sales);
    }

    /// <summary>
    /// RetaurantSales Class
    /// </summary>
    [DataContract]
    public class RestaurantSales
    {
        /// <summary>
        /// Restaurant Number
        /// </summary>
        [DataMember(IsRequired = true)]
        [JsonProperty(Order = 1)]
        public int RestNumber { get; set; }

        /// <summary>
        /// Business Hour
        /// </summary>
        [DataMember(IsRequired = true)]
        [JsonProperty(Order = 2)]
        public List<int> BusinessHour { get; set; }

        /// <summary>
        /// List of Channels or Destination Types
        /// </summary>
        [DataMember(IsRequired = true)]
        [JsonProperty(Order = 3)]
        public List<Channel> Channels { get; set; }
    }

    /// <summary>
    /// Channel Class
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// Destination Code or Channel
        /// </summary>
        [DataMember(IsRequired = true)]
        [JsonProperty(Order = 1)]
        public string DestCode { get; set; }

        /// <summary>
        /// List of paytypes for the channel
        /// </summary>
        [DataMember(IsRequired = true)]
        [JsonProperty(Order = 2)]
        public List<Pay> PayTypes { get; set; }
    }

    /// <summary>
    /// Pay Class
    /// </summary>
    public class Pay
    {
        /// <summary>
        /// Paytype
        /// </summary>
        [DataMember(IsRequired = true)]
        [JsonProperty(Order = 1)]
        public string PayType { get; set; }

        /// <summary>
        /// The sales for the paytype
        /// </summary>
        [DataMember(IsRequired = true)]
        [JsonProperty(Order = 2)]
        public String Sales { get; set; }
    }
}

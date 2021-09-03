using Newtonsoft.Json;

namespace Yamcs.Shared.Models
{
    public class SubscribeTMStatisticsRequest 
    {

        public SubscribeTMStatisticsRequest(string _instance, string _processor)
        {
            //options = this;
            instance = _instance;
            processor = _processor;
        }

     
        public string instance { set; get; }

        public string processor { set; get; }

      
    }




}

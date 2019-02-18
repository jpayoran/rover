using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RoverAppWeb.Models;
using System.Configuration;


/// <summary>
/// Rover Main class
/// </summary>

namespace RoverAppWeb.Classes
{
    public class RoverClass
    {
        private string url = ConfigurationManager.AppSettings["RoverURL"];

        public RoverClass()
        {
        }

        public RoverObject QueryRoverObject(DateTime queryDate)
        {
            string jsonResponse;
            RoverObject rover = null;

            try
            {
                url = string.Format(url, queryDate.ToString("yyyy-MM-dd"));
                jsonResponse = Util.GetCallAPI(url);
                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    rover = JsonConvert.DeserializeObject<RoverObject>(jsonResponse);
                }
            }
            catch(Exception)
            {
            }

            return rover;
        }


    }
}

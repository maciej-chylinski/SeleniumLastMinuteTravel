using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebDriverWrapper
{
    public class SeleniumWrapper
    {
        public void ParseJson(string json)
        {
            var outJsonObject = JObject.Parse(json);
                

            if ((bool)outJsonObject["LikeThisCourse"])
            {
                var firstName = (string)outJsonObject["FirstName"];
                //key in key FirstName of Mother and Father: ["FirstName.MotherName"]
                var lastName = (string)outJsonObject["LastName"];
                var age = (int)outJsonObject["Age"];
            }

        }

    }
}

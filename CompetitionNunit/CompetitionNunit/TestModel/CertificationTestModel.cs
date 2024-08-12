using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionNunit.TestModel
{
    public class CertificationTestModel
    {


#pragma warning disable
        public string Certificate { get; set; }

        [JsonProperty("Certified From")]
        public string CertifiedFrom { get; set; }
        public string Year { get; set; }



    }



}

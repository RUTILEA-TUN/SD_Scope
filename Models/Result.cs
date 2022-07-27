using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Scope.Models
{
    public class Result
    {
        public int ProductId { get; set; }
        public Inspection Inspection { get; set; }
        public DateTime PutInTime { get; set; }
        public DateTime RemoveTime { get; set; }
        public DateTime CountTime { get; set; }
        public string Status { get; set; }
        public int Detail { get; set; }
        public string DetailName { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public float Light { get; set; }
        public float Noise { get; set; }
        public float Acceleration { get; set; }
        public float eTOVC { get; set; }

        //public Inspection
        public Result()
        {

        }
    }
    

}

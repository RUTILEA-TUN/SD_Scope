using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Scope.Models
{
    public class Inspection
    {
        public int InspecttionId { get; set; }
        public string EmployeeNum { get; set; }
        public string ProductCode { get; set; }
        public string LotNumber { get; set; }
        public int PlannedNumber { get; set; }
        public int InspectedNumber  { get; set; }
        public int DefectiveNumber { get; set; }
        public float CycleTime { get; set; }
        public string OfficeHrs { get; set; }
        public string OfficeHrsStart { get; set; }
        public string OfficeHrsEnd { get; set; }
        public string FirstRestStart { get; set; }
        public string FirstRestEnd { get; set; }
        public string SecondRestStart { get; set; }
        public string SecondRestEnd { get; set; }
        public string ThirdRestStart { get; set; }
        public string ThirdRestEnd { get; set; }
        public bool AnxietyInstructions { get; set; }
        public bool AnxietyLocation { get; set; }
        public bool AnxietyHighTemp { get; set; }
        public bool AnxietyLowTemp { get; set; }
        public bool AnxietyIlluminance { get; set; }
        public bool AnxietyProcedure { get; set; }
        public string Version { get; set; }
        public List<Result> Results { get; set; }


        public Inspection(int inspecttionId, string employeeNum, string productCode)
        {
            InspecttionId = inspecttionId;
            EmployeeNum = employeeNum;
            ProductCode = productCode;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Scope.Models
{
    internal class PreInspection
    {
        

        public string EmployeeId { get; set; }
        public string LotNumber { get; set; }
        public int PlannedNumber { get; set; }
        public string ItemID { get; set; }

        /*public PreInspection()
        {

        }*/
        public PreInspection(string employeeId, string lotNumber, int plannedNumber, string itemID)
                {
                    EmployeeId = employeeId;
                    LotNumber = lotNumber;
                    PlannedNumber = plannedNumber;
                    ItemID = itemID;
                }


    }
}

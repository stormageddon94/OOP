using System;
using System.Collections.Generic;
using System.Text;

namespace BoarderControl
{
    public class Robot : IId
    {
        public Robot(string idNumber, string model)
        {
            this.IdNumber = idNumber;
            this.Model = model;
        }
        public string IdNumber { get; set; }
        public string Model { get; set; }

        //public bool IsIdFake(string endNumbers)
        //{
        //    if (this.IdNumber.EndsWith(endNumbers))
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}

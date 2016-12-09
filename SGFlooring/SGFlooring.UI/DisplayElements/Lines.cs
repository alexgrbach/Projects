using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI.DisplayElements
{
    public class Lines
    {
        
        public string DrawLine(LineTypes lineType)
        {
            switch (lineType)
            {
                case LineTypes.Stars:
                    return "***********************************************";
                case LineTypes.Equals:
                    return "===============================================";
                case LineTypes.UnderScore:
                    return "_______________________________________________";
                case LineTypes.Fishy:
                    return " <º)))><¸.·´¯`·.¸.·´¯`·.´¯`·.¸¸.·´¯`·.¸><(((º> ";
                default:
                    
                    return "ERRORDAMMIT!";
            }
        }
    }
}


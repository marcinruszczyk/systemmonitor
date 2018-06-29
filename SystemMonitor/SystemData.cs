using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace SystemMonitor
{
    class SystemData
    {
       


        public string GetComponentName(string win32string, string what)
        {
            string name = String.Empty;
            ManagementClass mgmt = new ManagementClass(win32string);  
            ManagementObjectCollection objCol = mgmt.GetInstances();

            foreach (ManagementObject obj in objCol)
            {
                if (name == String.Empty)
                {
                    name = obj.Properties[what].Value.ToString();  
                }
            }
            return name;
        }
               

    }
}

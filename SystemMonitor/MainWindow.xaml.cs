using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Threading;
using System.Data;

namespace SystemMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
              

        public MainWindow()
        {
            
            InitializeComponent();  
            


            SystemData sysdata = new SystemData();
            txt_proc.Text = sysdata.GetComponentName("Win32_Processor", "Name").ToString();
            txt_load.Text = sysdata.GetComponentName("Win32_Processor", "LoadPercentage").ToString();
            txt_speed.Text = sysdata.GetComponentName("Win32_Processor", "MaxClockSpeed").ToString();
            txt_num_of_cores.Text = sysdata.GetComponentName("Win32_Processor", "NumberOfCores").ToString();
            txt_logical.Text = sysdata.GetComponentName("Win32_Processor", "NumberOfLogicalProcessors").ToString();
            txt_graphics.Text = sysdata.GetComponentName("Win32_VideoController", "Name").ToString();
            
            txt_driver.Text = sysdata.GetComponentName("Win32_VideoController", "DriverVersion").ToString();
            txt_driverdata.Text = sysdata.GetComponentName("Win32_VideoController", "DriverDate").ToString();

            txt_battery.Text = sysdata.GetComponentName("Win32_Battery", "EstimatedChargeRemaining").ToString();
            txt_name.Text = sysdata.GetComponentName("Win32_Battery", "Name").ToString();
            txt_sound.Text = sysdata.GetComponentName("Win32_SoundDevice", "Name").ToString();
            txt_madeby.Text = sysdata.GetComponentName("Win32_SoundDevice", "Manufacturer").ToString();
            

           
            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = Decimal.Round(((decimal)phav / (decimal)tot) * 100 )  ;
            decimal percentOccupied = Decimal.Round(100 - percentFree);

            txt_access_mem.Text = phav.ToString();
            txt_total_mem.Text = tot.ToString();
            txt_free_mem.Text = percentFree.ToString();
            txt_busy_mem.Text = percentOccupied.ToString();
          


            OperatingSystem os = Environment.OSVersion;
            string syswerstr = os.VersionString.ToString();
            txt_system.Text = syswerstr;

            

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(200);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();




        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            SystemData sysdata = new SystemData();
            string load = sysdata.GetComponentName("Win32_Processor", "LoadPercentage").ToString();
            txt_load.Text = load;
        }

               
    }
}




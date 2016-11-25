using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puntoVentaModelo.Modelos
{
    public class modeloComputadora
    {

        public  PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

        public string getNombreMaquina()
        {
            try
            {
                string nombre = "";
                nombre = Environment.MachineName.ToString();
                return nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNombreMaquina.: " + ex.ToString());
                return null;
            }

        }

        public void apagarMaquina()
        {
            System.Diagnostics.Process.Start("shutdown", @"/s/m");
        }

    }
}

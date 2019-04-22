using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DebugTask.Service
{
    public class Generator
    {
        public void DoMagic()
        {
            var buf = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
            byte[] addressBytes = buf.GetPhysicalAddress().GetAddressBytes();
            byte[] timeBytes = BitConverter.GetBytes(DateTime.Now.Date.ToBinary());
            //V_12.a = BitConverter.GetBytes(DateTime.Now.Date.ToBinary());
            //int[] source = addressBytes.Select(V_12.eval_a).Select(<> c.<> 9.eval_a).ToArray();
            //V_12.b = A_0.Select(int.Parse).ToArray();
            //return source.Select(V_12.eval_a).All(<> c.<> 9.eval_b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DebugTask
{
    public class Generator
    {
        private byte[] dateAsBytes;
        private int[] inputAsArray;

        public bool Parse(string[] input)
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();

            byte[] addressBytes = networkInterface.GetPhysicalAddress().GetAddressBytes();

            dateAsBytes = BitConverter.GetBytes(DateTime.Now.Date.ToBinary());

            int[] array = addressBytes.Select(EvalBytes).Select(elem =>
            {
                if (elem <= 999)
                {
                    return elem * 10;
                }
                return elem;
            }).ToArray();

            inputAsArray = input.Select(int.Parse).ToArray();

            return array.Select(this.EvalInt).All(elem => elem == 0);
        }

        public string Generate()
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();

            byte[] addressBytes = networkInterface.GetPhysicalAddress().GetAddressBytes();

            dateAsBytes = BitConverter.GetBytes(DateTime.Now.Date.ToBinary());

            var array = addressBytes.Select(EvalBytes).Select(elem =>
            {
                if (elem <= 999)
                {
                    return elem * 10;
                }

                return elem;
            }).ToArray();

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString());
                if (i != array.Length - 1)
                {
                    stringBuilder.Append('-');
                }
            }

            return stringBuilder.ToString();
        }

        internal int EvalBytes(byte a0, int a1)
        {
            return a0 ^ dateAsBytes[a1];
        }

        internal int EvalInt(int a0, int a1)
        {
            return a0 - inputAsArray[a1];
        }
    }
}

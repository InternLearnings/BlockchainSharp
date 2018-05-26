namespace BlockchainSharp.Tests.TestUtils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HexUtils
    {
        public static byte[] StringToByteArray(string hex)
        {
            int nchars = hex.Length;
            byte[] bytes = new byte[nchars / 2];

            for (int k = 0; k < nchars; k += 2)
                bytes[k / 2] = Convert.ToByte(hex.Substring(k, 2), 16);

            return bytes;
        }
    }
}

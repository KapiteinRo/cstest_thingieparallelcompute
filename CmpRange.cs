using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSTestParallelComputeThingie
{
    public class CmpRange
    {
        /// <summary>
        /// Compare ranges, and compute compatibility.
        /// </summary>
        /// <param name="iThis"></param>
        /// <param name="iThat"></param>
        /// <returns>Percentage of compatibility</returns>
        public static float Compare(int iThis, int iThat)
        {
            if (iThis == iThat)
                return 100f;
            float fHi = (float)(iThis > iThat ? iThis : iThat);
            float fLo = (float)(iThis > iThat ? iThat : iThis);
            return 100 - ((((fLo - ((fHi / 2) + 7)) / fHi) * 100) * -1);
        }
    }
}

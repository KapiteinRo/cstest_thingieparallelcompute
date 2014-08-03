using System;
using System.Collections.Generic;

namespace CSTestParallelComputeThingie
{
    public class RangeFinder
    {
        /// <summary>
        /// Generate list
        /// </summary>
        /// <param name="iLo"></param>
        /// <param name="iHi"></param>
        /// <returns></returns>
        public static IEnumerable<int> View(int iLo, int iHi)
        {
            for (int i = iLo; i < iHi; i++)
                yield return i;
        }
    }
}

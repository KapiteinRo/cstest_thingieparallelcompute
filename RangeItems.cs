using System;
using System.Text;
using System.Collections.Generic;

namespace CSTestParallelComputeThingie
{
    /// <summary>
    /// Item..
    /// </summary>
    public class RangeItem
    {
        /// <summary>
        /// Parent value
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Highest value
        /// </summary>
        public int HI { get; set; }
        /// <summary>
        /// Lowest value
        /// </summary>
        public int LO { get; set; }
        
        public void Compute(float fLimit)
        {
            // first, fill range
            List<int> liCompareWith = new List<int>(RangeFinder.View(LO, HI));
            LO = -1;
            HI = -1;
            // now walk through them
            foreach (int i in liCompareWith)
            {
                // if it is higher than the limit, fill HI and/or LO
                if (CmpRange.Compare(Value, i) >= fLimit)
                {
                    if (LO == -1)
                        LO = i;
                    HI = i;
                }
            }
        }

        /// <summary>
        /// Creates CSV record.
        /// </summary>
        /// <returns></returns>
        public string ToCSVString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\"").Append(Value).Append("\";");
            sb.Append("\"").Append(LO).Append("\";");
            sb.Append("\"").Append(HI).Append("\"\r\n");

            return sb.ToString();
        }
    }

    /// <summary>
    /// All the items
    /// </summary>
    public class RangeItems : List<RangeItem>
    {
        /// <summary>
        /// Initialise
        /// </summary>
        /// <param name="iLo"></param>
        /// <param name="iHi"></param>
        public RangeItems(int iLo, int iHi)
        {
            foreach (int i in RangeFinder.View(iLo, iHi))
                this.Add(new RangeItem { Value = i, LO = iLo, HI = iHi });
        }

        /// <summary>
        /// Build CSV header
        /// </summary>
        /// <returns></returns>
        public string BuildCSVHeader()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\"Value\";");
            sb.Append("\"Low\";");
            sb.Append("\"High\"\r\n");

            return sb.ToString();
        }
    }
}

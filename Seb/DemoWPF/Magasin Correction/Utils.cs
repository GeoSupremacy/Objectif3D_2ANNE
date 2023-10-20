using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magasin_Correction
{
    internal class Utils
    {
        public static float GetEurosFromDollard(float _dollard) => _dollard * 0.95f;
        public static string GetEurosFromDollardToString(float _dollard) => $"{GetEurosFromDollard(_dollard).ToString("0.00")} €";
    }
}

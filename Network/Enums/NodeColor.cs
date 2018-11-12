using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Enums
{
    public enum NodeColor
    {
        /// <summary>
        /// Полностью доступен
        /// </summary>
        Green,
        /// <summary>
        /// Доступен, но услуга деградирована
        /// </summary>
        Yellow,
        /// <summary>
        /// Недоступен
        /// </summary>
        Red
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Enums
{
    public enum NodeType
    {
        /// <summary>
        /// Система мониторинга
        /// </summary>
        Monitor,
        /// <summary>
        /// Потребитель
        /// </summary>
        Consumer,
        /// <summary>
        /// Источник
        /// </summary>
        Source,
        /// <summary>
        /// Прмежуточный узел
        /// </summary>
        Intermediate
    }
}

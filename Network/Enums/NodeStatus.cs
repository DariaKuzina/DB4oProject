using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Enums
{
    /// <summary>
    /// Статус узла с точки зрения мониторинговой системы
    /// </summary>
    public enum NodeStatus
    {
        /// <summary>
        /// Не удалось определить статус узла
        /// </summary>
        Undefined,
        /// <summary>
        /// Связь доступна
        /// </summary>
        Connected,
        /// <summary>
        /// Связь недоступна
        /// </summary>
        Disconnected
    }
}

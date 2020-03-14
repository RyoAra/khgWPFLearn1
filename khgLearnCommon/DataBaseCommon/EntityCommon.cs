using System;
using System.Collections.Generic;
using System.Text;

namespace khgLearnCommon.DataBaseCommon
{
    public interface IEntityCommon
    {
        /// <summary>
        /// 更新状態フラグ
        /// </summary>
        bool IsValid { get; set; }
    }
}

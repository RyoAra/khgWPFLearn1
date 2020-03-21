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

        /// <summary>
        /// 更新時実行するクエリ先の関数
        /// </summary>
        Func<bool> Execute { get; set; }
    }
}

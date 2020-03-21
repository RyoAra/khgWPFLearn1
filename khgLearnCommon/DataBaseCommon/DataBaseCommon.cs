using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Dapper;

namespace khgLearnCommon.DataBaseCommon
{
    public class DataBaseCommon
    {
        public string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
        private string _connectionString;


        //sync version
        T GeneralExecuteAction<T>(Func<ISession, T> action)
        {
            lastDbError = DbError.Ok;
            using (var ctx = GetContextForStatement())
            {
                try
                {
                    T result = action(ctx.session);
                    ctx.CommitTransactionIfExists();
                    return result;
                }
                catch (Exception ex)
                {
                    ctx.RollbackTransactionIfExists();
                    lastDbError = new DbError(ex);
                    return default(T);
                }
            }
        }
        //async version 
        async Task<T> GeneralExecuteAction<T>(Func<ISession, Task<T>> action)
        {
            lastDbError = DbError.Ok;
            using (var ctx = GetContextForStatement())
            {
                try
                {
                    T result = await action(ctx.session);
                    await ctx.CommitTransactionIfExistsAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    await ctx.RollbackTransactionIfExistsAsync();
                    lastDbError = new DbError(ex);
                    return default(T);
                }
            }
        }

        public async Task<bool> Update(object updateRow, object oldRow)
        {
            string TableName = updateRow.GetType().Name;

            // ここでキー項目&データ取得
            var update = GetAllKeys(oldRow.GetType(), oldRow);
            var updateData = GetAllPropertis(updateRow.GetType(), updateRow);

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string setString = "";
                    for (int i = 0; i < updateData.Count; i++)
                    {
                        if (((EntityBindbleBase)updateData.ElementAt(i).Value).IsValid)
                        {
                            // 考えるの面倒なので1=1入れてから対応
                            setString += updateData.ElementAt(i).Key + " = " + updateData.ElementAt(i).Value?.ToString();
                            if (i < updateData.Count - 1)
                            {
                                setString += ",";
                            }
                        }
                    }

                    // 条件作成
                    string whereString = "1 = 1";
                    for (int i = 0; i < update.Count; i++)
                    {
                        // 考えるの面倒なので1=1入れてから対応
                        whereString += " AND " + update.ElementAt(i).Key + " = " + update.ElementAt(i).Value?.ToString();
                    }

                    // 更新した分だけにしたいけど今はいったん全部で・・・
                    var sqlStatement = "Update @TableName Set @setString WHERE @whereString";
                    await connection.ExecuteAsync(sqlStatement, TableName, setString, whereString);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 削除用
        /// </summary>
        /// <param name="deleteRow"></param>
        /// <returns></returns>
        public async Task<bool> Delete(object deleteRow)
        {
            string TableName = deleteRow.GetType().Name;

            // ここでキー項目&データ取得
            var delKey = GetAllKeys(deleteRow.GetType(), deleteRow);

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    // 条件作成
                    string whereString = "1 = 1";
                    for (int i = 0; i < delKey.Count; i++)
                    {
                        // 考えるの面倒なので1=1入れてから対応
                        whereString += " AND " + delKey.ElementAt(i).Key + " = " + delKey.ElementAt(i).Value?.ToString();
                    }
                    var sqlStatement = "DELETE @TableName WHERE @whereString";
                    await connection.ExecuteAsync(sqlStatement, TableName, whereString);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        #region ここからサブメソッド

        /// <summary>
        /// クラス自体とクラス中の public メソッドの作者情報を取得する。
        /// </summary>
        /// <param name="t">クラスの Type</param>
        static Dictionary<string, object> GetAllPropertis(Type t, object obj)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            Console.Write("type name: {0}\n", t.Name);

            foreach (PropertyInfo info in t.GetProperties())
            {
                // keyのみ投入
                keyValuePairs.Add(info.Name, info.GetValue(obj));
            }
            return keyValuePairs;
        }

        /// <summary>
        /// クラス自体とクラス中の public メソッドの作者情報を取得する。
        /// </summary>
        /// <param name="t">クラスの Type</param>
        static Dictionary<string, object> GetAllKeys(Type t, object obj)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            Console.Write("type name: {0}\n", t.Name);

            foreach (PropertyInfo info in t.GetProperties())
            {
                Console.Write("  method name: {0}\n", info.Name);
                if (GetAuthors(info))
                {
                    // keyのみ投入
                    keyValuePairs.Add(info.Name, info.GetValue(obj));
                }
            }
            return keyValuePairs;
        }

        /// <summary>
        /// クラスやメソッドの作者情報を取得する。
        /// </summary>
        /// <param name="info">クラスやメソッドの MemberInfo</param>
        static bool GetAuthors(PropertyInfo info)
        {
            Attribute[] keys = Attribute.GetCustomAttributes(
                info, typeof(KeyAttribute));
            foreach (Attribute att in keys)
            {
                KeyAttribute key = att as KeyAttribute;
                if (key != null)
                {
                    // キーですの
                    return true;
                }
            }

            // キーじゃないですの
            return false;
        }

        #endregion
    }
}

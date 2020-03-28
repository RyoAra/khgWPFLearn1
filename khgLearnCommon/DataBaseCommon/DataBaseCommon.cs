using Dapper;
using Dapper.FastCrud;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace khgLearnCommon.DataBaseCommon
{
    public class DataBaseCommon
    {
        private DbConnection  dbConnection;

        public string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
        private string _connectionString;


        public void SetConnectionString(SqlDialect sqlDialect, string connectionString)
        {
            ConnectionString = connectionString;
            OrmConfiguration.DefaultDialect = sqlDialect;
            dbConnection = new SqlConnection(ConnectionString);
        }

        public void SetConnectionString(SqlDialect sqlDialect)
        {
            OrmConfiguration.DefaultDialect = sqlDialect;
            dbConnection = new SqlConnection(ConnectionString);
        }


        public bool DBOpen()
        {
            dbConnection.Open();

            return true;
        }

        public bool DBOpenAsync()
        {
            dbConnection.OpenAsync();

            return true;
        }

        public bool DBClose()
        {
            dbConnection.Close();

            return true;
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
                    var sqlStatement = "Update {0} Set {1} WHERE {2}";
                    sqlStatement = string.Format(sqlStatement, TableName, setString, whereString);
                    await connection.ExecuteAsync(sqlStatement);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Insert(object insertRow)
        {
            string TableName = insertRow.GetType().Name;

            // ここでキー項目&データ取得
            var update = GetAllKeys(insertRow.GetType(), insertRow);
            var insertData = GetAllPropertis(insertRow.GetType(), insertRow);
            string columnName="";
            string data = "";
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    bool isFirst = true;
                    for (int i = 0; i < insertData.Count; i++)
                    {
                       
                        if (isFirst == false)
                        {
                            columnName += "'";
                            data += "'";
                        }
                        isFirst = false;
                        columnName += insertData.ElementAt(i).Key;
                        data += insertData.ElementAt(i).Value?.ToString();
                    }

                    // 更新した分だけにしたいけど今はいったん全部で・・・
                    var sqlStatement = "Insert Into {0} ({1})  Values ({2})";
                    sqlStatement = string.Format(sqlStatement, TableName, columnName, data);
                    await connection.ExecuteAsync(sqlStatement);
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
                    //var sqlStatement = "Update {0} Set {1} WHERE {2}";
                    //var sqlStatement = "DELETE @TableName WHERE @whereString";
                    var sqlStatement = "DELETE {0} WHERE {1}";
                    sqlStatement = string.Format(sqlStatement, TableName, whereString);
                    await connection.ExecuteAsync(sqlStatement);
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

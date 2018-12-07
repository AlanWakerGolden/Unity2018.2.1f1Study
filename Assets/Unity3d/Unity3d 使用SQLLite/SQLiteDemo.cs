using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SQLiteDemo : MonoBehaviour {

    private SQLiteHelper sql;

    [ContextMenu("建库创表")]
    private void Init()
    {
        // 创建名为sqlitedemo的数据库
        sql = new SQLiteHelper("ZyFirstSqlite.db");
        Debug.Log("创建成功了一张表");
        //创建名为table1的数据表
        sql.CreateTable("table1", new string[] { "ID", "Name", "Age", "Email" }, new string[] { "INTEGER", "TEXT", "INTEGER", "TEXT" });
    }

    /// <summary>
    /// 插入数据
    /// </summary>
    [ContextMenu("InsertData")]
    private void InsertData()
    {
        //插入两条数据
        sql.InsertValues("table1", new string[] { "'2018083844'", "'张亿'", "'22'", "'1032361865@qq.com'" });
        sql.InsertValues("table1", new string[] { "'2018083845'", "'梁永通'", "'23'", "'liangyongtong@sina.com'" });

    }

    /// <summary>
    /// 更新数据
    /// </summary>
    [ContextMenu("UpdateData")]
    private void UpdateData()
    {
        //更新数据
        sql.UpdateValues("table1", new string[] { "Name" }, new string[] { "'张云凡'" }, "Name", "=", "张亿");
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    [ContextMenu("DeleteData")]
    private void DeleteData()
    {
        sql.DeleteValuesAND("table1", new string[] { "Name", "Age" }, new string[] { "=", "=" }, new string[] { "'张亿'", "'22'" });
    }

    /// <summary>
    /// 读取数据
    /// </summary>
    [ContextMenu("ReaderData")]
    private void ReaderData()
    {
        SqliteDataReader reader = sql.ReadFullTable("table1");
        while (reader.Read())
        {
            //读取ID
            Debug.Log(reader.GetInt32(reader.GetOrdinal("ID")));
            //读取Name
            Debug.Log(reader.GetString(reader.GetOrdinal("Name")));
            //读取Age
            Debug.Log(reader.GetInt32(reader.GetOrdinal("Age")));
            //读取Email
            Debug.Log(reader.GetString(reader.GetOrdinal("Email")));
        }

        //读取数据表中Age>=22的所有记录的ID和Name
        reader = sql.ReadTable("table1", new string[] { "ID", "Name" }, new string[] { "Age" }, new string[] { ">=" }, new string[] { "'22'" });
        while (reader.Read())
        {
            //读取ID
            Debug.Log(reader.GetInt32(reader.GetOrdinal("ID")));
            //读取Name
            Debug.Log(reader.GetString(reader.GetOrdinal("Name")));
        }

    }

    [ContextMenu("自定义删除")]
    private void DefineDeleteData()
    {
        sql.ExecuteQuery("DELETE FROM table1 WHERE NAME='张亿'");
    }

    [ContextMenu("关闭连接数据库")]
    private void Close()
    {
        sql.CloseConnection();
    }

}

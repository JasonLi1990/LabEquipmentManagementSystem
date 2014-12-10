using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
///DBConnect 的摘要说明
/// </summary>
public class DBConnect
{
    private String conStr = ConfigurationManager.AppSettings.Get("connectString");  //数据库连接字符串
    private SqlConnection con;
    private SqlCommand cmd;

    public SqlCommand getCmd()
    {
        return cmd;
    }

    public SqlConnection getConn()
    {
        return con;
    }

    public DBConnect()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //    
    }

    public static SqlParameter MakeParameter(string paraName, object value)
    {
        SqlParameter param = new SqlParameter(paraName, value);
        return param;
    }

    /// <summary>
    /// 执行带有参数或不合参数的SQL语句
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="paras"></param>
    public void ExecuteSql(string sql, SqlParameter[] paras)
    {
        OpenConnect();
        cmd = new SqlCommand(sql, con);
        if (paras != null)
        {
            foreach (SqlParameter parameter in paras)
                cmd.Parameters.Add(parameter);
        }
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        CloseConnect();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="paras"></param>
    /// <returns></returns>
    public DataSet GetDataSet(string sql, SqlParameter[] paras)
    {
        OpenConnect();
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.SelectCommand.CommandType = CommandType.Text;
        if (paras != null)
        {
            foreach (SqlParameter parameter in paras)
                da.SelectCommand.Parameters.Add(parameter);
        }
        DataSet ds = new DataSet();
        da.Fill(ds);
        CloseConnect();
        if (ds.Tables[0].Rows.Count == 0)
        {
            return null;
        }
        return ds;
    }

    public bool OpenConnect()
    {
        con = new SqlConnection(conStr);
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            return true;
        }
        return false;
    }
    public bool CloseConnect()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        if (con.State == ConnectionState.Closed)
        {
            return true;
        }
        return false;
    }
}

using Dapper;
using EMaS_MVC.Models;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EMaS_MVC.HelperClass
{
    public class GlobalConnectionHelper
    {
        private static GlobalConnectionHelper _instance = new GlobalConnectionHelper();


        private GlobalConnectionHelper() { }

        public static GlobalConnectionHelper getInstance()
        {
            return _instance;
        }

        private string EMaSDbConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["oracleConString"].ConnectionString;
            }
        }

        public DataTable getData(string strQry)
        {
            using (IDbConnection db = new OracleConnection(EMaSDbConnectionString))
            {
                DataTable dtTable = new DataTable();
                dtTable.Load(db.ExecuteReader(strQry));
                return dtTable;
            }
        }

        public List<T> getData<T>(string strQry, T data)
        {
            var dataList = new List<T>();

            using (IDbConnection db = new OracleConnection(EMaSDbConnectionString))
            {
                if (data != null)
                {
                    dataList = db.Query<T>(strQry, data).ToList();
                }
                else
                {
                    dataList = db.Query<T>(strQry).ToList();
                }
            }

            return dataList;
        }

        public void upSert<T>(string strQry, T data)
        {
            using (IDbConnection db = new OracleConnection(EMaSDbConnectionString))
            {
                db.Execute(strQry, data);
            }
        }

        //public static List<CmSystemMenu> getGroupMenu()
        //{
        //    OracleConnection db = new OracleConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //    var RootMenu = db.Query("SELECT * FROM CM_SYSTEM_MENU WHERE SYS_MENU_TYPE='RT' ORDER BY SYS_MENU_SERIAL").ToList();
        //    var GroupMenu = GlobalConnectionHelper.getMenu(RootMenu[0].SYS_MENU_ID,AppHelper.GetLoginUserData("SYS_USR_GRP_ID"));
        //    return GroupMenu;
        //}

        public static List<CmSystemMenu> getMenu(string strParentMenu, string strGroupID)
        {
            using (IDbConnection db = new OracleConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string strSql = "SELECT DISTINCT "
                       + "M.SYS_MENU_ID, SYS_MENU_TITLE, SYS_MENU_FILE,"
                       + "SYS_MENU_PARENT, CMP_BRANCH_ID, SYS_MENU_TYPE,"
                       + "SYS_MENU_SERIAL "
                       + "FROM CM_SYSTEM_MENU M,CM_SYSTEM_ACCESS_POLICY P "
                       + "WHERE P.SYS_MENU_ID=M.SYS_MENU_ID AND M.SYS_MENU_PARENT='" + strParentMenu + "' AND P.SYS_ACCP_VIEW = 'Y' "
                        + "AND M.SYS_MENU_PARENT<> M.SYS_MENU_ID AND P.SYS_USR_GRP_ID = '" + strGroupID + "' ORDER BY SYS_MENU_SERIAL";
                var menu = db.Query<CmSystemMenu>(strSql).ToList();

                return menu;
            }
        }

        public void sqlExecute(string strQry)
        {
            using (IDbConnection db = new OracleConnection(EMaSDbConnectionString))
            {
                db.Execute(strQry);
            }
        }
    }
}
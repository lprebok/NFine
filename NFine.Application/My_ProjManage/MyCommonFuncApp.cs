using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Data;
using NFine.Code;
using System.Data;
using System.Data.SqlClient;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Repository.My_ProjManage;
using System.Threading.Tasks;

namespace NFine.Application.My_ProjManage
{
    public class MyCommonFuncApp
    {
        IMyCommonFuncRepository icomm = new MyCommonFuncRepository();
        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <returns></returns>
        public OperatorModel GetCurrentUser()
        {
            return OperatorProvider.Provider.GetCurrent();
        }

        /// <summary>
        /// 获取项目类别信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProType()
        {
            string strCMD = "SELECT mpbd.FCode,mpbd.FName FROM dbo.MY_ProBaseData AS mpbd " +
            " WHERE mpbd.FType = 'MY0001' AND mpbd.FCheckFlag = 1 ";
            return icomm.GetQueryDataTable(strCMD, null);
        }

        /// <summary>
        /// 获取项目经理信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProjManger()
        {
            return icomm.GetPersonList();
        }

        /// <summary>
        /// 将DataTable转换为Json格式，要转换的列为"FCode","FName".
        /// </summary>
        /// <param name="dtdata"></param>
        /// <returns></returns>
        public string DataTableToJson(DataTable dtdata)
        {
            var treeList = new List<TreeSelectModel>();
            foreach (DataRow dr in dtdata.Rows)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = dr["FCode"].ToString();
                treeModel.text = dr["FName"].ToString();
                treeModel.parentId = "";
                treeModel.data = "";
                treeList.Add(treeModel);
            }
            return treeList.TreeSelectJson();
        }

        /// <summary>
        /// 获取年度信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetYear()
        {
            DataTable dbYear = new DataTable();
            dbYear.Columns.Add("FCode");
            dbYear.Columns.Add("FName");
            int iNowYear = DateTime.Now.Year;
            for (int itmpYear = 2017; itmpYear <= iNowYear; itmpYear++)
            {
                dbYear.Rows.Add(itmpYear,itmpYear.ToString()+"年");
            }
            return dbYear;
        }

        /// <summary>
        /// 获取周次信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetWeek()
        {
            DataTable dbYear = new DataTable();
            dbYear.Columns.Add("FCode");
            dbYear.Columns.Add("FName");
            for (int itmpYear = 1; itmpYear <= 53; itmpYear++)
            {
                dbYear.Rows.Add(itmpYear, itmpYear.ToString() + "周");
            }
            return dbYear;
        }









    }
}

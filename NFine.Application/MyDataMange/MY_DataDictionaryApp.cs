using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Data;
using System.Data;
using System.Data.SqlClient;
using NFine.Domain._03_Entity.MyDataManage;
using NFine.Domain._04_IRepository.MyDataMange;
using NFine.Repository.MyDataMange;

namespace NFine.Application.MyDataMange
{
    public class MY_DataDictionaryApp
    {
        IMY_DataDictionaryRepository myService = new MY_DataDictionaryRepository();

        public List<MY_DataDictionaryEntity> GetEntityList()
        {
            return myService.IQueryable().ToList();
        }

        public DataTable GetList(string itemId = "", string keyword = "")
        {
            string strCmd = "SELECT mdd.FID,mddi.FColCode ,mddi.FColName ,mddi.FColType,mdd.FSortCode ,mddi.FDesc ,mddi.FWriteDate ,mddi.FCheckFlag " +
            " FROM dbo.MY_DataDictInfo AS mddi " +
            " LEFT JOIN dbo.MY_DataDictionary AS mdd ON mdd.FCode = mddi.FTCode " +
            " WHERE mddi.FCancelFlag = 0 AND (@FCode='' OR mddi.FTCode=@FCode) " +
            " AND mddi.FColName LIKE '%'+@FName+'%' " +
            " ORDER BY mdd.FSortCode ";
            SqlParameter[] para = { new SqlParameter("@FCode",SqlDbType.VarChar),
                                    new SqlParameter("@FName",SqlDbType.VarChar)};
            para[0].Value = itemId;
            para[1].Value = keyword;
           return myService.GetQueryTable(strCmd,para);
        }








    }
}

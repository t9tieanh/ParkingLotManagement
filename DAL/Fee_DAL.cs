using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Fee_DAL
    {
        public static bool UpdateFeeMoto (Fee_DTO myFee)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM Fee";
            MyDB.ExecuteNonQuery(sqlCommand);
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO [Fee] VALUES (@FeeCar, @FeeMoto, @FeeBicycle)";
            sqlCommand.Parameters.AddWithValue("@FeeCar", myFee.FeeCar);
            sqlCommand.Parameters.AddWithValue("@FeeMoto", myFee.FeeMoto);
            sqlCommand.Parameters.AddWithValue("@FeeBicycle", myFee.FeeBicycle);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static Fee_DTO GetFee ()
        {
            try
            {
                string str = "SELECT * FROM FEE";
                DataTable dt = MyDB.GetDataTable(str);
                return new Fee_DTO(Convert.ToDouble(dt.Rows[0][0]), Convert.ToDouble(dt.Rows[0][1]), Convert.ToDouble(dt.Rows[0][2]));
            }
            catch
            {
                return new Fee_DTO(0,0,0);
            }
        }
    }
}

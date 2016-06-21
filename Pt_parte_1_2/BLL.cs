using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BLL
    {
        public class pic 
        {
            static public int insertPb(int PictureBox, string Directory)
            { 

            DAL dal = new DAL();
            SqlParameter[] sqlp = new SqlParameter[]{
                new SqlParameter("@PictureBox", PictureBox),
                new SqlParameter("@Directory", Directory),
                };
            return dal.executarNonQuery("Insert into pbNumero (Directory, PictureBox) values (@Directory, @PictureBox)", sqlp);
            }
            // Proxima static
            static public DataTable load()
            {
                DAL dal = new DAL();
                return dal.executarReader("select * from pbNumero", null);
            }
         
        }
        // Proxima Class
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MySQL_Database_Library
{
    public class Library_Properties

    {



        private string sql_string;
        private string strCon;
        

        // This write-only property collects the User's SQL string command 

        public string Sql
        {

            set { sql_string = value; }

        }

        // This write-only property collects the database file_path from the User

        public string connection_string
        {

            set { strCon = value; }

        }

        /*  This read-only property returns MyDataSet method that performs connection to the database 
         *   
         *  and also the DataSet object holding pulled records from the database to the User
        */

        public System.Data.DataSet GetConnection

        {

            get { return MyDataSet(); }

        }

          

        System.Data.DataSet dat_set;
        System.Data.SqlServerCe.SqlCeDataAdapter da_1;


        /*  This method perform connection to the database 
         *   
         *  and pull records from the database into a DataSet object
        */

        private System.Data.DataSet MyDataSet()

        {

            System.Data.SqlServerCe.SqlCeConnection con = new System.Data.SqlServerCe.SqlCeConnection(strCon);

            con.Open();

            da_1 = new System.Data.SqlServerCe.SqlCeDataAdapter(sql_string,con);

            dat_set = new System.Data.DataSet();
            da_1.Fill(dat_set, "Default Table");

            con.Close();

            return dat_set;

        }


        // This method updates the database 

        public void UpdateDB()

        {

            System.Data.SqlServerCe.SqlCeCommandBuilder cb;
            cb = new System.Data.SqlServerCe.SqlCeCommandBuilder(da_1);
            cb.DataAdapter.Update(dat_set.Tables["Default Table"]);

        }


     

    }
}

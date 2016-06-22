using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using LifePerformanceMitch.Model;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace TweakersRemake
{
    public static class Database
    {
        private static string Connection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=fhictora)));User ID=dbi323425;PASSWORD=mmk55mmk100;";

        private static OracleConnection Conn;

       static Database()
        {
           try
           {
                Conn = new OracleConnection(Connection);
           }
           catch (OracleException Ex)
           {
               throw;
           }
        }

        public static bool Openconnecion()
        {
            if (Conn.State == ConnectionState.Open)
            {


                return true;
            }
            else
            {
                try
                {
                    Conn.Open();
                    return true;
                }
                catch (OracleException ex)
                {

                    return false;
                }
            }
        }

        public static OracleDataReader GetReader(string str)
        {
            if (Openconnecion())
            {
                OracleCommand command = new OracleCommand(str);
                command.Connection = Conn;

                return command.ExecuteReader();
            }
            return null;
            //Dit is commentaar

        }
        public static int GetNextID(string Table)
        {
            string str = "Select Max(ID) From " + Table;
            if (Openconnecion())
            {
                try
                {
                    OracleCommand command = new OracleCommand(str);
                    command.Connection = Conn;
                    OracleDataReader Data = command.ExecuteReader();
                    Data.Read();
                    return Data.GetInt32(0) + 1;

                }
                catch (OracleException)
                {

                    return 1;
                }



            }
            return 0;



        }

        public static bool VoegMeerToe(Vaargebieden vaar)
        {
            
        }

        public static bool VoegKlantToe(Klant klant)
        {
            
        }

        public static bool VoegHuurcontractToe(Huurcontract huurcontract)
        {
            
        }

        public static List<Huurcontract> KrijfHuurcontracts()
        {
            
        }

        public static List<Vaargebieden> KrijgVaargebiedens()
        {
            
        }

        public static List<Klant> KrijgKlanten()
        {
            
        }




    }

  
}
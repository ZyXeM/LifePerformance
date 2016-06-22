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
            string str = "Insert into vaargebieden values(:id , :naam , :dagprijs , :booten)";
            if (Openconnecion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand(str);
                    cmd.Parameters.Add("id", OracleDbType.Int16);
                    cmd.Parameters["id"].Value = GetNextID("Vaargebieden");
                    cmd.Parameters.Add("naam", OracleDbType.Varchar2);
                    cmd.Parameters["naam"].Value = vaar.Naam;
                    cmd.Parameters.Add("dagprijs", OracleDbType.Double);
                    cmd.Parameters["dagprijs"].Value = vaar.Dagprijs;
                    int type = 0;
                    if (vaar.Motor)
                    {
                        type = 1;
                    }
                    else if (vaar.Spier && vaar.Motor)
                    {
                        type = 2;
                    }
                    cmd.Parameters["booten"].Value = type;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }

        public static bool VoegKlantToe(Klant klant)
        {
            string str = "Insert into Klant values(:id , :naam , :email)";
            if (Openconnecion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand(str);
                    cmd.Parameters.Add("id", OracleDbType.Int16);
                    cmd.Parameters["id"].Value = GetNextID("Klant");
                    cmd.Parameters.Add("naam", OracleDbType.Varchar2);
                    cmd.Parameters["naam"].Value = klant.Naam;
                    cmd.Parameters.Add("email", OracleDbType.Varchar2);
                    cmd.Parameters["email"].Value = klant.Emailadres;
                  
                
                   
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }

        public static bool VoegHuurcontractToe(Huurcontract huurcontract)
        {
            
        }

        public static List<Huurcontract> KrijgHuurcontracts()
        {
            
        }

        public static List<Vaargebieden> KrijgVaargebiedens()
        {
            try
            {
                List<Vaargebieden> list = new List<Vaargebieden>();
                string str = "select * from Vaargebieden";
                OracleCommand cmd = new OracleCommand(str);
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Vaargebieden vaar = new Vaargebieden(Read.GetDouble(2), Read.GetString(1), Read.GetInt16(0),
                        Read.GetInt16(3));
                    list.Add(vaar);
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Klant> KrijgKlanten()
        {
            try
            {
                List<Klant> list = new List<Klant>();
                string str = "select * from Vaargebieden";
                OracleCommand cmd = new OracleCommand(str);
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Klant klant = new Klant(Read.GetInt16(0), Read.GetString(1), Read.GetString(2));
                    list.Add(klant);
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Huur> KrijghuurLijst()
        {
            try
            {
                List<Huur> list = new List<Huur>();
                string str = "select * from Boot where motor = 0";
                OracleCommand cmd = new OracleCommand(str);
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Spierboot boot = new Spierboot(Read.GetString(0), Read.GetDouble(2), Read.GetString(3));
                    list.Add(boot);
                }
                str = "select * from Boot where motor = 1";
                cmd = new OracleCommand(str);
                Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Motorboot boot = new Motorboot(Read.GetString(0), Read.GetDouble(2), Read.GetString(3),
                        Read.GetInt16(1));
                    list.Add(boot);
                }

                str = "select * from Artikelen";
                cmd = new OracleCommand(str);
                Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Artikel boot = new Artikel(Read.GetInt16(0), Read.GetString(1), Read.GetDouble(2));
                    list.Add(boot);
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
            
        }




    }

  
}
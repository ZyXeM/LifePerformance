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
        private static string Connection =
            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fhictora01.fhict.local)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=fhictora)));User ID=dbi323425;PASSWORD=mmk55mmk100;";

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
                    cmd.Parameters.Add("dagprijs", OracleDbType.Decimal);
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
            try
            {
                Openconnecion();
                string str = "insert into huurcontract values(:id ,:klant , :datetot , :datevan)";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Parameters.Add("id", OracleDbType.Int16);
                int huurint = GetNextID("huurcontract");
                cmd.Parameters["id"].Value = GetNextID("huurcontract");
                cmd.Parameters.Add("klant", OracleDbType.Int16);
                cmd.Parameters["klant"].Value = huurcontract.Klant.Id;
                cmd.Parameters.Add("datetot", OracleDbType.Date);
                cmd.Parameters["datetot"].Value = huurcontract.Datum_Tot;
                cmd.Parameters.Add("datevan", OracleDbType.Date);
                cmd.Parameters["datevan"].Value = huurcontract.Datum_Vanaf;

                foreach (var h in huurcontract.Huurlijst)
                {
                    if (h is Artikel)
                    {
                        if (!VoegArtikelConnectieToe(huurint, ((Artikel) h).Id))
                        {
                            return false;
                        }
                    }
                    else if (h is Boot)
                    {
                        if (!VoegBootConnectieToe(huurint, h.Naam))

                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static int? CheckBestaand(int huurId,int ArtikelId)
        {
            try
            {
                Openconnecion();
                string str = "select * from Artikel_huurcontract where huurcontract_ID = :hid and Artikel_ID = :aid";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Parameters.Add("hid", OracleDbType.Int16);
                cmd.Parameters["hid"].Value = huurId;
                cmd.Parameters.Add("aid", OracleDbType.Int16);
                cmd.Parameters["aid"].Value = ArtikelId;
                OracleDataReader Read = cmd.ExecuteReader();
                Read.Read();
                if (Read.HasRows)
                {
                    return Read.GetInt16(2);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int? CheckBestaandBoot(int huurId, string bootId)
        {
            try
            {
                Openconnecion();
                string str = "select * from boot_huurcontract where huurcontract_ID = :hid and boot_ID = :aid";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Parameters.Add("hid", OracleDbType.Int16);
                cmd.Parameters["hid"].Value = huurId;
                cmd.Parameters.Add("aid", OracleDbType.Varchar2);
                cmd.Parameters["aid"].Value = bootId;
                OracleDataReader Read = cmd.ExecuteReader();
                Read.Read();
                if (Read.HasRows)
                {
                    return Read.GetInt16(2);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool VoegArtikelConnectieToe(int huurId,int ArtikelId)
        {
            try
            {
                Openconnecion();
                string str = "insert into Artikel_huurcontract values(:hid , :bid , :hoeveel)";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Parameters.Add("hid", OracleDbType.Int16);
                cmd.Parameters["hid"].Value = huurId;
                cmd.Parameters.Add("bid", OracleDbType.Int16);
                cmd.Parameters["bid"].Value = ArtikelId;
                cmd.Parameters.Add("hoeveel", OracleDbType.Int16);
                int? i = CheckBestaand(huurId, ArtikelId);
                if(i == null)
                {
                    i = 1;
                }
                cmd.Parameters["hoeveel"].Value = i;
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool VoegBootConnectieToe(int huurId, string BootId)
        {
            try
            {
                Openconnecion();
                string str = "insert into boot_huurcontract values(:hid , :bid)";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Parameters.Add("hid", OracleDbType.Int16);
                cmd.Parameters["hid"].Value = huurId;
                cmd.Parameters.Add("bid", OracleDbType.Varchar2);
                cmd.Parameters["bid"].Value = BootId;
                int? i = CheckBestaandBoot(huurId, BootId);
                 cmd.Parameters["hoeveel"].Value = i;
                if (i == null)
                {
                    i = 1;
                }
                cmd.Parameters["hoeveel"].Value = i;
                cmd.Parameters.Add("hoeveel", OracleDbType.Int16);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Huurcontract> KrijgHuurcontracts()
        {
            try
            {
                Openconnecion();
                List<Huurcontract> huurcontracten = new List<Huurcontract>();
                string str = "Select * from huurcontract";
                OracleCommand cmd = new OracleCommand(str);
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    List<Huur> huurl = Database.KrijgHuurLijst(Read.GetInt16(0));
                    Klant klant = Database.KrijgKlant(Read.GetInt16(1));
                    Huurcontract huur = new Huurcontract(Read.GetInt16(0), Read.GetDateTime(2),Read.GetDateTime(3),huurl, klant);
                }

                return huurcontracten;

            }
            catch (Exception)
            {
                return null;
            }
            
        }

        private static Klant KrijgKlant(int id)
        {
            try
            {
                Openconnecion();
                string str = "select * from klant  where Id =  " + id;
                OracleCommand cmd = new OracleCommand(str);
                OracleDataReader Read = cmd.ExecuteReader();
                Read.Read();
                Klant klant = new Klant(Read.GetInt16(0), Read.GetString(1), Read.GetString(2));
                return klant;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Vaargebieden> KrijgVaargebiedens()
        {
            try
            {
                Openconnecion();
                List<Vaargebieden> list = new List<Vaargebieden>();
                string str = "select * from Vaargebieden";
                OracleCommand cmd = new OracleCommand(str);
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Vaargebieden vaar = new Vaargebieden(Read.GetDecimal(2), Read.GetString(1), Read.GetInt16(0),
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
                Openconnecion();
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

        public static List<Huur> KrijgHuurLijst()
        {
            try
            {
                Openconnecion();
                List<Huur> list = new List<Huur>();
                string str = "select * from Boot where motor = 0";
                OracleCommand cmd = new OracleCommand(str);
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Spierboot boot = new Spierboot(Read.GetString(0), Read.GetDecimal(2), Read.GetString(3));
                    list.Add(boot);
                }
                str = "select * from Boot where motor = 1";
                cmd = new OracleCommand(str);
                Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Motorboot boot = new Motorboot(Read.GetString(0), Read.GetDecimal(2), Read.GetString(3),
                        Read.GetInt16(1));
                    list.Add(boot);
                }

                str = "select * from Artikelen";
                cmd = new OracleCommand(str);
                Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Artikel boot = new Artikel(Read.GetInt16(0), Read.GetString(1), Read.GetDecimal(2));
                    list.Add(boot);
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public static List<Huur> KrijgHuurLijst(int id)
        {
            try
            {
                Openconnecion();
                List<Huur> list = new List<Huur>();
                string str = "select * from Boot b join Boot_huurcontract bh where b.motor = 0 and bh.huurcontract_ID = "+ id;
                OracleCommand cmd = new OracleCommand(str);
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Spierboot boot = new Spierboot(Read.GetString(0), Read.GetDecimal(2), Read.GetString(3));
                    list.Add(boot);
                }
                str = "select * from Boot b join Boot_huurcontract bh where b.motor = 1 and bh.huurcontract_ID = " + id;
                cmd = new OracleCommand(str);
                Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Motorboot boot = new Motorboot(Read.GetString(0), Read.GetDecimal(2), Read.GetString(3),
                        Read.GetInt16(1));
                    list.Add(boot);
                }

                str = "select * from Artikelen A join Artikelen_huurcontract AH where AH.Huurcontract_ID = "+id;
                cmd = new OracleCommand(str);
                Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Artikel boot = new Artikel(Read.GetInt16(0), Read.GetString(1), Read.GetDecimal(2));
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
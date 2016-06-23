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
        /// <summary>
        /// Geeft de eerste volgende vrije ID van een bepaalde table
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
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
                catch (Exception)
                {

                    return 1;
                }



            }
            return 0;



        }
        /// <summary>
        /// Voegt een meer toe aan de database
        /// </summary>
        /// <param name="vaar"></param>
        /// <returns></returns>
        public static bool VoegMeerToe(Vaargebieden vaar)
        {
            string str = "Insert into vaargebieden values(:id , :naam , :dagprijs , :booten)";
            if (Openconnecion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand(str);
                    cmd.Connection = Conn;
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
                    cmd.Parameters.Add("booten", OracleDbType.Int16);
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
        /// <summary>
        /// Voegt klant toe aan de database
        /// </summary>
        /// <param name="klant"></param>
        /// <returns></returns>
        public static bool VoegKlantToe(Klant klant)
        {
            string str = "Insert into Klant values(:id , :naam , :email )";
            if (Openconnecion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand(str);
                    cmd.Connection = Conn;
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
        /// <summary>
        /// Voegt huurcontract toe aan database
        /// </summary>
        /// <param name="huurcontract"></param>
        /// <returns></returns>
        public static bool VoegHuurcontractToe(Huurcontract huurcontract)
        {
            try
            {
                Openconnecion();
                string str = "insert into huurcontract values(:id ,:klant , :datetot , :datevan)";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
                cmd.Parameters.Add("id", OracleDbType.Int16);
                int huurint = GetNextID("huurcontract");
                cmd.Parameters["id"].Value = GetNextID("huurcontract");
                cmd.Parameters.Add("klant", OracleDbType.Int16);
                cmd.Parameters["klant"].Value = huurcontract.Klant.Id;
                cmd.Parameters.Add("datetot", OracleDbType.Date);
                cmd.Parameters["datetot"].Value = huurcontract.Datum_Tot;
                cmd.Parameters.Add("datevan", OracleDbType.Date);
                cmd.Parameters["datevan"].Value = huurcontract.Datum_Vanaf;
                cmd.ExecuteNonQuery();
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

        /// <summary>
        /// Checked of de connectie vna het huurcontract en artikel al bestaat, zo ja dan hoeveel er al zijn
        /// </summary>
        /// <param name="huurId"></param>
        /// <param name="ArtikelId"></param>
        /// <returns></returns>
        public static int? CheckBestaand(int huurId,int ArtikelId)
        {
            try
            {
                Openconnecion();
                string str = "select * from Artikelen_huurcontract where huurcontract_ID = :hid and Artikel_ID = :aid";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
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
        /// <summary>
        /// Checked of de connectie vna het huurcontract en Boot al bestaat, zo ja dan hoeveel er al zijn
        /// </summary>
        /// <param name="huurId"></param>
        /// <param name="bootId"></param>
        /// <returns></returns>
        public static int? CheckBestaandBoot(int huurId, string bootId)
        {
            try
            {
                Openconnecion();
                string str = "select * from boot_huurcontract where huurcontract_ID = :hid and boot_ID = :aid";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
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
        /// <summary>
        /// Voegt de connectie tussen een contact en een Artikel toe
        /// </summary>
        /// <param name="huurId"></param>
        /// <param name="ArtikelId"></param>
        /// <returns></returns>
        public static bool VoegArtikelConnectieToe(int huurId,int ArtikelId)
        {
            try
            {
                Openconnecion();
                string str = "insert into Artikelen_huurcontract values(:bid , :hid , :hoeveel)";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
                cmd.Parameters.Add("bid", OracleDbType.Int16);
                cmd.Parameters["bid"].Value = ArtikelId;
                cmd.Parameters.Add("hid", OracleDbType.Int16);
                cmd.Parameters["hid"].Value = huurId;
                
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
        /// <summary>
        /// Voegt een connectie tussen de huurcontract en een boot toe
        /// </summary>
        /// <param name="huurId"></param>
        /// <param name="BootId"></param>
        /// <returns></returns>
        public static bool VoegBootConnectieToe(int huurId, string BootId)
        {
            try
            {
                Openconnecion();
                string str = "insert into boot_huurcontract values(:bid , :hid , :hoeveel )";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
                cmd.Parameters.Add("bid", OracleDbType.Varchar2);
                cmd.Parameters["bid"].Value = BootId;
                cmd.Parameters.Add("hid", OracleDbType.Int16);
                cmd.Parameters["hid"].Value = huurId;
              
                int? i = CheckBestaandBoot(huurId, BootId);
                
                if (i == null)
                {
                    i = 1;
                }
                cmd.Parameters.Add("hoeveel", OracleDbType.Int16);
                cmd.Parameters["hoeveel"].Value = i;
                
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Haal alle huurcontracten op
        /// </summary>
        /// <returns></returns>
        public static List<Huurcontract> KrijgHuurcontracts()
        {
            try
            {
                Openconnecion();
                List<Huurcontract> huurcontracten = new List<Huurcontract>();
                string str = "Select * from huurcontract";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    //Haalt de huurlijst op van elke gevonden huurcontract
                    List<Huur> huurl = Database.KrijgHuurLijst(Read.GetInt16(0));
                    Klant klant = Database.KrijgKlant(Read.GetInt16(1));
                    Huurcontract huur = new Huurcontract(Read.GetInt16(0), Read.GetDateTime(2),Read.GetDateTime(3),huurl, klant);
                    huurcontracten.Add(huur);
                }

                return huurcontracten;

            }
            catch (Exception)
            {
                return null;
            }
            
        }
        /// <summary>
        /// Geeft een klant met een bepaalde Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static Klant KrijgKlant(int id)
        {
            try
            {
                Openconnecion();
                string str = "select * from klant  where Id =  " + id;
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
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
        /// <summary>
        /// Geeft alle vaargebieden die er in de database staan
        /// </summary>
        /// <returns></returns>
        public static List<Vaargebieden> KrijgVaargebiedens()
        {
            try
            {
                Openconnecion();
                List<Vaargebieden> list = new List<Vaargebieden>();
                string str = "select * from Vaargebieden";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
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
        /// <summary>
        /// Krijg alle klanten in de database
        /// </summary>
        /// <returns></returns>
        public static List<Klant> KrijgKlanten()
        {
            try
            {
                Openconnecion();
                List<Klant> list = new List<Klant>();
                string str = "select * from Klant";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
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
        /// <summary>
        /// Krijg een lijst van alle objecten die gehuurd kunnen worden
        /// </summary>
        /// <returns></returns>
        public static List<Huur> KrijgHuurLijst()
        {
            try
            {
                Openconnecion();
                List<Huur> list = new List<Huur>();
                string str = "select * from Boot where motor = 0";
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Spierboot boot = new Spierboot(Read.GetString(0), Read.GetDecimal(2), Read.GetString(3));
                    list.Add(boot);
                }
                str = "select * from Boot where motor = 1";
                cmd = new OracleCommand(str);
                cmd.Connection = Conn;
                Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Motorboot boot = new Motorboot(Read.GetString(0), Read.GetDecimal(2), Read.GetString(3),
                        Read.GetInt16(1));
                    list.Add(boot);
                }

                str = "select * from Artikelen";
                cmd = new OracleCommand(str);
                cmd.Connection = Conn;
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
        /// <summary>
        /// Krijg alle huur objecten de gekoppeld staan aan een huurcontract
        /// </summary>
        /// <param name="id">Huurcontract ID</param>
        /// <returns></returns>
        public static List<Huur> KrijgHuurLijst(int id)
        {
            try
            {
                Openconnecion();
                List<Huur> list = new List<Huur>();
                string str = "select b.* from Boot b join Boot_huurcontract bh on bh.boot_ID = b.naam where b.motor = 0 and bh.huurcontract_ID = "+ id;
                OracleCommand cmd = new OracleCommand(str);
                cmd.Connection = Conn;
                OracleDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Spierboot boot = new Spierboot(Read.GetString(0), Read.GetDecimal(2), Read.GetString(3));
                    list.Add(boot);
                }
                str = "select b.* from Boot b join Boot_huurcontract bh  on bh.boot_ID = b.naam where b.motor = 1 and bh.huurcontract_ID = " + id;
                cmd = new OracleCommand(str);
                cmd.Connection = Conn;
                Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    Motorboot boot = new Motorboot(Read.GetString(0), Read.GetDecimal(2), Read.GetString(3),
                        Read.GetInt16(1));
                    list.Add(boot);
                }

                str = "select A.* from Artikelen A join Artikelen_huurcontract AH on   AH.Artikelen_ID = A.id where AH.Huurcontract_ID = " + id;
                cmd = new OracleCommand(str);
                cmd.Connection = Conn;
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
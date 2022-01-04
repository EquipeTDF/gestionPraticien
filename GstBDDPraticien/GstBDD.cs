using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GstClasses;

namespace GstBDDPraticien
{
    public class GstBDD
    {
        //objet pour lequel on va se co
        private MySqlConnection cnx;
        //écrire les requêtes
        private MySqlCommand cmd;
        //récupérer les données de type sql
        private MySqlDataReader dr;

        public GstBDD()
        {
            string chaine = "Server=localhost;Database=bddpraticien;Uid=root;Pwd=;SslMode=none";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Praticien> GetLesPraticiens()
        {
            // récupère tout les praticies dans la base de données et les instancies
            List<Praticien> mesPraticiens = new List<Praticien>();

            cmd = new MySqlCommand("SELECT praticien.PRA_NUM, praticien.PRA_NOM, praticien.PRA_PRENOM FROM praticien", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Praticien unPraticien = new Praticien(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString());
                mesPraticiens.Add(unPraticien);
            }
            dr.Close();
            return mesPraticiens;
        }

        public List<Specialite> GetSpecialitesDuPraticien(int unNumPraticien)
        {
            List<Specialite> mesSpecialites = new List<Specialite>();
            cmd = new MySqlCommand("SELECT specialite.SPE_LIBELLE FROM specialite INNER JOIN posseder ON specialite.SPE_CODE = posseder.SPE_CODE WHERE posseder.PRA_NUM ="+ unNumPraticien, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Specialite uneSpecialite = new Specialite(dr[0].ToString());
                mesSpecialites.Add(uneSpecialite);
            }
            dr.Close();
            return mesSpecialites;
        }

        public List<Activite> GetActivitesDuPraticien(int unNumPraticien)
        {
            List<Activite> mesActivites = new List<Activite>();
            cmd = new MySqlCommand("SELECT activite_compl.AC_THEME FROM activite_compl INNER JOIN inviter ON inviter.AC_NUM = activite_compl.AC_NUM WHERE inviter.PRA_NUM = " + unNumPraticien, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Activite uneActivite = new Activite(dr[0].ToString());
                mesActivites.Add(uneActivite);
            }
            dr.Close();
            return mesActivites;
        }
        public List<Specialite> GetSpecialitesNonPossedesDuPraticien(int unNumPraticien)
        {
            List<Specialite> mesSpecialites = new List<Specialite>();
            cmd = new MySqlCommand("SELECT specialite.SPE_LIBELLE FROM specialite WHERE specialite.SPE_LIBELLE NOT IN (SELECT specialite.SPE_LIBELLE FROM specialite INNER JOIN posseder ON specialite.SPE_CODE = posseder.SPE_CODE WHERE posseder.PRA_NUM =" + unNumPraticien + ")", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Specialite uneSpecialite = new Specialite(dr[0].ToString());
                mesSpecialites.Add(uneSpecialite);
            }
            dr.Close();
            return mesSpecialites;
        }

        public List<Activite> GetActivitesNonInvitesDuPraticien(int unNumPraticien)
        {
            List<Activite> mesActivites = new List<Activite>();
            cmd = new MySqlCommand("SELECT activite_compl.AC_THEME FROM activite_compl  WHERE activite_compl.AC_NUM NOT IN ( SELECT activite_compl.AC_NUM FROM activite_compl INNER JOIN inviter ON inviter.AC_NUM = activite_compl.AC_NUM WHERE inviter.PRA_NUM = " + unNumPraticien + ")", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Activite uneActivite = new Activite(dr[0].ToString());
                mesActivites.Add(uneActivite);
            }
            dr.Close();
            return mesActivites;
        }

        public void AjouterSpePraticien(int unNumPraticien, int unNumSpe, int estDiplome, int unCoef)
        {
            string connectionString = cnx.ConnectionString;

            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `posseder`(`PRA_NUM`, `SPE_CODE`, `POS_DIPLOME`, `POS_COEFPRESCRIPTION`) VALUES (@unNumPraticien, @unNumSpe, @estDiplome, @unCoef)";
                cmd.Parameters.AddWithValue("@unNumPraticien", Convert.ToInt16(unNumPraticien));
                cmd.Parameters.AddWithValue("@unNumSpe", Convert.ToInt16(unNumSpe));
                cmd.Parameters.AddWithValue("@estDiplome", Convert.ToInt16(estDiplome));
                cmd.Parameters.AddWithValue("@unCoef", Convert.ToInt16(unCoef));
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

    }

}

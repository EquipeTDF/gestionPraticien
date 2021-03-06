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
            string chaine = "Server=localhost;Database=bddpraticien ;Uid=root;Pwd=;SslMode=none";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Praticien> GetLesPraticiens()
        {
            //Récupère tout les praticiens dans la base de données et les instancies

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
            //Récupère les spécialités d'un praticien donné en fonction de son numéro

            List<Specialite> mesSpecialites = new List<Specialite>();
            cmd = new MySqlCommand("SELECT specialite.SPE_CODE, specialite.SPE_LIBELLE FROM specialite INNER JOIN posseder ON specialite.SPE_CODE = posseder.SPE_CODE WHERE posseder.PRA_NUM =" + unNumPraticien, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Specialite uneSpecialite = new Specialite(Convert.ToInt32(dr[0].ToString()), dr[1].ToString());
                mesSpecialites.Add(uneSpecialite);
            }
            dr.Close();
            return mesSpecialites;
        }

        public List<Activite> GetActivitesDuPraticien(int unNumPraticien)
        {
            //Récupère les Activités d'un pratiticien donné en fonction de son numéro

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
            //Récupère les spécialités du praticien donné en fonction de son numéro

            List<Specialite> mesSpecialites = new List<Specialite>();
            cmd = new MySqlCommand("SELECT specialite.SPE_CODE, specialite.SPE_LIBELLE FROM specialite WHERE specialite.SPE_LIBELLE NOT IN (SELECT specialite.SPE_LIBELLE FROM specialite INNER JOIN posseder ON specialite.SPE_CODE = posseder.SPE_CODE WHERE posseder.PRA_NUM =" + unNumPraticien + ")", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Specialite uneSpecialite = new Specialite(Convert.ToInt16(dr[0].ToString()) ,dr[1].ToString());
                mesSpecialites.Add(uneSpecialite);
            }
            dr.Close();
            return mesSpecialites;
        }

        public List<Activite> GetActivitesNonInvitesDuPraticien(int unNumPraticien)
        {
            //Récupère les activités où le praticien donné en fonction de son numéro n'a pas été invité

            List<Activite> mesActivites = new List<Activite>();
            cmd = new MySqlCommand("SELECT activite_compl.AC_NUM, activite_compl.AC_THEME FROM activite_compl  WHERE activite_compl.AC_NUM NOT IN ( SELECT activite_compl.AC_NUM FROM activite_compl INNER JOIN inviter ON inviter.AC_NUM = activite_compl.AC_NUM WHERE inviter.PRA_NUM = " + unNumPraticien + ")", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Activite uneActivite = new Activite(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                mesActivites.Add(uneActivite);
            }
            dr.Close();
            return mesActivites;
        }

        public void AjouterSpePraticien(int unNumPraticien, int unNumSpe, int estDiplome, int unCoef)
        {
            //Ajoute une spécialité à un praticien avec son coef et s'il possède le diplôme

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
        public void SupprimerSpePraticien(int unNumPraticien, int unNumSpe)
        {
            //Supprime la specialité d'un praticien donné en fonction de son numéro

            string connectionString = cnx.ConnectionString;

            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM `posseder` WHERE PRA_NUM = @unNumPraticien AND SPE_CODE = @unNumSpe";
                cmd.Parameters.AddWithValue("@unNumPraticien", Convert.ToInt16(unNumPraticien));
                cmd.Parameters.AddWithValue("@unNumSpe", Convert.ToInt16(unNumSpe));
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        public void AjouterActiviteAPraticien(int unNumPraticien, int unNumActivite, int estSpecialiste)
        {
            //Ajoute une activité à un praticien en spécifiant s'il est spécialiste de celle-ci

            string connectionString = cnx.ConnectionString;

            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `inviter`(`AC_NUM`, `PRA_NUM`, `SPECIALISTEON`) VALUES (@unNumActivite, @unNumPraticien, @estSpecialiste)";
                cmd.Parameters.AddWithValue("@unNumActivite", Convert.ToInt16(unNumActivite));
                cmd.Parameters.AddWithValue("@unNumPraticien", Convert.ToInt16(unNumPraticien));
                cmd.Parameters.AddWithValue("@estSpecialiste", Convert.ToInt16(estSpecialiste));
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }


        public List<Specialite> GetLesSpecialite()
        {
            //Récupère toutes les spécialités

            List<Specialite> lesSpecialites = new List<Specialite>();
            cmd = new MySqlCommand("SELECT SPE_CODE, SPE_LIBELLE FROM specialite", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Specialite uneSpecialite = new Specialite(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                lesSpecialites.Add(uneSpecialite);
            }
            dr.Close();
            return lesSpecialites;
        }

        public List<Praticien> GetNbSpeParPraticiens()
        {
            //Récupère le nom, le prénom et le nombre de spécialités pour chaque praticiens

            List<Praticien> lesSpeTotal = new List<Praticien>();
            cmd = new MySqlCommand("SELECT PRA_NOM, PRA_PRENOM, COUNT(pos.SPE_CODE) FROM praticien p INNER JOIN posseder pos ON p.PRA_NUM = pos.PRA_NUM GROUP BY p.PRA_NUM", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Praticien unPraticien = new Praticien(dr[0].ToString(), dr[1].ToString(), Convert.ToInt16(dr[2].ToString()));

                lesSpeTotal.Add(unPraticien);
            }
            dr.Close();
            return lesSpeTotal;
        }

        public List<Praticien> GetPraticienAvecLePlusDeSpe()
        {
            //Récupère les praticiens possédant le plus de spécialités

            List<Praticien> lesPraticiens = GetNbSpeParPraticiens();
            List<Praticien> lesPraticiensSpeMax = new List<Praticien>();

            int nbSpeMax = 0;
            foreach(Praticien p in lesPraticiens)
            {

                if (p.NombreDeSpe > nbSpeMax)
                {
                    nbSpeMax = p.NombreDeSpe;
                    lesPraticiensSpeMax.Clear();
                    lesPraticiensSpeMax.Add(p);
                }
                else if (p.NombreDeSpe == nbSpeMax)
                {
                    lesPraticiensSpeMax.Add(p);
                }
            }

            return lesPraticiensSpeMax;
        }

        public List<Praticien> GetPraticienAvecLeMoinsDeSpe()
        {
            //Récupère les praticiens possédant le moins de spécialtés

            List<Praticien> lesPraticiens = GetNbSpeParPraticiens();
            List<Praticien> lesPraticiensSpeMin = new List<Praticien>();

            int nbSpeMin = -1;
            foreach (Praticien p in lesPraticiens)
            {
                if (nbSpeMin == -1)
                {
                    nbSpeMin = p.NombreDeSpe;
                    lesPraticiensSpeMin.Clear();
                    lesPraticiensSpeMin.Add(p);
                    continue;
                }
                if (p.NombreDeSpe < nbSpeMin)
                {
                    nbSpeMin = p.NombreDeSpe;
                    lesPraticiensSpeMin.Clear();
                    lesPraticiensSpeMin.Add(p);
                }
                else if (p.NombreDeSpe == nbSpeMin)
                {
                    lesPraticiensSpeMin.Add(p);
                }
            }

            return lesPraticiensSpeMin;
        }

        public List<Praticien> GetPraticienAyantJamaisParticiperAUneActivite()
        {
            //Récupère les praticiens n'ayant jamais participé à une activité

            List<Praticien> lesPraticiensAyantJamaisParticiperAUneActivite = new List<Praticien>();
            cmd = new MySqlCommand("SELECT PRA_NUM, PRA_NOM, PRA_PRENOM FROM praticien WHERE PRA_NUM NOT IN (SELECT PRA_NUM FROM inviter)", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Praticien unPraticien = new Praticien(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString());
                lesPraticiensAyantJamaisParticiperAUneActivite.Add(unPraticien);
            }
            dr.Close();
            return lesPraticiensAyantJamaisParticiperAUneActivite;
        }

        public void UpdateSpe(int unNumero, string unNom)
        {
            //Modifie le nom (unNom) d'une spécialité définie par son numéro

            string connectionString = cnx.ConnectionString;

            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE `specialite` SET `SPE_LIBELLE`= @nom WHERE SPE_CODE=@speCode";
                cmd.Parameters.AddWithValue("@speCode", Convert.ToInt16(unNumero));
                cmd.Parameters.AddWithValue("@nom", unNom);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public void AjouterSpe(string unNom)
        {
            //Ajoute une spécialité à la base de données

            string connectionString = cnx.ConnectionString;

            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `specialite`(`SPE_LIBELLE`) VALUES (@nom)";
                cmd.Parameters.AddWithValue("@nom", unNom);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public double GetCoefNotorieteSup()
        {
            //Récupère le nombre de praticiens ayant un coefficient de notoriété supérieur à la moyenne

            double coefSup = 0;
            cmd = new MySqlCommand("SELECT COUNT(PRA_NUM) FROM praticien WHERE PRA_COEFNOTORIETE > (SELECT AVG(PRA_COEFNOTORIETE) FROM praticien)", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            coefSup = Convert.ToDouble(dr[0].ToString());
            dr.Close();

            return coefSup;
        }

        public double GetCoefNotorieteInf()
        {
            //Récupère le nombre de praticiens ayant un coefficient de notoriété inférieur à la moyenne

            double coefInf = 0;
            cmd = new MySqlCommand("SELECT COUNT(PRA_NUM) FROM praticien WHERE PRA_COEFNOTORIETE < (SELECT AVG(PRA_COEFNOTORIETE) FROM praticien)", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            coefInf = Convert.ToDouble(dr[0].ToString());
            dr.Close();

            return coefInf;
        }

        public List<GraphSpeParPraticien> GetLeGrafNbSpeParPraticien()
        {
            //Renvoie les particiens avec leurs nombre de spécialisations

            List<GraphSpeParPraticien> lesGraphs = new List<GraphSpeParPraticien>();
            cmd = new MySqlCommand("SELECT PRA_NOM, COUNT(pos.SPE_CODE) FROM praticien p INNER JOIN posseder pos ON p.PRA_NUM = pos.PRA_NUM GROUP BY p.PRA_NUM", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                GraphSpeParPraticien leGraph = new GraphSpeParPraticien(dr[0].ToString(), Convert.ToInt16(dr[1].ToString()));

                lesGraphs.Add(leGraph);
            }
            dr.Close();
            return lesGraphs;
        }

        public List<GraphSpeParPraticien> GetLeGrafNbSpeParPraticienMax()
        {
            //Renvoie les praticiens ayant le plus de spécialisations avec leur spécialisation

            List<GraphSpeParPraticien> lesGraphs = new List<GraphSpeParPraticien>();
            foreach (Praticien p in GetPraticienAvecLePlusDeSpe())
            {
                GraphSpeParPraticien leGraph = new GraphSpeParPraticien(dr[0].ToString(), Convert.ToInt16(dr[1].ToString()));

                lesGraphs.Add(leGraph);
            }
            return lesGraphs;
        }
    }
}

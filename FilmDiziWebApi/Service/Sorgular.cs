using System.Data;
using System.Data.SqlClient;

namespace FilmDiziWebApi.Service
{
    public class Sorgular
    {
        public static DataTable Listele(string sr)
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format(sr), Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Listele(string sr,int id)
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format(sr), Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Listele(string sr, string ad, int id, int adet)
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format(sr), Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@ad", ad);
            adp.SelectCommand.Parameters.AddWithValue("@id", id);
            adp.SelectCommand.Parameters.AddWithValue("@adet", adet);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Listele(string sr, float imdbmin,float imdbmax,int yilmin,int yilmax, int id, int adet)
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format(sr), Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@id", id);
            adp.SelectCommand.Parameters.AddWithValue("@adet", adet);
            adp.SelectCommand.Parameters.AddWithValue("@imdbmin", imdbmin);
            adp.SelectCommand.Parameters.AddWithValue("@imdbmax", imdbmax);
            adp.SelectCommand.Parameters.AddWithValue("@yilmin", yilmin);
            adp.SelectCommand.Parameters.AddWithValue("@yilmax", yilmax);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Listele(string sr, float imdbmin, float imdbmax, int yilmin, int yilmax, int id, int adet, int kategoriid)
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format(sr), Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@id", id);
            adp.SelectCommand.Parameters.AddWithValue("@adet", adet);
            adp.SelectCommand.Parameters.AddWithValue("@imdbmin", imdbmin);
            adp.SelectCommand.Parameters.AddWithValue("@imdbmax", imdbmax);
            adp.SelectCommand.Parameters.AddWithValue("@yilmin", yilmin);
            adp.SelectCommand.Parameters.AddWithValue("@yilmax", yilmax);
            adp.SelectCommand.Parameters.AddWithValue("@kategoriid", kategoriid);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static void IzlemeGuncelle(string sr, int id)
        {
            SqlCommand cmd = new SqlCommand(string.Format(sr), Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            Tools.Exec(cmd);
        }

        public static bool BegeniGuncelle(string sr, int id, int begeni)
        {
            SqlCommand cmd = new SqlCommand(string.Format(sr), Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@begeni", begeni);
            return Tools.Exec(cmd);
        }

        public static bool BegeniGonder(string sr, int id, int begeni)
        {
            SqlCommand cmd = new SqlCommand(string.Format(sr), Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@begeni", begeni);
            return Tools.Exec(cmd);
        }

    }
}
using FilmDiziWebApi.Models;
using FilmDiziWebApi.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace FilmDiziWebApi.Controllers
{
    public class FilmController : ApiController
    {

        public List<Film> GetFilmleriListele(float imdbmin, float imdbmax, int yilmin, int yilmax, int id = 0, int adet = 10)
        {
            List<Film> filmler = new List<Film>();
            DataTable dt;
            if (id == 0)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select  top 1 FilmID from Film order by FilmID desc", Tools.Baglanti);
                dt = new DataTable();
                adp.Fill(dt);
                int filmid = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    filmid = Convert.ToInt32(dr[0].ToString());
                }
                dt = Sorgular.Listele("GetFilmleriListele", imdbmin, imdbmax, yilmin, yilmax, filmid, adet);
            }
            else
            {             
                dt = Sorgular.Listele("GetFilmleriListele", imdbmin, imdbmax, yilmin, yilmax, id, adet);             
            }
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                byte[] result = (byte[])dr[2];
                f.FilmKapakFoto = result;
                f.FilmAltYazi = Convert.ToBoolean(dr[3]);
                f.FilmBaslik = dr[4].ToString();
                f.FilmKonu = dr[5].ToString();
                f.FilmYapimYili = dr[6].ToString();
                f.FilmDil = dr[7].ToString();
                f.FilmIMDB = dr[8].ToString();
                f.FilmSure = dr[9].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[10].ToString());
                f.FilmBegeniOrani = Convert.ToSingle(dr[11].ToString());
                f.FilmKategoriler = dr[12].ToString();
                f.FilmOyuncular = dr[13].ToString();
                f.FilmYonetmenler = dr[14].ToString();
                filmler.Add(f);
            }
            return filmler;
        }

        public List<Film> GetKategoriliFilmleriListele(float imdbmin, float imdbmax, int yilmin, int yilmax, int kategoriid, int id = 0, int adet = 10)
        {
            List<Film> filmler = new List<Film>();
            DataTable dt;
            if (id == 0)
            {
                string asd = "select top 1 f.FilmID from Film f, FilmKategoriler fk where f.FilmYapimYili >= @yilmin and f.FilmYapimYili <= @yilmax and CONVERT(float, f.FilmIMDB)>= @imdbmin and CONVERT(float, f.FilmIMDB)<= @imdbmax and f.FilmID = fk.FilmID and fk.KategoriID = @kategoriid order by FilmID desc";
                SqlDataAdapter adp = new SqlDataAdapter(asd, Tools.Baglanti);
                adp.SelectCommand.Parameters.AddWithValue("@imdbmin", imdbmin);
                adp.SelectCommand.Parameters.AddWithValue("@imdbmax", imdbmax);
                adp.SelectCommand.Parameters.AddWithValue("@yilmin", yilmin);
                adp.SelectCommand.Parameters.AddWithValue("@yilmax", yilmax);
                adp.SelectCommand.Parameters.AddWithValue("@kategoriid", kategoriid);
                dt = new DataTable();
                adp.Fill(dt);
                int filmid = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    filmid = Convert.ToInt32(dr[0].ToString());
                }
                dt = Sorgular.Listele("GetKategoriliFilmleriListele", imdbmin, imdbmax, yilmin, yilmax, filmid, adet, kategoriid);
            }
            else
            {
                dt = Sorgular.Listele("GetKategoriliFilmleriListele", imdbmin, imdbmax, yilmin, yilmax, id, adet, kategoriid);
            }
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                byte[] result = (byte[])dr[2];
                f.FilmKapakFoto = result;
                f.FilmAltYazi = Convert.ToBoolean(dr[3]);
                f.FilmBaslik = dr[4].ToString();
                f.FilmKonu = dr[5].ToString();
                f.FilmYapimYili = dr[6].ToString();
                f.FilmDil = dr[7].ToString();
                f.FilmIMDB = dr[8].ToString();
                f.FilmSure = dr[9].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[10].ToString());
                f.FilmBegeniOrani = Convert.ToSingle(dr[11].ToString());
                f.FilmKategoriler = dr[12].ToString();
                f.FilmOyuncular = dr[13].ToString();
                f.FilmYonetmenler = dr[14].ToString();
                filmler.Add(f);
            }
            return filmler;
        }

        public List<Film> GetFilmListele(int id = 0)
        {
            List<Film> filmler = new List<Film>();
            DataTable dt = Sorgular.Listele("GetFilmListele", id);
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                byte[] result = (byte[])dr[2];
                f.FilmKapakFoto = result;
                f.FilmAltYazi = Convert.ToBoolean(dr[3]);
                f.FilmBaslik = dr[4].ToString();
                f.FilmKonu = dr[5].ToString();
                f.FilmYapimYili = dr[6].ToString();
                f.FilmDil = dr[7].ToString();
                f.FilmIMDB = dr[8].ToString();
                f.FilmSure = dr[9].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[10].ToString());
                f.FilmBegeniOrani = Convert.ToSingle(dr[11].ToString());
                f.FilmKategoriler = dr[12].ToString();
                f.FilmOyuncular = dr[13].ToString();
                f.FilmYonetmenler = dr[14].ToString();
                filmler.Add(f);
            }
            return filmler;
        }

        public List<Film> GetFilmleriAra(string ad, int id = 0, int adet = 10)
        {
            List<Film> filmler = new List<Film>();
            DataTable dt = Sorgular.Listele("GetFilmleriAra",ad, id, adet);
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                byte[] result = (byte[])dr[2];
                f.FilmKapakFoto = result;
                f.FilmAltYazi = Convert.ToBoolean(dr[3]);
                f.FilmBaslik = dr[4].ToString();
                f.FilmKonu = dr[5].ToString();
                f.FilmYapimYili = dr[6].ToString();
                f.FilmDil = dr[7].ToString();
                f.FilmIMDB = dr[8].ToString();
                f.FilmSure = dr[9].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[10].ToString());
                f.FilmBegeniOrani = Convert.ToSingle(dr[11].ToString());
                f.FilmKategoriler = dr[12].ToString();
                f.FilmOyuncular = dr[13].ToString();
                f.FilmYonetmenler = dr[14].ToString();
                filmler.Add(f);
            }
            return filmler;
        }

        public List<FilmKategori> GetFilmKategorileriListele()
        {
            List<FilmKategori> filmkategoriler = new List<FilmKategori>();
            DataTable dt = Sorgular.Listele("GetFilmKategorileriListele");
            foreach (DataRow dr in dt.Rows)
            {
                FilmKategori fk = new FilmKategori();
                fk.FilmKategoriID = Convert.ToInt32(dr[0].ToString());
                fk.FilmID = Convert.ToInt32(dr[1].ToString());
                fk.KategoriID = Convert.ToInt32(dr[2].ToString());
                filmkategoriler.Add(fk);
            }
            return filmkategoriler;
        }

        public List<Film> GetKategoriyeGoreFilmleriListele(int id)
        {
            List<Film> filmler = new List<Film>();
            DataTable dt = Sorgular.Listele("GetKategoriyeGoreFilmleriListele",id);
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                byte[] result = (byte[])dr[2];
                f.FilmKapakFoto = result;
                f.FilmAltYazi = Convert.ToBoolean(dr[3]);
                f.FilmBaslik = dr[4].ToString();
                f.FilmKonu = dr[5].ToString();
                f.FilmYapimYili = dr[6].ToString();
                f.FilmDil = dr[7].ToString();
                f.FilmIMDB = dr[8].ToString();
                f.FilmSure = dr[9].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[10].ToString());
                f.FilmBegeniOrani = Convert.ToSingle(dr[11].ToString());
                f.FilmKategoriler = dr[12].ToString();
                f.FilmOyuncular = dr[13].ToString();
                f.FilmYonetmenler = dr[14].ToString();
                filmler.Add(f);
            }
            return filmler;
        }

        public List<Film> GetCokBegenilenFilmleriListele()
        {
            List<Film> filmler = new List<Film>();
            DataTable dt = Sorgular.Listele("GetCokBegenilenFilmleriListele");
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                byte[] result = (byte[])dr[2];
                f.FilmKapakFoto = result;
                f.FilmAltYazi = Convert.ToBoolean(dr[3]);
                f.FilmBaslik = dr[4].ToString();
                f.FilmKonu = dr[5].ToString();
                f.FilmYapimYili = dr[6].ToString();
                f.FilmDil = dr[7].ToString();
                f.FilmIMDB = dr[8].ToString();
                f.FilmSure = dr[9].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[10].ToString());
                f.FilmBegeniOrani = Convert.ToSingle(dr[11].ToString());
                f.FilmKategoriler = dr[12].ToString();
                f.FilmOyuncular = dr[13].ToString();
                f.FilmYonetmenler = dr[14].ToString();
                filmler.Add(f);
            }
            return filmler;
        }
        
        public List<Film> GetCokIzlenenFilmleriListele()
        {
            List<Film> filmler = new List<Film>();
            DataTable dt = Sorgular.Listele("GetCokIzlenenFilmleriListele");
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                byte[] result = (byte[])dr[2];
                f.FilmKapakFoto = result;
                f.FilmAltYazi = Convert.ToBoolean(dr[3]);
                f.FilmBaslik = dr[4].ToString();
                f.FilmKonu = dr[5].ToString();
                f.FilmYapimYili = dr[6].ToString();
                f.FilmDil = dr[7].ToString();
                f.FilmIMDB = dr[8].ToString();
                f.FilmSure = dr[9].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[10].ToString());
                f.FilmBegeniOrani = Convert.ToSingle(dr[11].ToString());
                f.FilmKategoriler = dr[12].ToString();
                f.FilmOyuncular = dr[13].ToString();
                f.FilmYonetmenler = dr[14].ToString();
                filmler.Add(f);
            }
            return filmler;
        }

        public List<Film> GetSonEklenenFilmleriListele()
        {
            List<Film> filmler = new List<Film>();
            DataTable dt = Sorgular.Listele("GetSonEklenenFilmleriListele");
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                byte[] result = (byte[])dr[2];
                f.FilmKapakFoto = result;
                f.FilmAltYazi = Convert.ToBoolean(dr[3]);
                f.FilmBaslik = dr[4].ToString();
                f.FilmKonu = dr[5].ToString();
                f.FilmYapimYili = dr[6].ToString();
                f.FilmDil = dr[7].ToString();
                f.FilmIMDB = dr[8].ToString();
                f.FilmSure = dr[9].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[10].ToString());
                f.FilmBegeniOrani = Convert.ToSingle(dr[11].ToString());
                f.FilmKategoriler = dr[12].ToString();
                f.FilmOyuncular = dr[13].ToString();
                f.FilmYonetmenler = dr[14].ToString();
                filmler.Add(f);
            }
            return filmler;
        }

        public List<Kategoriler> GetKategorileriListele()
        {
            List<Kategoriler> kategoriler = new List<Kategoriler>();
            DataTable dt = Sorgular.Listele("GetKategorileriListele");
            foreach (DataRow dr in dt.Rows)
            {
                Kategoriler k = new Kategoriler();
                k.KategoriID = Convert.ToInt32(dr[0].ToString());
                k.KategoriUstID = Convert.ToInt32(dr[1].ToString());
                k.KategoriAd = dr[2].ToString();
                kategoriler.Add(k);
            }
            return kategoriler;
        }

        public void GetFilmIzlenmeGuncelle(int id)
        {
            Sorgular.IzlemeGuncelle("PostFilmIzlenmeUpdate", id);
        }

        public bool GetFilmBegeniGuncelle(int id, int begeni)
        {
            return Sorgular.BegeniGuncelle("PostFilmBegeniUpdate", id,begeni);
        }

        public bool GetFilmBegeniGonder(int id, int begeni)
        {
            return Sorgular.BegeniGuncelle("PostFilmBegeniInsert", id, begeni);
        }

        public List<Film> GetFilmler()
        {
            List<Film> filmler = new List<Film>();
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("select * from Deneme"), Tools.Baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Film f = new Film();
                f.FilmID = Convert.ToInt32(dr[0].ToString());
                f.FilmLink = dr[1].ToString();
                f.FilmBaslik = dr[2].ToString();
                f.FilmKonu = dr[3].ToString();
                f.FilmAltYazi = Convert.ToBoolean(dr[4]);              
                f.FilmYapimYili = dr[5].ToString();
                f.FilmDil = dr[6].ToString();
                f.FilmIMDB = dr[7].ToString();
                f.FilmSure = dr[8].ToString();
                f.FilmIzlenmeSayisi = Convert.ToInt32(dr[9].ToString());
                filmler.Add(f);
            }
            return filmler;
        }
    
    }
}

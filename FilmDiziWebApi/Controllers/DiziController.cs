using FilmDiziWebApi.Models;
using FilmDiziWebApi.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace FilmDiziWebApi.Controllers
{
    public class DiziController : ApiController
    {
        public List<Dizi> GetDizileriListele(float imdbmin, float imdbmax, int yilmin, int yilmax, int id = 0, int adet = 10)
        {
            List<Dizi> diziler = new List<Dizi>();
            DataTable dt;
            if (id == 0)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select  top 1 DiziID from Dizi order by DiziID desc", Tools.Baglanti);
                dt = new DataTable();
                adp.Fill(dt);
                int diziid = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    diziid = Convert.ToInt32(dr[0].ToString());
                }
                dt = Sorgular.Listele("GetDizileriListele", imdbmin, imdbmax, yilmin, yilmax, diziid, adet);
            }
            else
            {
                dt = Sorgular.Listele("GetDizileriListele", imdbmin, imdbmax, yilmin, yilmax, id, adet);
            }
            foreach (DataRow dr in dt.Rows)
            {
                Dizi d = new  Dizi();
                d.DiziID = Convert.ToInt32(dr[0].ToString());
                byte[] result = (byte[])dr[1];
                d.DiziKapakFoto = result;
                d.DiziBaslik = dr[2].ToString();
                d.DiziKonu = dr[3].ToString();
                d.DiziBaslangicYili = dr[4].ToString();
                d.DiziIMDB = dr[5].ToString();
                d.DiziIzlenmeSayisi = Convert.ToInt32(dr[6].ToString());
                d.DiziBegeniOrani = Convert.ToSingle(dr[7].ToString());
                d.DiziOyuncular = dr[8].ToString();
                d.DiziYonetmenler = dr[9].ToString();
                diziler.Add(d);
            }
            return diziler;
        }

        public List<Dizi> GetDiziListele(int id = 0)
        {
            List<Dizi> diziler = new List<Dizi>();
            DataTable dt = Sorgular.Listele("GetDiziListele", id);
            foreach (DataRow dr in dt.Rows)
            {
                Dizi d = new Dizi();
                d.DiziID = Convert.ToInt32(dr[0].ToString());
                byte[] result = (byte[])dr[1];
                d.DiziKapakFoto = result;
                d.DiziBaslik = dr[2].ToString();
                d.DiziKonu = dr[3].ToString();
                d.DiziBaslangicYili = dr[4].ToString();
                d.DiziIMDB = dr[5].ToString();
                d.DiziIzlenmeSayisi = Convert.ToInt32(dr[6].ToString());
                d.DiziBegeniOrani = Convert.ToSingle(dr[7].ToString());
                d.DiziOyuncular = dr[8].ToString();
                d.DiziYonetmenler = dr[9].ToString();
                diziler.Add(d);
            }
            return diziler;
        }

        public List<Dizi> GetDizileriAra(string ad, int id = 0, int adet = 10)
        {
            List<Dizi> diziler = new List<Dizi>();
            DataTable dt = Sorgular.Listele("GetDizileriAra", ad, id, adet);
            foreach (DataRow dr in dt.Rows)
            {
                Dizi d = new Dizi();
                d.DiziID = Convert.ToInt32(dr[0].ToString());
                byte[] result = (byte[])dr[1];
                d.DiziKapakFoto = result;
                d.DiziBaslik = dr[2].ToString();
                d.DiziKonu = dr[3].ToString();
                d.DiziBaslangicYili = dr[4].ToString();
                d.DiziIMDB = dr[5].ToString();
                d.DiziIzlenmeSayisi = Convert.ToInt32(dr[6].ToString());
                d.DiziBegeniOrani = Convert.ToSingle(dr[7].ToString());
                d.DiziOyuncular = dr[8].ToString();
                d.DiziYonetmenler = dr[9].ToString();
                diziler.Add(d);
            }
            return diziler;
        }

        public List<DiziBolum> GetBolumleriListele(int id)
        {
            List<DiziBolum> bolumler = new List<DiziBolum>();
            DataTable dt = Sorgular.Listele("GetBolumleriListele",id);
            foreach (DataRow dr in dt.Rows)
            {
                DiziBolum db = new DiziBolum();
                db.DiziBolumID = Convert.ToInt32(dr[0].ToString());
                db.DiziID = Convert.ToInt32(dr[1].ToString());
                db.DiziBolumLink = dr[2].ToString();
                db.DiziBolumBaslik = dr[3].ToString();
                db.DiziBolumSezonNo = dr[4].ToString();
                bolumler.Add(db);
            }
            return bolumler;
        }
        
        public List<Dizi> GetCokBegenilenDizileriListele()
        {
            List<Dizi> diziler = new List<Dizi>();
            DataTable dt = Sorgular.Listele("GetCokBegenilenDizileriListele");
            foreach (DataRow dr in dt.Rows)
            {
                Dizi d = new Dizi();
                d.DiziID = Convert.ToInt32(dr[0].ToString());
                byte[] result = (byte[])dr[1];
                d.DiziKapakFoto = result;
                d.DiziBaslik = dr[2].ToString();
                d.DiziKonu = dr[3].ToString();
                d.DiziBaslangicYili = dr[4].ToString();
                d.DiziIMDB = dr[5].ToString();
                d.DiziIzlenmeSayisi = Convert.ToInt32(dr[6].ToString());
                d.DiziBegeniOrani = Convert.ToSingle(dr[7].ToString());
                d.DiziOyuncular = dr[8].ToString();
                d.DiziYonetmenler = dr[9].ToString();
                diziler.Add(d);
            }
            return diziler;
        }

        public List<Dizi> GetCokIzlenenDizileriListele()
        {
            List<Dizi> diziler = new List<Dizi>();
            DataTable dt = Sorgular.Listele("GetCokIzlenenDizileriListele");
            foreach (DataRow dr in dt.Rows)
            {
                Dizi d = new Dizi();
                d.DiziID = Convert.ToInt32(dr[0].ToString());
                byte[] result = (byte[])dr[1];
                d.DiziKapakFoto = result;
                d.DiziBaslik = dr[2].ToString();
                d.DiziKonu = dr[3].ToString();
                d.DiziBaslangicYili = dr[4].ToString();
                d.DiziIMDB = dr[5].ToString();
                d.DiziIzlenmeSayisi = Convert.ToInt32(dr[6].ToString());
                d.DiziBegeniOrani = Convert.ToSingle(dr[7].ToString());
                d.DiziOyuncular = dr[8].ToString();
                d.DiziYonetmenler = dr[9].ToString();
                diziler.Add(d);
            }
            return diziler;
        }

        public List<Dizi> GetSonEklenenDizileriListele()
        {
            List<Dizi> diziler = new List<Dizi>();
            DataTable dt = Sorgular.Listele("GetSonEklenenDizileriListele");
            foreach (DataRow dr in dt.Rows)
            {
                Dizi d = new Dizi();
                d.DiziID = Convert.ToInt32(dr[0].ToString());
                byte[] result = (byte[])dr[1];
                d.DiziKapakFoto = result;
                d.DiziBaslik = dr[2].ToString();
                d.DiziKonu = dr[3].ToString();
                d.DiziBaslangicYili = dr[4].ToString();
                d.DiziIMDB = dr[5].ToString();
                d.DiziIzlenmeSayisi = Convert.ToInt32(dr[6].ToString());
                d.DiziBegeniOrani = Convert.ToSingle(dr[7].ToString());
                d.DiziOyuncular = dr[8].ToString();
                d.DiziYonetmenler = dr[9].ToString();
                diziler.Add(d);
            }
            return diziler;
        }

        public void GetDiziIzlenmeGuncelle(int id)
        {
            Sorgular.IzlemeGuncelle("PostDiziBolumIzlenmeUpdate", id);
        }

        public bool GetDiziBegeniGuncelle(int id, int begeni)
        {
            return Sorgular.BegeniGuncelle("PostDiziBegeniUpdate", id, begeni);
        }

        public bool GetDiziBegeniGonder(int id, int begeni)
        {
            return Sorgular.BegeniGuncelle("PostDiziBegeniInsert", id, begeni);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace FilmDiziWebApi.Models
{
    public class Film
    {
        public int FilmID { get; set; }

        public string FilmLink { get; set; }

        public string FilmBaslik { get; set; }

        public string FilmKonu { get; set; }

        public byte[] FilmKapakFoto { get; set; }

        public bool FilmAltYazi { get; set; }

        public string FilmYapimYili { get; set; }

        public string FilmDil { get; set; }

        public string FilmIMDB { get; set; }

        public string FilmSure { get; set; }

        public int FilmIzlenmeSayisi { get; set; }

        public float FilmBegeniOrani { get; set; }

        public int FilmEkleyenID { get; set; }

        public string FilmKategoriler { get; set; }

        public string FilmOyuncular { get; set; }

        public string FilmYonetmenler { get; set; }

    }
}
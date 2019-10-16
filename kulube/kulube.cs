using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace kulube
{
    class kulube
    {
        private String KulubeAdi;
        private String KulubeSu;
        private String KulubeYemek;
        private String KulubeHava;
        private int KulubeTemp;
        private String KulubeKoordinat;

        public String mKulubeAdi
        {
            get { return KulubeAdi; }
            set { KulubeAdi = value; }
        }

        public String mKulubeSu
        {
            get { return KulubeSu; }
            set { KulubeSu = value; }
        }

        public String mKulubeYemek
        {
            get { return KulubeYemek; }
            set { KulubeYemek = value; }
        }

        public int mKulubeTemp
        {
            get { return KulubeTemp; }
            set { KulubeTemp = value; }
        }

        public String mKulubeHava
        {
            get { return KulubeHava; }
            set { KulubeHava = value; }
        }

        public String mKulubeKoordinat
        {
            get { return KulubeKoordinat; }
            set { KulubeKoordinat = value; }
        }

        public void KulubeHavaDurumu()
        {
            if(this.KulubeTemp <= 10)
            {
                this.KulubeHava = "USUYORUM " + KulubeTemp + "C" ;
            }
            else if(this.KulubeTemp >= 30)
            {
                this.KulubeHava = "COK SICAK " + KulubeTemp + "C";
            }
            else
            {
                this.KulubeHava = "HAVA GUZEL " + KulubeTemp + "C";
            }
        }


    }
}
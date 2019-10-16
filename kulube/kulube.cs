using System;

namespace kulube
{
    class kulube
    {
        private String KulubeAdi;
        private String KulubeSu;
        private String KulubeYemek;
        private String KulubeHava;
        private int KulubeTemp;
        private int KulubeGirisCikis;

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

        public int mKulubeGirisCikis
        {
            get { return KulubeGirisCikis; }
            set { KulubeGirisCikis = value; }
        }

        public String mKulubeHava
        {
            get { return KulubeHava; }
            set { KulubeHava = value; }
        }

        public void KulubeHavaDurumu()
        {
            KulubeHava = "Sıcaklık : " + KulubeTemp + "°C" ;
        }


    }
}
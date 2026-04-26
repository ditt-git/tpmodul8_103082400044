using System;
using tpmodul8_103082400044;

namespace tpmodul8_103082400036
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();


            JalankanAplikasi(covidConfig);


            Console.WriteLine("\n--- Memanggil Method UbahSatuan ---");
            covidConfig.UbahSatuan();


            JalankanAplikasi(covidConfig);
        }

        static void JalankanAplikasi(CovidConfig covidConfig)
        {
            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
            int hariDemam = Convert.ToInt32(Console.ReadLine());

            bool suhuValid = false;

            if (covidConfig.config.satuan_suhu == "celcius")
            {
                if (suhu >= 36.5 && suhu <= 37.5)
                {
                    suhuValid = true;
                }
            }
            else if (covidConfig.config.satuan_suhu == "fahrenheit")
            {
                if (suhu >= 97.7 && suhu <= 99.5)
                {
                    suhuValid = true;
                }
            }

            if (suhuValid && hariDemam < covidConfig.config.batas_hari_deman)
            {
                Console.WriteLine(covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(covidConfig.config.pesan_ditolak);
            }
        }
    }
}
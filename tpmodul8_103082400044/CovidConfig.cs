using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace tpmodul8_103082400044
{
    public class ConfigData
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public ConfigData() { }

        public ConfigData(string satuan_suhu, int batas_hari_deman, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_deman = batas_hari_deman;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
    }

    public class CovidConfig
    {
        public ConfigData config;
        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<ConfigData>(configJsonData);
        }

        private void SetDefault()
        {
            config = new ConfigData(
                "celcius",
                14,
                "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            );
        }

        private void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu == "celcius")
            {
                config.satuan_suhu = "fahrenheit";
            }
            else
            {
                config.satuan_suhu = "celcius";
            }
            WriteConfigFile();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreyaPrototipo
{
    class Config
    {
        public static List<string> keys;
        public static ConfigENT ConfigKeys;

        static Config()
        {

            keys = new List<string>();
            ConfigKeys = new ConfigENT();
            string[] lines = System.IO.File.ReadAllLines(@"C:\freyaConfig.txt");
            foreach (string line in lines)
            {
                keys.Add(line);
            }

            if (keys.Count > 3)
            {
                ConfigKeys.url = keys[0];
                ConfigKeys.diretorio = keys[1];
                ConfigKeys.prefixo = keys[2];
                ConfigKeys.tempo = keys[3];
            }
        }
    }

    class ConfigENT
    {
        public string url;
        public string diretorio;
        public string prefixo;
        public string tempo;
    }
}

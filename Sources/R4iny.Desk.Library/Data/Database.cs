using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace R4iny.Desk.Library.Data
{
    public class Database : JsonSerializable
    {
        [JsonIgnore]
        public string DatabasePath { get; set; }
        public string RootPath { get; set; }

        public List<Entry> Entries { get; set; } = new List<Entry>();

        public static Database Load(string path, bool forcedReset = false)
        {
            bool failFlag = false;
            string rawString;
            if (File.Exists(path))
            {
                rawString = File.ReadAllText(path, Encoding.Default);
            }
            else
            {
                rawString = "";
                failFlag = true;
            }

            Database db = null;
            if (!failFlag)
            {
                try
                {
                    db = JsonConvert.DeserializeObject<Database>(rawString, JsonSerializable.JsonSerializerSetting);
                    if (db != null)
                    {
                        db.DatabasePath = path;
                    }
                }
                catch
                {
                    failFlag = true;
                }
            }

            if (db == null) failFlag = true;

            if (failFlag)
            {
                if (!forcedReset) return null;

                return Database.Reset(path);
            }

            return db;
        }

        public static Database Reset(string path)
        {
            Database db = new Database()
            {
                DatabasePath = path,
            };

            db.Save();

            return db;
        }

        public int Save()
        {
            File.WriteAllText(this.DatabasePath, this.ToString(true));

            return 0;
        }

        public int AddEntry(Entry entry)
        {
            this.Entries.Add(entry);

            return 0;
        }

        //public int FindEntry(string message)
        //{


        //    return 0;
        //}

        //public int DeleteEntry(string id)
        //{


        //    return 0;
        //}

        //public int SearchEntry(string pattern)
        //{


        //    return 0;
        //}
    }
}

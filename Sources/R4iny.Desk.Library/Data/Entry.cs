using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4iny.Desk.Library.Data
{
    public class Entry : JsonSerializable
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public Entry()
        {
            this.Id = Guid.NewGuid();
        }

        public Entry(string name) : this()
        {
            this.Name = name;
        }

        public static void Save(Entry entry)
        {

        }

        public void Save()
        {
            Entry.Save(this);
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PULSE_Web.Models
{
    public class PULSEModuleDB : DbContext
    {
        public PULSEModuleDB() : base("name=PULSEModuleDB")
        {
        }

        public virtual DbSet<Module> Modules { get; set; }
    }

    public class Module
    {
        [Key]
        public int ModuleID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string DatePublished { get; set; }
        public string Description { get; set; }
        public string DLLFilename { get; set; }
        public string Blueprint { get; set; }
        public byte[] ModulePic { get; set; }
        public virtual ICollection<ModuleFunc> Funcs { get; set; }

        public class ModuleFunc
        {
            [Key]
            public string Name { get; set; }
            public string Command { get; set; }
            public virtual ICollection<FuncParam> Params { get; set; }

            public class FuncParam
            {
                [Key]
                public string Name { get; set; }
                public string DataType { get; set; }
            }
        }

    }
}
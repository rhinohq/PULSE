using System;
using System.Collections.Generic;

namespace PULSE
{
	public static class Modules
	{
        public class Module
        {
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
                public string Name { get; set; }
                public string Command { get; set; }
                public virtual ICollection<FuncParam> Params { get; set; }

                public class FuncParam
                {
                    public string Name { get; set; }
                    public string DataType { get; set; }
                }
            }

        }
    }
}


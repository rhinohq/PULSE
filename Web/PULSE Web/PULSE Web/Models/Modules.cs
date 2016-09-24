using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PULSE_Web.Models
{
    public static class Modules
    {
        private static PULSEModuleDB ModuleDB = new PULSEModuleDB();

        public static void ProcessPublicModule(string FilePath, string FileName)
        {
            Module NewModule;
            string ExtractPath = FilePath.Substring(FilePath.Length - FileName.Length, FilePath.Length) + "tmp";

            ZipFile.ExtractToDirectory(FilePath, ExtractPath);

            FileName = ExtractPath + "\\Meta.json";

            JsonSerializerSettings JSONSettings = new JsonSerializerSettings();
            JSONSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            NewModule = (Module)JsonConvert.DeserializeObject(File.ReadAllText(FileName), JSONSettings);

            ModuleDB.Modules.Add(NewModule);
            ModuleDB.SaveChangesAsync();
        }
    }
}
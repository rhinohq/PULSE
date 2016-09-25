using System;
using System.Collections.Generic;
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
        private static PULSEUserDB UserDB = new PULSEUserDB();

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

            Directory.Delete(ExtractPath, true);
        }

        public static List<Module> GetPublicModules()
        {
            return ModuleDB.Modules.Where(x => x.Public == true).ToList();
        }

        public static List<Module> GetUserActiveModules(string Username)
        {
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (user != null)
                return user.ActiveModules.ToList();
            else
                return null;
        }

        public static List<Module> GetUserModules(string Username)
        {
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (user != null)
                return user.AllModules.ToList();
            else
                return null;
        }

        public static void AddModuleToUser(string Username, int ModuleID)
        {
            Module module = ModuleDB.Modules.Where(x => x.ModuleID == ModuleID).FirstOrDefault();
            User user = UserDB.Users.Where(x => x.Username == Username).FirstOrDefault();

            if (module != null && user != null)
            {
                user.AllModules.Add(module);
                user.ActiveModules.Add(module);

                UserDB.SaveChangesAsync();
            }
        }
    }
}
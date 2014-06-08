using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace SmartGUI.Settings
{
    public class GlobalSettings
    {
        private bool _useMultithreading;
        private string _searchLevel;
        private bool _useProfiles;
        private string _profileSelected;
        private string _defaultPath;
        private string _username;

        public bool UseMultithreading
        {
            get
            {
                return _useMultithreading;
            }
            private set
            {
                _useMultithreading = value;
            }
        }
        public string SearchLevel
        {
            get
            {
                return _searchLevel;
            }
            private set
            {
                _searchLevel = value;
            }
        }
        public bool UseProfiles
        {
            get
            {
                return _useProfiles;
            }
            private set
            {
                _useProfiles = value;
            }
        }
        public string ProfileSelected
        {
            get 
            {
                return _profileSelected;
            }
            private set
            {
                _profileSelected = value;
            }
        }
        public string DefaultPath
        {
            get
            {
                return _defaultPath;
            }
            set
            {
                _defaultPath = value;
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public static GlobalSettings Load(string path = null)
        {
            var settings = new GlobalSettings();

            try
            {
                if (!File.Exists("config.xml"))
                {
                    var xmlConfig = new XDocument(
                        new XElement("Settings",
                            new XElement("Multithreading", "false"),
                            new XElement("Searchlevel", "medium"),
                            new XElement("UseProfiles", "true"),
                            new XElement("CurrentProfile", "Defaut"),
                            new XElement("BotPath", ""),
                            new XElement("Username", "Unknown")
                            )
                    );

                    xmlConfig.Save("config.xml");
                }

                XElement root = XElement.Load("config.xml");

                settings.UseMultithreading = Convert.ToBoolean(root.Element("Multithreading").Value);
                settings.SearchLevel = root.Element("Searchlevel").Value;
                settings.UseProfiles = Convert.ToBoolean(root.Element("UseProfiles").Value);
                settings.ProfileSelected = root.Element("CurrentProfile").Value;
                settings.DefaultPath = root.Element("BotPath").Value;
                settings.Username = root.Element("Username").Value;
            }
            catch (Exception ex)
            {
                //Show error maybe
                throw ex;
            }

            return settings;
        }

        public GlobalSettings()
        {

        }

        public void Save()
        {
            try
            {
                var root = new XElement("Settings");
                root.Add(new XElement("Multithreading", UseMultithreading));
                root.Add(new XElement("Searchlevel", SearchLevel));
                root.Add(new XElement("UseProfiles", UseProfiles));
                root.Add(new XElement("CurrentProfile", ProfileSelected));
                root.Add(new XElement("BotPath", DefaultPath));
                root.Add(new XElement("Username", Username));

                var xmlSettings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };

                using (XmlWriter xmlOutFile = XmlWriter.Create("config.xml", xmlSettings))
                {
                    root.Save(xmlOutFile);
                }
            }
            catch (Exception ex)
            {
                //Show error maybe
                throw ex;
            }
        }

    }
}

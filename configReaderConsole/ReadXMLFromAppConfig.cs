using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Net;

namespace configReaderConsole
{
    public class IpAddresses
    {
        private string _IpAddress1;
        private string _IpAddress2;
        private string _IpAddress3;
        private string _IpAddress4;

        public string IpAddress1
        {
            get { return _IpAddress1; }
            set { _IpAddress1 = value; }
        }

        public string IpAddress2
        {
            get { return _IpAddress2; }
            set { _IpAddress2 = value; }
        }

        public string IpAddress3
        {
            get { return _IpAddress3; }
            set { _IpAddress3 = value; }
        }

        public string IpAddress4
        {
            get { return _IpAddress4; }
            set { _IpAddress4 = value; }
        }
    }

    public class GGCSettings
    {
        private string _userId;
        private IpAddresses _IpAddresses;       
        private string _consumerId;
        private string _agencyCode;
        private string _applicatonCode;
        private string _region;
        private string _domain;

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public IpAddresses IpAddresses
        {
            get { return _IpAddresses; }
            set { _IpAddresses = value; }
        }

        public string ConsumerId
        {
            get { return _consumerId; }
            set { _consumerId = value; }
        }

        public string AgencyCode
        {
            get { return _agencyCode; }
            set { _agencyCode = value; }
        }

        public string ApplicatonCode
        {
            get { return _applicatonCode; }
            set { _applicatonCode = value; }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        
    }


    public class GGCSettingsSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            XPathNavigator nav = section.CreateNavigator();
            XmlSerializer ser = new XmlSerializer(typeof(GGCSettings));
            return ser.Deserialize(new XmlNodeReader(section));
        }
    }
    
    class ReadXMLFromAppConfig
    {
        static void Main(string[] args)
        {
            GGCSettings ggc = (GGCSettings)System.Configuration.ConfigurationManager.GetSection("GGCSettings"); 
        }
    }
}

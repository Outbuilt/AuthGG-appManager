using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authGG_Manager
{
    #region jsonAttributes
    public class informationUser
    {
        public string status { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string rank { get; set; }
        public string hwid { get; set; }
        public string variable { get; set; }
        public string lastlogin { get; set; }
        public string lastip { get; set; }
        public string expiry { get; set; }
    }

    public class userDelete
    {
        public string status { get; set; }
        public string info { get; set; }
    }

    public class editVariable
    {
        public string status { get; set; }
        public string info { get; set; }
    }

    public class userCount
    {
        public string status { get; set; }
        public string value { get; set; }
    }

    public class unuseLicense
    {
        public string status { get; set; }
        public string info { get; set; }
    }

    public class useLicense
    {
        public string status { get; set; }
        public string info { get; set; }
    }

    public class deleteLicense
    {
        public string status { get; set; }
        public string info { get; set; }
    }

    public class informationLicense
    {
        public string status { get; set; }
        public string license { get; set; }
        public string rank { get; set; }
        public string used { get; set; }
        public string used_by { get; set; }
        public string created { get; set; }
    }

    public class licensesCount
    {
        public string status { get; set; }
        public string value { get; set; }
    }

    public class HWIDInformation
    {
        public string status { get; set; }
        public string value { get; set; }
    }
    #endregion
}

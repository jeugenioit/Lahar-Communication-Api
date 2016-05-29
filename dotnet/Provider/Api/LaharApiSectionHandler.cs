using System;
using System.Configuration;


namespace JE.Common.Provider.Api
{
    /// <summary>
    /// [Provider] Class section Lahar Api handler
    /// </summary>
    public class LaharApiSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("token", IsKey = true, IsRequired = true)]
        public string Token
        {
            get
            {
                return (String)this["token"];
            }
            set
            {
                this["token"] = value;
            }
        }

        [ConfigurationProperty("request-protocol", IsRequired = true)]
        public string Protocol
        {
            get
            {
                return (String)this["request-protocol"];
            }
            set
            {
                this["request-protocol"] = value;
            }
        }

        [ConfigurationProperty("request-url", IsRequired = true)]
        public string RequestUrl
        {
            get
            {
                return (String)this["request-url"];
            }
            set
            {
                this["request-url"] = value;
            }
        }



    }
}

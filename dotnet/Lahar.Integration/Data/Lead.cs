using System;
using Lahar.Api.Integration.Helpers;

namespace Lahar.Api.Integration.Data
{
    /// <summary>
    /// Class Lead - Information about contact
    /// </summary>
    public class Lead
    {
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string State { get; set; }
        public virtual string City { get; set; }
        public virtual string CEP { get; set; }
        public virtual string Website { get; set; }
        public virtual string Twitter { get; set; }
        public virtual string Facebook { get; set; }
        public virtual string Linkedin { get; set; }      
        public virtual string Position { get; set; }
        public virtual string Sector { get; set; }
        
        public virtual string CompanyName { get; set; }
        public virtual string CompanyEmail { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual string CompanyWebsite { get; set; }
        public virtual string CompanyPhone { get; set; }
        public virtual string CompanyTwitter { get; set; }
        public virtual string CompanyFacebook { get; set; }
        public virtual string CompanyLinkedin { get; set; }

        public virtual string Note { get; set; }
        public virtual string[] Tags { get; set; }
        public virtual eStageLead Stage { get; set; }

        public virtual string FormNameOrigin { get; set; }
        public virtual string UrlOrigin { get; set; }
    }
}

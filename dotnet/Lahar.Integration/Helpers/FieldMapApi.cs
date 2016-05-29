using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahar.Api.Integration.Helpers
{
    /// <summary>
    /// Map fields to send the api
    /// </summary>
    public class FieldMapApi
    {
        //--> COMMON
        public const string TOKEN = "token_api_lahar";
        public const string FORMNAME = "nome_formulario";
        public const string POSTEDURL = "url_origem";
        public const string TAGS = "tags";
        public const string STAGELEAD = "estagio_lead";
        public const string REQUESTTYPEAPI = "tipo_integracao";

        //--> CONTACT
        public const string CONTACT_EMAIL = "email_contato";
        public const string CONTACT_NAME = "nome_contato";
        public const string CONTACT_PHONE = "tel_fixo";
        public const string CONTACT_CELLPHONE = "tel_celular";
        public const string CONTACT_STATE = "estado";
        public const string CONTACT_CITY = "cidade";
        public const string CONTACT_ZIPCODE = "cep";
        public const string CONTACT_POSITION = "cargo";
        public const string CONTACT_SECTOR = "setor";
        public const string CONTACT_WEBSITE = "site_contato";
        public const string CONTACT_TWITTER = "twitter";
        public const string CONTACT_FACEBOOK = "facebook";
        public const string CONTACT_LINKEDIN = "linkedin";
        public const string CONTACT_OBSERVATION = "anotacoes";
        //--> COMPANY
        public const string COMPANY_EMAIL = "email_empresa";
        public const string COMPANY_NAME = "name_empresa";
        public const string COMPANY_ADDRESS = "endereco_empresa";
        public const string COMPANY_PHONE = "tel_empresa";
        public const string COMPANY_WEBSITE = "site_empresa";
        public const string COMPANY_TWITTER = "twitter_empresa";
        public const string COMPANY_FACEBOOK = "facebook_empresa";

    }
}

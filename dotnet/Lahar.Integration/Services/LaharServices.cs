using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

using JE.Common.LogService.Services.Interfaces;
using JE.Common.LogService.Services;
using JE.Common.Provider.Api;

using Lahar.Api.Integration.Services.Interfaces;
using Lahar.Api.Integration.Data;
using Lahar.Api.Integration.Helpers;


namespace Lahar.Api.Integration.Services
{
    public class LaharServices : ILaharServices
    {
        #region Atributes
        private readonly ILogServices logServices = new LogServices();
        private readonly LaharApiSectionHandler laharApi = (LaharApiSectionHandler)ConfigurationManager.GetSection("apiprovider/lahar");
        #endregion

        #region Public Methods

        public bool SaveLead(Lead obj)
        {
            bool result = false;            

            if (obj == null)
            {
                throw new Exception("Object Lead can not be null");
            }
            else if (string.IsNullOrEmpty(obj.Email))
            {
                throw new Exception("Property E-mail can not be null or empty");
            }
            else
            {
                logServices.LogTrace("===================================================");
                logServices.LogTrace("START METHOD SAVELEAD");
                logServices.LogTrace("===================================================");
                try
                {
                    string response = ComunicationWihApi(RequestMethodType.POST, RequestSignature.CONVERSIONS, ConvertDataToPost(obj));

                    if (!string.IsNullOrEmpty(response))
                    {
                        logServices.LogTrace("DESERIALIZE RETURN TO CHECK");
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        dynamic json = serializer.Deserialize(response, typeof(object));
                        var status = (string) json["status"];

                        if (status.Equals("sucesso"))
                        {
                            logServices.LogTrace("SUCCESS");
                            result = true;
                        }
                        else
                        {
                            logServices.LogTrace("OPS! CHECK RESPONSE");
                            logServices.LogTrace(response);
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    logServices.LogError(ex, "Error call Lahar API");
                    throw new Exception("Error call ComunicationWihApi", ex);
                }
            }

            logServices.LogTrace("END METHOD SAVELEAD");
            return result;
        }

        public bool UpdateStageLead(Lead obj)
        {
            bool result = false;
            

            if (obj == null)
            {
                throw new Exception("Object Lead can not be null");
            }
            else if (string.IsNullOrEmpty(obj.Email))
            {
                throw new Exception("Property E-mail can not be null or empty");
            }
            else
            {
                logServices.LogTrace("===================================================");
                logServices.LogTrace("START METHOD UPDATESTAGELEAD");
                logServices.LogTrace("===================================================");
                try
                {
                    string response = ComunicationWihApi(RequestMethodType.PUT, RequestSignature.LEADS, ConvertDataToJSON(obj));

                    if (!string.IsNullOrEmpty(response))
                    {
                        logServices.LogTrace("DESERIALIZE RETURN TO CHECK");
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        dynamic json = serializer.Deserialize(response, typeof(object));
                        var status = (string)json["status"];

                        if (status.Equals("sucesso"))
                        {
                            logServices.LogTrace("SUCCESS");
                            result = true;
                        }
                        else
                        {
                            logServices.LogTrace("OPS! CHECK RESPONSE");
                            logServices.LogTrace(response);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logServices.LogError(ex, "Error call Lahar API");
                    throw new Exception("Error call ComunicationWihApi", ex);
                }
            }

            logServices.LogTrace("END METHOD UPDATESTAGELEAD");
            return result;
        }

        #endregion

        #region Private Method

        private string ConvertDataToPost(Lead obj)
        {
            logServices.LogTrace("START CONVERT DATA TO POST");
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string,string>(FieldMapApi.TOKEN, laharApi.Token));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.FORMNAME, (string.IsNullOrEmpty(obj.FormNameOrigin) ? "MySite Register" : obj.FormNameOrigin)));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.POSTEDURL, (string.IsNullOrEmpty(obj.UrlOrigin) ? "www.mysite.com" : obj.UrlOrigin)));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.TAGS, (obj.Tags != null && obj.Tags.Length > 0) ? string.Join(",", obj.Tags) : string.Empty));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.STAGELEAD, Convert.ToInt32(obj.Stage).ToString()));            
            data.Add(new KeyValuePair<string,string>(FieldMapApi.REQUESTTYPEAPI, RequestSignature.CONVERSIONS)); //-->The api does not support update contact so it is always necessary to perform a new conversion to update contact
            //--> Contact
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_EMAIL, obj.Email));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_NAME, obj.Name));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_PHONE, obj.Phone));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_CELLPHONE, obj.CellPhone));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_STATE, obj.State));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_CITY, obj.City));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_ZIPCODE, obj.CEP));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_POSITION, obj.Position));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_SECTOR, obj.Sector));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_WEBSITE, obj.Website));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_TWITTER, obj.Twitter));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_FACEBOOK, obj.Facebook));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_LINKEDIN, obj.Linkedin));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.CONTACT_OBSERVATION, obj.Note));
            //-- Company          
            data.Add(new KeyValuePair<string,string>(FieldMapApi.COMPANY_EMAIL, obj.CompanyEmail));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.COMPANY_NAME, obj.CompanyName));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.COMPANY_ADDRESS, obj.CompanyAddress));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.COMPANY_PHONE, obj.CompanyPhone));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.COMPANY_WEBSITE, obj.CompanyWebsite));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.COMPANY_TWITTER, obj.CompanyTwitter));
            data.Add(new KeyValuePair<string,string>(FieldMapApi.COMPANY_FACEBOOK, obj.CompanyFacebook));

            FormUrlEncodedContent content = new FormUrlEncodedContent(data.ToArray());
            logServices.LogTrace("END CONVERT DATA TO POST");
            return content.ReadAsStringAsync().Result;
        }

        private string ConvertDataToJSON(Lead obj)
        {
            logServices.LogTrace("START CONVERT DATA TO JSON");
            StringBuilder data = new StringBuilder();
            data.Append("{");
            data.Append(string.Format("\"{0}\":\"{1}\"", FieldMapApi.TOKEN, laharApi.Token));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.FORMNAME, (string.IsNullOrEmpty(obj.FormNameOrigin) ? "MySite Register" : obj.FormNameOrigin)));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.POSTEDURL, (string.IsNullOrEmpty(obj.UrlOrigin) ? "www.mysite.com" : obj.UrlOrigin)));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.TAGS, (obj.Tags != null && obj.Tags.Length > 0) ? string.Join(",", obj.Tags) : string.Empty));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.STAGELEAD, Convert.ToInt32(obj.Stage).ToString()));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.REQUESTTYPEAPI, RequestSignature.LEADS));
            //--> Contact
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_EMAIL, obj.Email));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_NAME, obj.Name));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_PHONE, obj.Phone));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_CELLPHONE, obj.CellPhone));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_STATE, obj.State));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_CITY, obj.City));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_ZIPCODE, obj.CEP));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_POSITION, obj.Position));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_SECTOR, obj.Sector));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_WEBSITE, obj.Website));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_TWITTER, obj.Twitter));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_FACEBOOK, obj.Facebook));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_LINKEDIN, obj.Linkedin));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.CONTACT_OBSERVATION, obj.Note));
            //-- Company          
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.COMPANY_EMAIL, obj.CompanyEmail));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.COMPANY_NAME, obj.CompanyName));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.COMPANY_ADDRESS, obj.CompanyAddress));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.COMPANY_PHONE, obj.CompanyPhone));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.COMPANY_WEBSITE, obj.CompanyWebsite));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.COMPANY_TWITTER, obj.CompanyTwitter));
            data.Append(string.Format(",\"{0}\":\"{1}\"", FieldMapApi.COMPANY_FACEBOOK, obj.CompanyFacebook));
            data.Append("}");
            logServices.LogTrace("END CONVERT DATA TO JSON");
            return data.ToString();
        }

        private string ComunicationWihApi(string requestMethod, string requestSignature, string dataOfSend)
        {
            string status = string.Empty;
            logServices.LogTrace("START COMMUNICATION TO API");
            WebRequest request = WebRequest.Create(string.Format("{0}://{1}/{2}", laharApi.Protocol, laharApi.RequestUrl, requestSignature));

            logServices.LogTrace(string.Format("REQUEST METHOD: {0}", requestMethod));
            request.Method = requestMethod;

            logServices.LogTrace(string.Format("DATA SEND: \n{0}", dataOfSend));
            string postData = dataOfSend;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            switch (requestMethod)
            {
                case RequestMethodType.PUT:
                    request.ContentType = "application/json";
                    break;
                case RequestMethodType.POST:
                    request.ContentType = "application/x-www-form-urlencoded";
                    break;
                case RequestMethodType.GET:
                    request.ContentType = "application/x-www-form-urlencoded";
                    break;
                default:
                    request.ContentType = "application/x-www-form-urlencoded";
                    break;
            }
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            //-->
            WebResponse response = request.GetResponse();
            status = ((HttpWebResponse)response).StatusDescription;
            logServices.LogTrace(string.Format("STATUS RESPONSE: {0}", status));

            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            logServices.LogTrace(string.Format("RESPONSE API: {0}", responseFromServer));

            reader.Close();
            dataStream.Close();
            response.Close();
            logServices.LogTrace("END COMMUNICATION TO API");

            return responseFromServer;
        }

        #endregion
    }
}

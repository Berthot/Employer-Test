using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Employer.CLI.DTO;
using Newtonsoft.Json;

namespace Employer.CLI.Controller
{
    public class SubjectController
    {

        public object CreateNewSubject(SubjectDto subjectDto)
        {
            
            const string url = "http://localhost:5000/Subject";
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(subjectDto));
            var requestWeb = WebRequest.CreateHttp(url);
            // 'desabilitar' ssl
            requestWeb.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            requestWeb.Method = "POST";
            requestWeb.ContentType = "application/json";
            requestWeb.ContentLength = data.Length;
            requestWeb.UserAgent = "RequisicaoWebDemo";
            using (var stream = requestWeb.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            
            try
            {
                using var resposta = requestWeb.GetResponse();
                using var streamOne = resposta.GetResponseStream();
                using var reader = new StreamReader(streamOne);
                object objResponse = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<SubjectDto>(objResponse.ToString());

            }
            catch (WebException ex)
            {
                using var stream = ex.Response.GetResponseStream();
                using var reader = new StreamReader(stream);
                return JsonConvert.DeserializeObject<List<string>>(reader.ReadToEnd());
            }
 
        }

        public object DeleteSubject(SubjectDto subjectDto)
        {
            const string url = "http://localhost:5000/Subject";
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(subjectDto));
            var requestWeb = WebRequest.CreateHttp(url);
            // 'desabilitar' ssl
            requestWeb.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            requestWeb.Method = "DELETE";
            requestWeb.ContentType = "application/json";
            requestWeb.ContentLength = data.Length;
            requestWeb.UserAgent = "RequisicaoWebDemo";
            using (var stream = requestWeb.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            
            try
            {
                using var resposta = requestWeb.GetResponse();
                using var streamOne = resposta.GetResponseStream();
                using var reader = new StreamReader(streamOne);
                return JsonConvert.DeserializeObject<List<string>>(reader.ReadToEnd());

            }
            catch (WebException ex)
            {
                using var stream = ex.Response.GetResponseStream();
                using var reader = new StreamReader(stream);
                return JsonConvert.DeserializeObject<List<string>>(reader.ReadToEnd());
            }
        }
    }
}
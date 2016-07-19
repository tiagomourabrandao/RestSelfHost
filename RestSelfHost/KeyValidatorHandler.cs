using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RestSelfHost
{
    public class KeyValidatorHandler : DelegatingHandler
    {
        private string _applicationToken = ConfigurationManager.AppSettings["token"];
        protected async override Task<HttpResponseMessage>
           SendAsync(HttpRequestMessage request,
           CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;

            if (request.Headers.Authorization != null && request.Headers.Authorization.Scheme == _applicationToken)
                response = await base.SendAsync(request, cancellationToken);
            else
                response = request.CreateResponse(HttpStatusCode.Unauthorized, "You are not authorized to use that API!");
            return response;
        }
    }
}

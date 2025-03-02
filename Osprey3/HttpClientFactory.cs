using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public static class HttpClientFactory
{
    public static HttpMessageHandler CreateHandler()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        return handler;
    }
}
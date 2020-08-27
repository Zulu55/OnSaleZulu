using OnSalePrep.Common.Request;
using OnSalePrep.Common.Responses;
using System.Threading.Tasks;

namespace OnSalePrep.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);

        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request);

        Task<Response> PostQualificationAsync(string urlBase, string servicePrefix, string controller, QualificationRequest qualificationRequest, string token);
    }
}

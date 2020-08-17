using OnSalePrep.Common.Responses;
using System.Threading.Tasks;

namespace OnSalePrep.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}

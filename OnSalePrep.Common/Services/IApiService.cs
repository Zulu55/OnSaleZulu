using OnSalePrep.Common.Request;
using OnSalePrep.Common.Responses;
using System.Threading.Tasks;

namespace OnSalePrep.Common.Services
{
    public interface IApiService
    {
        /// <summary>
        /// Get a generic list 
        /// </summary>
        /// <typeparam name="T">Is the class</typeparam>
        /// <param name="urlBase">The user base</param>
        /// <param name="servicePrefix">The service prefix</param>
        /// <param name="controller">The controller name</param>
        /// <returns></returns>
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);

        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request);

        Task<Response> PostQualificationAsync(string urlBase, string servicePrefix, string controller, QualificationRequest qualificationRequest, string token);

        Task<Response> RegisterUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest);

        Task<Response> RecoverPasswordAsync(string urlBase, string servicePrefix, string controller, EmailRequest emailRequest);

        Task<Response> ModifyUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest, string token);
    }
}

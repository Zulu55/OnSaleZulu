using OnSalePrep.Common.Responses;

namespace OnSalePrep.Web.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body);
    }
}

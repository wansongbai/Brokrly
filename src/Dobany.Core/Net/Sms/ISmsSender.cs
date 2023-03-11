using System.Threading.Tasks;

namespace Dobany.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}
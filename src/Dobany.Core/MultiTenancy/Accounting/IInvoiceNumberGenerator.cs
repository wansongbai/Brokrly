using System.Threading.Tasks;
using Abp.Dependency;

namespace Dobany.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}
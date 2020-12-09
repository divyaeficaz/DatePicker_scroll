using System.IO;
using System.Threading.Tasks;

namespace Yondr_Finance.Interfaces
{
    public interface ILocalFileProvider
    {
        Task<string> SaveFileToDisk(Stream stream, string fileName);
    }
}
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IFileUploaderService
    {
        Task<string> Upload(MemoryStream file, string fileName);
    }
}
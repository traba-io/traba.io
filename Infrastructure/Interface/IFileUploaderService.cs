using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IFileUploaderService
    {
        Task Upload(MemoryStream file, string fileName);
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SuperShop.Helpers
{
    public interface IBlobHelper
    {
        Task<Guid> UploadBlobAsync(IFormFile file, string containerName);

        Task<Guid> UploadBlobAsync(byte[] file, string containerName); //A utilizar no mobile!

        Task<Guid> UploadBlobAsync(string image, string containerName); //Endereço de uma imagem
    }
}

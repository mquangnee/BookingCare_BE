using BookingCare.Application.Services;
using BookingCare.Shared.Setting;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace BookingCare.Infrastructure.Services
{
    public class CloudStorageService : ICloudStorageService
    {
        private readonly StorageClient _storageClient;
        private readonly string _bucketName;

        public CloudStorageService(IOptions<CloudStorageSetting> cloudStorageSetting)
        {
            var settings = cloudStorageSetting.Value;
            _bucketName = settings.BucketName!;
            GoogleCredential credential = GoogleCredential.FromFile(settings.CredentialPath);
            _storageClient = StorageClient.Create(credential);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderPath)
        {
            string fileName = $"{Guid.NewGuid()}_{file.FileName}";
            string objectName = $"{folderPath.TrimEnd('/')}/{fileName}";

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            await _storageClient.UploadObjectAsync(_bucketName, objectName, file.ContentType, memoryStream);
            return $"https://storage.googleapis.com/{_bucketName}/{objectName}";
        }
    }
}

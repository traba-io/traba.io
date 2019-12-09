using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Domain.Util;
using Infrastructure.Interface;
using TinyPng;


namespace Infrastructure.Service
{
    public class S3FileUploaderService : IFileUploaderService
    {
        public async Task<string> Upload(MemoryStream file, string fileName)
        {
            using var client = new AmazonS3Client(EnvironmentVariables.AwsAccessKeyId,
                EnvironmentVariables.AwsSecretAccessKey, RegionEndpoint.SAEast1);
            using var tinyClient = new TinyPngClient(EnvironmentVariables.TinyPngApiKey);
            
            var response = await tinyClient.Compress(file.ToArray()).Download().GetImageStreamData();

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = response,
                Key = fileName,
                BucketName = EnvironmentVariables.AwsBucketName,
                CannedACL = S3CannedACL.PublicRead
            };

            var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(uploadRequest);

            return "https://s3-sa-east-1.amazonaws.com/traba.io/" + fileName;
        }
    }
}
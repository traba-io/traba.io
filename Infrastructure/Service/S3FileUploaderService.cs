using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Domain.Util;
using Infrastructure.Interface;


namespace Infrastructure.Service
{
    public class S3FileUploaderService : IFileUploaderService
    {
        public async Task Upload(MemoryStream file, string fileName)
        {
            using var client =
                new AmazonS3Client(EnvironmentVariables.AwsAccessKeyId, EnvironmentVariables.AwsSecretAccessKey, RegionEndpoint.USEast1);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = file,
                Key = fileName,
                BucketName = EnvironmentVariables.AwsBucketName,
                CannedACL = S3CannedACL.PublicRead
            };

            var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(uploadRequest);
        }
    }
}
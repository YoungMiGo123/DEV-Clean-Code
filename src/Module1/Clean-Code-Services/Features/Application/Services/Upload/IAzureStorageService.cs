using Azure.Storage.Blobs;

namespace Clean_Code_Services.Features.Application.Services.Upload
{
    public record DownloadStreamRequest(string FileName);
    public record UploadStreamRequest(string FileName, Stream Content);
    public record UploadFileRequest(string FileName, string Extension, string Content);
    public record UploadFormFileRequest(string FileName, string Extension, IFormFile Content);
    public class SongInfo
    {
        public string Name { get;  set; }
        public string Url { get;  set; }
    }
    public interface IAzureStorageService
    {
        Task<Stream> DownloadSongAsync(DownloadStreamRequest request);
        Task<IEnumerable<SongInfo>> GetSongs();
        Task UploadSongAsync(UploadStreamRequest request);
        Task<string> UploadAsync(UploadFileRequest request);
        Task<string> UploadFormFileAsync(UploadFormFileRequest request);
    }

    public class AzureStorageService(IConfiguration configuration) : IAzureStorageService
    {
        private readonly BlobServiceClient _blobServiceClient = new(configuration["Azure:StorageConnectionString"]);
        private string _containerName => configuration["Azure:ContainerName"];
        public async Task UploadSongAsync(UploadStreamRequest request)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(request.FileName);
            var response = await blobClient.UploadAsync(request.Content, true);
        }

        public async Task<Stream> DownloadSongAsync(DownloadStreamRequest request)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(request.FileName);
            var response = await blobClient.DownloadAsync();
            return response.Value.Content;
        }

        public async Task<IEnumerable<SongInfo>> GetSongs()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var songs = new List<SongInfo>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                var blobClient = containerClient.GetBlobClient(blobItem.Name);
                var songInfo = new SongInfo
                {
                    Name = blobItem.Name,
                    Url = blobClient.Uri.ToString()
                };
                songs.Add(songInfo);
            }

            return songs;
        }

        public async Task<string> UploadAsync(UploadFileRequest request)
        {
            byte[] fileBytes = Convert.FromBase64String(request.Content);

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

            var fileName = $"{request.FileName}|{Guid.NewGuid()}{request.Extension}";

            var blobClient = blobContainerClient.GetBlobClient(fileName);

            using (MemoryStream stream = new MemoryStream(fileBytes))
            {
                await blobClient.UploadAsync(stream, true);
            }

            return blobClient.Uri.ToString();
        }

        public async Task<string> UploadFormFileAsync(UploadFormFileRequest request)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

            var fileName = $"{request.FileName}|{Guid.NewGuid()}{request.Extension}";

            var blobClient = blobContainerClient.GetBlobClient(fileName);

            using (var stream = request.Content.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }

            return blobClient.Uri.ToString();
        }
    }
}

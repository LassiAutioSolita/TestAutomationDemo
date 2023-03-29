using System.Net.Http.Json;

namespace TestAutomationDropboxApp;

public interface IDropBoxApiClient
{
    List<DropboxFile> GetAllFiles();
}

public class DropBoxApiClient : IDropBoxApiClient
{
    public List<DropboxFile> GetAllFiles()
    {
        var httpClient = new HttpClient();
        var files = httpClient.GetFromJsonAsync<List<DropboxFile>>("https://api.dropbox.com").Result;
        return files;
    }
}

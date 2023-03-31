using System.Net.Http.Json;

namespace DemoApp;

public interface IDropboxClient
{
    Task<List<DropboxFile>> GetAllFiles();
    Task<List<DropboxFile>> GetAllFiles(string name);
}

public class DropboxClient : IDropboxClient
{
    public async Task<List<DropboxFile>> GetAllFiles()
    {
        var httpClient = new HttpClient();
        return await httpClient.GetFromJsonAsync<List<DropboxFile>>("https://api.dropbox.com");
    }

    public Task<List<DropboxFile>> GetAllFiles(string name)
    {
        throw new NotImplementedException();
    }
}

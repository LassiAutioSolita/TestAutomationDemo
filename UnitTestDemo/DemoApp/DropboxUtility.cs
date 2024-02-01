namespace DemoApp;

public class DropboxUtility
{
    private readonly IDropboxClient _client;

    public DropboxUtility(IDropboxClient client)
    {
        _client = client;
    }

    public async Task<List<DropboxFile>> GetAllFilesOfType(string type)
    {
        var files = await _client.GetAllFiles();
        return files.FindAll(file => file.GetFileType() == type);
    }
}

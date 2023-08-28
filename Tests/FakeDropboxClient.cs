using DemoApp;

namespace Tests;

public class FakeDropboxClient : IDropboxClient
{
    private static readonly List<DropboxFile> _files = new List<DropboxFile>
        {
            new DropboxFile("readme.txt"),
            new DropboxFile("demoapp.exe")
        };

    public void AddFile(string file)
    {

    }

    public async Task<List<DropboxFile>> GetAllFiles()
    {
        return await Task.FromResult(_files);
    }

    public async Task<List<DropboxFile>> GetAllFiles(string name)
    {
        var files = _files.FindAll(file => file.GetName() == name);
        return await Task.FromResult(files);
    }
}

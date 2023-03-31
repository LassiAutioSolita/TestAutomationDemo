using DemoApp;

namespace Tests;

public class FakeDropboxClient : IDropboxClient
{
    public void AddFile(string file)
    {

    }

    public async Task<List<DropboxFile>> GetAllFiles()
    {
        var list = new List<DropboxFile>
        {
            new DropboxFile("readme.txt"),
            new DropboxFile("demoapp.exe")
        };

        return list;
    }

    public Task<List<DropboxFile>> GetAllFiles(string name)
    {
        throw new NotImplementedException();
    }
}

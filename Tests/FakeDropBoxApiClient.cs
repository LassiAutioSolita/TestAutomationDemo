using TestAutomationDropboxApp;

namespace Tests;

internal class FakeDropBoxApiClient : IDropBoxApiClient
{
    public List<DropboxFile> GetAllFiles()
    {
        return new List<DropboxFile>
        {
            new DropboxFile("readme.txt"),
            new DropboxFile("picture.jpg")
        };
    }
}

namespace TestAutomationDropboxApp;

public class DropboxUtility
{
    private readonly IDropBoxApiClient _dropBoxApiClient;

    public DropboxUtility(IDropBoxApiClient dropBoxApiClient)
    {
        _dropBoxApiClient = dropBoxApiClient;
    }

    public List<DropboxFile> GetAllFiles()
    {
        return _dropBoxApiClient.GetAllFiles();
    }

    public List<DropboxFile> GetAllFiles(string fileType)
    {
        var files = GetAllFiles();
        return files.FindAll(file => file.GetFileType() == fileType);
    }
}

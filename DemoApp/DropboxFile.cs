namespace DemoApp;

public class DropboxFile
{
    private readonly string _name;

    public DropboxFile(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetFileType()
    {
        return _name.Split(".")[1];
    }
}

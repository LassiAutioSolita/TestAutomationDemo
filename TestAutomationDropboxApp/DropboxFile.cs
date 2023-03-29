namespace TestAutomationDropboxApp;

public class DropboxFile
{
    private readonly string _name;

    public DropboxFile(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("name");
        }
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetFileType()
    {
        return _name.Split('.')[1];
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (GetType() != obj.GetType()) return false;

        var compare = obj as DropboxFile;
        return compare.GetName() == GetName();
    }

    public override string ToString()
    {
        return GetName();
    }
}

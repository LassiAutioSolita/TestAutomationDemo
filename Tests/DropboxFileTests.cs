using DemoApp;

namespace Tests;

[TestClass]
public class DropboxFileTests
{
    [TestMethod]
    public void Create_dropbox_file_object()
    {
        _ = new DropboxFile("temp.txt");
    }

    [TestMethod]
    public void File_has_a_name()
    {
        var dropboxFile = new DropboxFile("readme.txt");
        Assert.AreEqual("readme.txt", dropboxFile.GetName());
    }

    [TestMethod]
    public void File_has_some_other_name()
    {
        var dropboxFile = new DropboxFile("picture.jpg");
        Assert.AreEqual("picture.jpg", dropboxFile.GetName());
    }

    [TestMethod]
    public void File_has_a_type()
    {
        var dropboxFile = new DropboxFile("picture.jpg");
        Assert.AreEqual("jpg", dropboxFile.GetFileType());
    }

    [TestMethod]
    public void File_has_another_type()
    {
        var dropboxFile = new DropboxFile("picture.tiff");
        Assert.AreEqual("tiff", dropboxFile.GetFileType());
    }

    [DataTestMethod]
    [DataRow("picture.jpg", "jpg")]
    [DataRow("picture.tiff", "tiff")]
    [DataRow("readme.txt", "txt")]
    public void ParameterizedTest(string fileName, string expected)
    {
        var dropboxFile = new DropboxFile(fileName);
        Assert.AreEqual(expected, dropboxFile.GetFileType());
    }
}

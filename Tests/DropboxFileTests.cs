using TestAutomationDropboxApp;

namespace Tests;

[TestClass]
public class DropboxFileTests
{
    [TestMethod]
    public void File_has_a_name()
    {
        var sut = new DropboxFile("picture.jpg");
        Assert.AreEqual("picture.jpg", sut.GetName());
    }

    [TestMethod]
    public void Text_file_is_detected()
    {
        var sut = new DropboxFile("readme.txt");
        Assert.AreEqual("txt", sut.GetFileType());
    }

    [TestMethod]
    public void Jpg_file_is_detected()
    {
        var sut = new DropboxFile("picture.jpg");
        Assert.AreEqual("jpg", sut.GetFileType());
    }

    [TestMethod]
    public void Throws_exception_if_name_is_missing()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new DropboxFile(""));
    }
}

using DemoApp;
using Moq;

namespace Tests;

[TestClass]
public class DropboxUtilityTests
{
    [TestMethod]
    public async Task GetAllFilesOfType_demo_with_fake()
    {
        var fakeClient = new FakeDropboxClient();
        var dropboxUtility = new DropboxUtility(fakeClient);
        var files = await dropboxUtility.GetAllFilesOfType("txt");

        Assert.AreEqual(1, files.Count);
        Assert.AreEqual("readme.txt", files[0].GetName());
    }

    [TestMethod]
    public async Task GetAllFilesOfType_demo_with_mock()
    {
        var mock = new Mock<IDropboxClient>();

        var list = new List<DropboxFile>
        {
            new DropboxFile("readme.txt"),
            new DropboxFile("demoapp.exe")
        };
        mock.Setup(client => client.GetAllFiles()).Returns(Task.FromResult(list));

        var dropboxUtility = new DropboxUtility(mock.Object);
        var files = await dropboxUtility.GetAllFilesOfType("txt");

        // Assert that mock.GetAllFiles() was called one time.
        //mock.Verify(client => client.GetAllFiles(), Times.Once);
        mock.Verify(client => client.GetAllFiles("txt"), Times.Once);
    }
}

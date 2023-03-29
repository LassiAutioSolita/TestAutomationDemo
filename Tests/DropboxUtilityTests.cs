using FluentAssertions;
using Moq;
using TestAutomationDropboxApp;

namespace Tests;

[TestClass]
public class DropboxUtilityTests
{
    [TestMethod]
    public void Returns_jpg_files_correctly()
    {
        var expected = new List<DropboxFile> { new DropboxFile("picture.jpg") };
        var sut = new DropboxUtility(new FakeDropBoxApiClient());

        var actual = sut.GetAllFiles("jpg");

        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void Mocking_example()
    {
        var expected = new List<DropboxFile> { new DropboxFile("contract.docx") };
        var dropboxApiClientMock = new Mock<IDropBoxApiClient>();

        var returnedList = new List<DropboxFile> { new DropboxFile("contract.docx") };
        dropboxApiClientMock.Setup(api => api.GetAllFiles()).Returns(returnedList);

        var sut = new DropboxUtility(dropboxApiClientMock.Object);

        var actual = sut.GetAllFiles("docx");

        actual.Should().BeEquivalentTo(expected);
        dropboxApiClientMock.Verify(api => api.GetAllFiles(), Times.Once);
    }
}

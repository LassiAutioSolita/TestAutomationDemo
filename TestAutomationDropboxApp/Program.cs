// See https://aka.ms/new-console-template for more information
using TestAutomationDropboxApp;

Console.WriteLine("Hello, DevAcademy!");

var client = new DropBoxApiClient();
var utility = new DropboxUtility(client);

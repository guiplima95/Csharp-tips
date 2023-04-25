using AdvancedTips.Core;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

Console.WriteLine("1 - Serializer User to XML, saving file in c:\\temp\\advancedTips\\serializerXml");
Console.WriteLine("2 - Exit");

ConsoleKeyInfo UserInput = Console.ReadKey();
if (UserInput.KeyChar == '1')
{
    string filePath = @"c:\temp\advancedTips\serializerXml";
    SerializerToXml(filePath);
}
else
{
    Console.ReadLine();
}


static void SerializerToXml(string filePath)
{
    EnsureDirectoryExists(filePath);

    User user = new("Guilherme", "email@test.com", "111.111.111.11");

    XmlSerializer serializer = new(typeof(User));

    using StreamWriter stream = new(path: filePath);

    serializer.Serialize(stream, user);

    Console.WriteLine("...Serializing");
    Console.WriteLine("Congratulations! Xml was create successfully");
    Process.Start(new ProcessStartInfo("explorer.exe", filePath));
}

static void EnsureDirectoryExists(string filePath)
{
    FileInfo fi = new(filePath);
    if (fi.Directory is null || fi.DirectoryName is null)
    {
        return;
    }
    if (!fi.Directory.Exists)
    {
        Directory.CreateDirectory(fi.DirectoryName);
    }
}
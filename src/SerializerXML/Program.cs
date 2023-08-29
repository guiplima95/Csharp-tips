using SerializerXML;
using System.Diagnostics;
using System.Xml.Serialization;

string filePath = @"c:\temp\advancedTips\serializerXml";

SerializerToXml(filePath);


static void SerializerToXml(string filePath)
{
    // create directory
    EnsureDirectoryExists(filePath);

    Member member = new("Guilherme", "guilhermelucas.contato@gmail.com", 27, DateTime.UtcNow, true);

    XmlSerializer serializer = new(typeof(Member));

    Console.WriteLine("...Serializing");

    using StreamWriter stream = new(path: filePath);

    // serializer to xml
    serializer.Serialize(stream, member);

    Console.WriteLine("Congratulations! Xml was create successfully");

    // open the file
    Process.Start(new ProcessStartInfo("explorer.exe", filePath));
}

static void EnsureDirectoryExists(string filePath)
{
    FileInfo fi = new(filePath);
    if (fi.Directory is null || fi.DirectoryName is null)
    {
        return;
    }

    if (fi.Directory.Exists)
    {
        return;
    }

    Directory.CreateDirectory(fi.DirectoryName);
}
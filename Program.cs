
using XmlChecker.Parser;

class Program
{
    static readonly string[] testFiles =
    {
        "case1.xml",
        "case2.xml",
        "case3.xml",
        "case4.xml",
        "case5.xml",
    };

    public static void Main(string[] args)
    {
        foreach(var file in testFiles)
        {
            var path = $"./data/{file}";
            var isXml = XmlReader.DetermineXmlFromFile(path);

            var source = File.ReadAllText(path);

            var tokenzied = new XmlTokenizer(source);
            var tokens = tokenzied.Tokens;
        }
    }
}
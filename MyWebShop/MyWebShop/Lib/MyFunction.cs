namespace MyWebShop.Lib
{
    public class MyFunction
    {
        public static string StringConnection(string Path)
        {
            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), $"..\\..\\..\\{Path}");
            FileInfo fileInfo = new FileInfo(path);
            return $"Server = (localdb)\\mssqllocaldb;;AttachDbFilename={fileInfo.FullName};Integrated Security=True;  Trusted_Connection = True";
        }
    }
}

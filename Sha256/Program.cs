
using System.IO;
using System.Security.Cryptography;

namespace Sha256
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var s = Sha256(@"c:\windows\explorer.exe");
            Console.WriteLine(s);
            Console.ReadLine();
        }

        private static string Sha256(string filePath)
        {
            var start = DateTime.Now;
            var result = "";
            using (var sha256 = SHA256.Create())
            {
                using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
                {
                    var checksum = sha256.ComputeHash(stream);
                    result = BitConverter.ToString(checksum).Replace("-", string.Empty);
                }
            }
            var stop = DateTime.Now;
            Console.WriteLine(stop - start);

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sha256_helper
{
    public static class SHAHelper
    {
        public static string GetSHA256(string fileName)
        {
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            return GetChecksumBuffered(fileStream);
        }

        private static string GetChecksum(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower();
            }
        }

        private static string GetChecksumBuffered(Stream stream)
        {
            using (var bufferedStream = new BufferedStream(stream, 1024 * 32))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(bufferedStream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower();
            }
        }
    }
}

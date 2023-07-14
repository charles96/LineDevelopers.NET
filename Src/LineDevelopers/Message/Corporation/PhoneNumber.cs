using System.Security.Cryptography;
using System.Text;

namespace Line.Message.Corporation
{
    public class PhoneNumber
    {
        public static string EncryptSHA256(string phoneNumber)
        {
            var sb = new StringBuilder();

            using (var sHA256 = SHA256.Create())
            {   
                byte[] hash = sHA256.ComputeHash(Encoding.UTF8.GetBytes(phoneNumber));

                foreach (byte byteNum in hash)
                    sb.Append(byteNum.ToString("x2"));
            }

            return sb.ToString();
        }

        public static async Task<string> EncryptSHA256Async(string phoneNumber)
        {
            var sb = new StringBuilder();

            using (var streamPhone = new MemoryStream(Encoding.UTF8.GetBytes(phoneNumber)))
            {
                using (var sHA256 = SHA256.Create())
                {
                    byte[] hash = await sHA256.ComputeHashAsync(streamPhone).ConfigureAwait(false);

                    foreach (byte b in hash)
                        sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}

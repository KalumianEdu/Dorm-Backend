using System;
using System.Security.Cryptography;

namespace DormAPI.Helpers
{
    public static class IdGenerator
    {
        // Option A: 15-character Alphanumeric ID
        public static string Generate15CharId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            byte[] data = new byte[15];
            RandomNumberGenerator.Fill(data);

            char[] result = new char[15];
            for (int i = 0; i < 15; i++)
            {
                result[i] = chars[data[i] % chars.Length];
            }
            return new string(result);
        }

        // Option B: 15-character Hexadecimal ID
        public static string Generate15HexId()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 15);
        }
    }
}
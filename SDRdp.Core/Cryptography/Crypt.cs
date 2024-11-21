using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SDRdp.Core.Cryptography;

public static class Crypto
{
    private static string PrivateKey
    {
        get
        {
            var key = "3fb7fe5dbb0643caa984f53de6fffd0f";

            return key;
        }
    }

    private static byte[] CreateAesKey(string inputString)

    {
        return Encoding.UTF8.GetByteCount(inputString) == 32 ? Encoding.UTF8.GetBytes(inputString) : SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public static string Encrypt(string plainText, string publicKey)
    {
        var keyBuffer = new byte[16];
        for (int i = 0; i < keyBuffer.Length; i++)
            keyBuffer[i] = i > publicKey.Length - 1 ? byte.MinValue : (byte)publicKey[i];

        publicKey = Convert.ToBase64String(keyBuffer);

        if (plainText is not { Length: > 0 })
            throw new ArgumentNullException(nameof(plainText));
        if (PrivateKey is not { Length: > 0 })
            throw new ArgumentNullException(nameof(PrivateKey));
        if (publicKey is not { Length: > 0 })
            throw new ArgumentNullException(nameof(publicKey));

        byte[] encrypted;

        using (var aesAlg = Aes.Create())
        {
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Key = CreateAesKey(PrivateKey);
            aesAlg.IV = Convert.FromBase64String(publicKey);
            //aesAlg.GenerateKey();
            //aesAlg.GenerateIV();

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(encrypted);
    }
    public static string Decrypt(string cipherText, string publicKey)
    {
        var keyBuffer = new byte[16];
        for (int i = 0; i < keyBuffer.Length; i++)
            keyBuffer[i] = i > publicKey.Length - 1 ? byte.MinValue : (byte)publicKey[i];

        publicKey = Convert.ToBase64String(keyBuffer);

        if (cipherText is not { Length: > 0 })
            throw new ArgumentNullException(nameof(cipherText));
        if (PrivateKey is not { Length: > 0 })
            throw new ArgumentNullException(nameof(PrivateKey));
        if (publicKey is not { Length: > 0 })
            throw new ArgumentNullException(nameof(publicKey));

        using var aesAlg = Aes.Create();
        aesAlg.Mode = CipherMode.CBC;
        aesAlg.Key = CreateAesKey(PrivateKey);
        aesAlg.IV = Convert.FromBase64String(publicKey);

        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        var plaintext = srDecrypt.ReadToEnd();

        return plaintext;
    }
}
﻿using System;
using System.IO;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Cryptography;
using System.Text;


namespace SDRdp.Core.Security.SymmetricEncryption
{
    [SupportedOSPlatform("windows")]
    public class LegacyRijndaelCryptographyProvider : ICryptographyProvider
    {
        public int BlockSizeInBytes { get; }

        public BlockCipherEngines CipherEngine { get; }

        public BlockCipherModes CipherMode { get; }
        public int KeyDerivationIterations { get; set; }

        public LegacyRijndaelCryptographyProvider()
        {
            BlockSizeInBytes = 16;
        }

        public string Encrypt(string strToEncrypt, SecureString strSecret)
        {
            if (string.IsNullOrWhiteSpace(strToEncrypt) || strSecret.Length == 0)
                return strToEncrypt;

            try
            {
                using Aes aes = Aes.Create();
                aes.BlockSize = BlockSizeInBytes * 8;

                using (MD5 md5 = MD5.Create())
                {
                    byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes(strSecret.ConvertToUnsecureString()));
                    aes.Key = key;
                    aes.GenerateIV();
                }

                using MemoryStream ms = new();
                ms.Write(aes.IV, 0, BlockSizeInBytes);

                using CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] data = Encoding.UTF8.GetBytes(strToEncrypt);

                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();

                byte[] encdata = ms.ToArray();

                return Convert.ToBase64String(encdata);
            }
            catch (Exception ex)
            {
            }

            return strToEncrypt;
        }

        public string Decrypt(string ciphertextBase64, SecureString password)
        {
            if (string.IsNullOrEmpty(ciphertextBase64) || password.Length == 0)
                return ciphertextBase64;

            try
            {
                using Aes aes = Aes.Create();
                aes.BlockSize = BlockSizeInBytes * 8;

                using (MD5 md5 = MD5.Create())
                {
                    byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes(password.ConvertToUnsecureString()));
                    aes.Key = key;
                }

                byte[] ciphertext = Convert.FromBase64String(ciphertextBase64);

                using MemoryStream ms = new(ciphertext);

                byte[] iv = new byte[BlockSizeInBytes];
                ms.Read(iv, 0, iv.Length);
                aes.IV = iv;

                using CryptoStream cryptoStream = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
                using StreamReader streamReader = new(cryptoStream, Encoding.UTF8, true);
                string plaintext = streamReader.ReadToEnd();

                return plaintext;
            }
            catch (Exception ex)
            {
                throw new EncryptionException("ErrorDecryptionFailed", ex);
            }
        }
    }
}
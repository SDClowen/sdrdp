using SDRdp.Core.Security;
using SDRdp.Core.Security.Factories;

namespace SDRdp.Core.Cryptography;

public static class Crypto
{
    /// <summary>
    /// The crypto provider
    /// </summary>
    private static ICryptographyProvider _cryptProvider = new CryptoProviderFactory(BlockCipherEngines.AES, BlockCipherModes.GCM).Build();

    /// <summary>
    /// Encrypt with provided crypto engine
    /// </summary>
    /// <param name="plainText">The plain text</param>
    /// <param name="key">The crypto key</param>
    /// <returns>The encrypted text</returns>
    public static string Encrypt(string plainText, string key)
        => _cryptProvider.Encrypt(plainText, key.ConvertToSecureString());

    /// <summary>
    /// Decrypt the plain text with provided crypto engine
    /// </summary>
    /// <param name="plainText">The plain text</param>
    /// <param name="key">The crypto key</param>
    /// <returns>The decrpyted text</returns>
    public static string Decrypt(string plainText, string key)
        => _cryptProvider.Decrypt(plainText, key.ConvertToSecureString());
}
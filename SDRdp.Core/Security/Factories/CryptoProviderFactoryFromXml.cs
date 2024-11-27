using System;
using System.Runtime.Versioning;
using System.Xml.Linq;
using SDRdp.Core.Security.SymmetricEncryption;

namespace SDRdp.Core.Security.Factories
{
    [SupportedOSPlatform("windows")]
    public class CryptoProviderFactoryFromXml : ICryptoProviderFactory
    {
        private readonly XElement _element;

        public CryptoProviderFactoryFromXml(XElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            _element = element;
        }

        public ICryptographyProvider Build(BlockCipherEngines engine = BlockCipherEngines.AES, BlockCipherModes mode = BlockCipherModes.GCM, int iterations = 10000)
        {
            ICryptographyProvider cryptoProvider;
            try
            {
                engine = (BlockCipherEngines)Enum.Parse(typeof(BlockCipherEngines),
                                                            _element?.Attribute("EncryptionEngine")?.Value ?? "");
                mode = (BlockCipherModes)Enum.Parse(typeof(BlockCipherModes),
                                                        _element?.Attribute("BlockCipherMode")?.Value ?? "");
                cryptoProvider = new CryptoProviderFactory(engine, mode).Build();

                int keyDerivationIterations = int.Parse(_element?.Attribute("KdfIterations")?.Value ?? "");
                cryptoProvider.KeyDerivationIterations = keyDerivationIterations;
            }
            catch (Exception)
            {
                return new LegacyRijndaelCryptographyProvider();
            }

            return cryptoProvider;
        }
    }
}
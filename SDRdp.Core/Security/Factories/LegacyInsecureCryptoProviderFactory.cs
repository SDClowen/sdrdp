using SDRdp.Core.Security.SymmetricEncryption;
using System.Runtime.Versioning;

namespace SDRdp.Core.Security.Factories
{
    [SupportedOSPlatform("windows")]
    public class LegacyInsecureCryptoProviderFactory : ICryptoProviderFactory
    {
        public ICryptographyProvider Build(BlockCipherEngines engine = BlockCipherEngines.AES, BlockCipherModes modes = BlockCipherModes.GCM, int iterations = 10000)
        {
            return new LegacyRijndaelCryptographyProvider();
        }
    }
}
namespace SDRdp.Core.Security.Factories
{
    public class CryptoProviderFactoryFromSettings : ICryptoProviderFactory
    {
        public ICryptographyProvider Build(BlockCipherEngines engine = BlockCipherEngines.AES, BlockCipherModes modes = BlockCipherModes.GCM, int iterations = 10000)
        {
            ICryptographyProvider provider =
                new CryptoProviderFactory(engine, modes).Build();
            provider.KeyDerivationIterations = iterations;

            return provider;
        }
    }
}
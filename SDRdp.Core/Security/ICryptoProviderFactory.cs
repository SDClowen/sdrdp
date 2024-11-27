namespace SDRdp.Core.Security
{
    public interface ICryptoProviderFactory
    {
        ICryptographyProvider Build(BlockCipherEngines engine, BlockCipherModes mode, int iterations);
    }
}
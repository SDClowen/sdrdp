﻿using System;


namespace SDRdp.Core.Security
{
    [Serializable]
    public class EncryptionException : Org.BouncyCastle.Security.EncryptionException
    {
        public EncryptionException(string message) : base(message)
        {
        }

        public EncryptionException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
using System;

namespace SDRdp.Core.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class CommandLineArgumentAttribute : Attribute
{
    public string ArgumentFormat { get; }
    public object? DefaultValue { get; }

    public CommandLineArgumentAttribute(string argumentFormat)
    {
        ArgumentFormat = argumentFormat;
    }
    public CommandLineArgumentAttribute(string argumentFormat, object defaultValue)
    {
        ArgumentFormat = argumentFormat;
        DefaultValue = defaultValue;
    }
}
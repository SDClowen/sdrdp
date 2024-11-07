using System;

namespace SDRdp.Core.Attributes;

internal class CommandLineToggleArgumentAttribute : Attribute
{
    public string ToggleText { get; }
    public bool DefaultValue { get; }

    public CommandLineToggleArgumentAttribute(string toggleText, bool defaultValue)
    {
        ToggleText = toggleText;
        DefaultValue = defaultValue;
    }
}
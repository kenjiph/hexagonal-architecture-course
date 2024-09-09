﻿using System.Text.RegularExpressions;

namespace WebApi.Transformers;

public class SlugyParametersTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object? value)
        => Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLowerInvariant();
}

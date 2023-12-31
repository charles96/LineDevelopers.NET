﻿using System.Text.Json;

namespace Line
{
    internal class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator
    {
        readonly Dictionary<string, string> dictionary;
        internal DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy underlyingNamingPolicy) : base(underlyingNamingPolicy) => this.dictionary = dictionary ?? throw new ArgumentNullException();
        public override string ConvertName(string name) => dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
    }
}

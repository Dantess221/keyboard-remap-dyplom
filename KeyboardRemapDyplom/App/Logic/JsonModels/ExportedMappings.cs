namespace App.Logic.JsonModels
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class ExportedMappings
    {
        [JsonProperty("key_mappings")]
        public Dictionary<int, int> KeyMappings { get; set; }

        [JsonProperty("structure_version")]
        public int StructureVersion { get; set; }
    }
}
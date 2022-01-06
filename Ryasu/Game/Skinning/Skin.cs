using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Ryasu.Game.Skinning.Advanced;
using Newtonsoft.Json.Converters;

namespace Ryasu.Game.Skinning
{
    public class Skin
    {
        [JsonProperty("Name")]
        public string SkinName { get; set; }


        [JsonProperty("Author")]
        public string SkinAuthor { get; set; }


        [JsonIgnore]
        public bool DefaultSkin { get; set; }


        [JsonProperty("KeyModes")]
        public List<List<SkinnedLaneTexture>> KeyModes { get; set; }


        [JsonProperty("HitPositions")]
        public List<int> HitPositions { get; set; }


        [JsonProperty("HitSoundDefault")]
        public string DefaultHitSound { get; set; }


        [JsonProperty("HitSoundClap")]
        public string ClapHitSound { get; set; }


        [JsonProperty("HitSoundWhistle")]
        public string WhistleHitSound { get; set; }


        [JsonProperty("HitSoundFinish")]
        public string FinishHitSound { get; set; }
    }
}

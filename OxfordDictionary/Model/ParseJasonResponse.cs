using Newtonsoft.Json;


namespace OxfordDictionary.Model
{
   public partial class ParseJasonResponse
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("word")]
        public string Word { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("schema")]
        public string Schema { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lexicalEntries")]
        public LexicalEntry[] LexicalEntries { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

       [JsonProperty("word")]
        public string Word { get; set; }
    }

    public partial class LexicalEntry
    {
        [JsonProperty("entries")]
        public Entry[] Entries { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lexicalCategory")]
        public LexicalCategory LexicalCategory { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Entry
    {
        [JsonProperty("senses")]
        public Sense[] Senses { get; set; }
    }

    public partial class Sense
    {
        [JsonProperty("definitions")]
        public string[] Definitions { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("subsenses", NullValueHandling = NullValueHandling.Ignore)]
        public Subsense[] Subsenses { get; set; }
    }

    public partial class Subsense
    {
        [JsonProperty("definitions")]
        public string[] Definitions { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class LexicalCategory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
    

}

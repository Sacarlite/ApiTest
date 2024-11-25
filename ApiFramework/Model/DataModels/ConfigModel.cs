using System.Runtime.Serialization;

namespace ApiFramework.Model.DataModels
{
    [DataContract]
    public class ConfigModel
    {
        [DataMember(Name = "url")]
        public string? Url { get; set; }
    }
}

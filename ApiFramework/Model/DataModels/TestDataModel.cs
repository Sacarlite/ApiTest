using ApiFramework.Model.ResponseModels;
using System.Runtime.Serialization;

namespace ApiFramework.Model.DataModels
{
    [DataContract]
    public class TestDataModel
    {
        [DataMember(Name = "getPostModel")]
        public PostModel GetPostModel { get; set; }

        [DataMember(Name = "badGetPostModel")]
        public PostModel BadGetPostModel { get; set; }

        [DataMember(Name = "postModel")]
        public PostModel PostModel { get; set; }

        [DataMember(Name = "testUserModel")]
        public UserModel testUserModel { get; set; }

        [DataMember(Name = "titleLenght")]
        public int TitleLenght { get; set; }
        [DataMember(Name = "bodyLenght")]
        public int BodyLenght { get; set; }
    }
}

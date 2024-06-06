
namespace Categories.Domain.Resources.Tags
{
    public struct TagTypes
    {
        public const string Tag = "Tag";
        public const string BookType = "BookType";
        public const string LanguageTag = "LanguageTag";

        public static List<string> GetAllTypes()
        {
            return new List<string>()
            {
                Tag,
                BookType,
                LanguageTag
            };
        }
    }
}

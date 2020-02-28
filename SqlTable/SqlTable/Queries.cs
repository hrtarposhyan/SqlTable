
namespace SqlTable
{
    public static class Queries
    {
        public const string InsertWithParams = "INSERT INTO {0} ({1}) VALUES ({2});SELECT CAST(scope_identity() AS int)";
    }
}

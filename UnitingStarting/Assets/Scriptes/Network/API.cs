

public class API
{
    public const string DOMAIN = "https://www.cheapshark.com/api/1.0/";
    public static string Deals => $"{DOMAIN}deals?storeID=1&upperPrice=15";
}

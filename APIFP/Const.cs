namespace APIFP
{
    internal class Const
    {
        public const string baseUrl      = "https://api.flightplandatabase.com/";

        public const string generateUrl  = baseUrl + "auto/generate";

        public const string metarRequest = baseUrl + "weather/{0}";

        public const string planId       = baseUrl + "plan/{0}";

        public const string userPlans    = baseUrl + "user/{0}/plans";

        public const string airpotInfo   = baseUrl + "nav/airport/{0}";
    }
}

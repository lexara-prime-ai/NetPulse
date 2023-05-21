using System;

namespace HTTPWebServer
{
    public class Request
    {
        public String? Type { get; set; }
        public String? URL { get; set; }
        public String? Host { get; set; }

        // CREATE CONSTRUCTOR
        private Request(String type, String url, String host)
        {

        }

        public static Request? GetRequest(String request)
        {
            if (String.IsNullOrEmpty(request))
                return null;

            String[] tokens = request.Split(' ');
            // TEMPORARILY PREVENT ERROR
            return new Request("", "", "");
        }
    }
}
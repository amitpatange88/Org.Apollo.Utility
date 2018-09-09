using System.Net;

namespace Org.Apollo.Utility
{
    class Internet
    {
        /// <summary>
        /// This checks if internet connection is ACTIVE or not.
        /// Method : Static
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectionActive()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://example.com/"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

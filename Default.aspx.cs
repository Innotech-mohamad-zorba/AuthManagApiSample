using System;
using System.Web.UI;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace managementApi
{
    public partial class _Default : Page
    {
        private readonly string _accessToken = "put correct value from your side";
        private readonly string _email = "put correct value from your side";
        private readonly string _auth0Domain = "put correct value from your side";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var manApiClient = new ManagementApiClient(_accessToken, new Uri(string.Format("https://{0}/api/v2", _auth0Domain)));

                // pending here with no response or exceptions, some strange behavior
                var users = manApiClient.Users.GetAllAsync(new GetUsersRequest() { Query = $@"email:""{_email.ToLower()}""", SearchEngine = "v3" }).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
            }
        }
    }
}
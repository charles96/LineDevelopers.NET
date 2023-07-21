using System.Web;
using Line;
using Line.Login;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LineDevelopers.OAuth.Tests.Pages
{
    public class CallbackModel : PageModel
    {
        public async Task OnGet()
        {
            string clientId = "";
            string secret = "";

            using (LineLoginClient client = new LineLoginClient())
            {
                var code = Request.Query["code"];

                var issued = await client.OAuth2dot1.IssueAccessTokenAsync(code,
                                    HttpUtility.HtmlEncode("https://2100-175-113-116-30.ngrok-free.app/Callback"),
                                    clientId,
                                    secret);

                
                var verifyToken = await client.OAuth2dot1.VerifyAccessTokenValidityAsync(issued.AccessToken);
                
                var verifyScope = verifyToken.Scope;
                var verifyClientId = verifyToken.ClientId;
                var verifyExpiresIn = verifyToken.ExpiresIn;

                var verifyIdToken =  await client.OAuth2dot1.VerifyIdTokenAsync(issued.IdToken, clientId);
                
                var iss = verifyIdToken.Iss;
                var sub = verifyIdToken.Sub;
                var aud = verifyIdToken.Aud;

                var user = await client.OAuth2dot1.GetUserInformationAsync(issued.AccessToken);

                var userSub = user.Sub;
                var userName = user.Name;

                var profile = await client.GetUserProfileAsync(issued.AccessToken);

                var profileName = profile.DisplayName;

                var friendship = await client.GetFriendshipStatusAsync(issued.AccessToken);

              
                await client.OAuth2dot1.RevokeAccessTokenAsync(issued.AccessToken, clientId, secret);

                try
                {
                    var refresh = await client.OAuth2dot1.RefreshAccessTokenAsync(issued.RefreshToken, clientId, secret);

                    var refreshAccess = refresh.AccessToken;

                }
                catch (LineCredentialException ex)
                {
                    var msg = ex.Message;
                    var detail = ex.Detail;
                }

            }


        }
    }
}

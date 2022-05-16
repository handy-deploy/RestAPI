using Microsoft.AspNetCore.Mvc;
using Octokit;
using Persistence;

namespace RestAPI.Controllers.Api.V1;

public class GithubController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Test()
    {
        /*var clientId = EnvironmentSettings.GithubClientId;
        var clientSecret = EnvironmentSettings.GithubClientSecret;
        var client = new GitHubClient(new ProductHeaderValue("Handy-Deploy"));

        var token = "6555555555555555";

        var request = new OauthLoginRequest(clientId)
        {
            Scopes = { "repo", "user" },
            RedirectUri = ""
            State = token
        };

        var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);

        return Redirect(oauthLoginUrl.ToString());*/

        return new OkResult();
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Loonfactory.Google.Apis.YouTube.V3.Captions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Loonfactory.Google.Apis.YouTube.V3.Example.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public IYouTubeCaptions Captions { get; }
    private readonly SignInManager<IdentityUser> _signInManager;

    public IndexModel(
        ILogger<IndexModel> logger,
        IYouTubeCaptions captions,
        SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        _signInManager = signInManager;

        Captions = captions;
    }

    public async void OnGet()
    {
        if (_signInManager.IsSignedIn(User))
        {
            var result = await Captions.ListAsync(["id"], "cN22IvXMSpw").ConfigureAwait(false);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Loonfactory.Google.Apis.YouTube.V3.Captions;

namespace Loonfactory.Google.Apis.YouTube.V3.Example.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public IYouTubeCaptions Captions { get; }

    public IndexModel(ILogger<IndexModel> logger, IYouTubeCaptions captions)
    {
        _logger = logger;

        Captions = captions;
    }

    public void OnGet()
    {

    }
}

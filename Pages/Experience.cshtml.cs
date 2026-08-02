using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages;

public sealed class ExperienceModel : PageModel
{
    public IReadOnlyList<Experience> Roles { get; } = ExperienceData.Roles;

    public IReadOnlyList<SideProject> SideProjects { get; } = ExperienceData.SideProjects;
}
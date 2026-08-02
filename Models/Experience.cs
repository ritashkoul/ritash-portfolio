namespace Portfolio.Models;

public sealed record Experience(
    string Company,
    string CompanyUrl,
    string Role,
    string Duration,
    string Location,
    string ProjectTitle,
    string ProjectSummary,
    IReadOnlyList<string> KeyContributions,
    IReadOnlyList<ExperienceDetailSection> DetailSections,
    IReadOnlyList<string> Highlights,
    IReadOnlyList<string> Technologies,
    bool IsFeatured = true);
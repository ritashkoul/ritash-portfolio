namespace Portfolio.Models;

public sealed record SideProject(
    string FileName,
    string Title,
    string Description,
    IReadOnlyList<string> Tags,
    string? Link);
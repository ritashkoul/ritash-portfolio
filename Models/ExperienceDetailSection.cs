namespace Portfolio.Models;

public sealed record ExperienceDetailSection(
    string Title,
    IReadOnlyList<string> Paragraphs,
    IReadOnlyList<string> Points);
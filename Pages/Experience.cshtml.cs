using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio.Pages;

public class ExperienceModel : PageModel
{
    public IReadOnlyList<ExperienceEntry> Roles { get; } =
    [
        new(
            "Addnode Group", "https://www.addnodegroup.com",
            "Software Developer", "Oct 2022 — Present", "Pune, India / Karlskrona, Sweden",
            "Enterprise GIS Platform for Swedish Municipalities",
            "Developing an enterprise GIS platform built on ESRI ArcGIS Pro, enabling around 100 Swedish " +
            "municipalities to manage GIS-driven town planning, infrastructure, and urban development.",
            [
                "Develop enterprise features using C#, .NET, WPF, and the ArcGIS Pro SDK.",
                "Design and build custom ArcGIS Pro add-ins using C# and Python to enhance spatial analysis and planning workflows.",
                "Design and develop REST APIs that integrate third-party geospatial services into the platform.",
                "Collaborate closely with Product Owners, Project Managers, and engineering teams across India, Sweden, and Lithuania to deliver new product capabilities.",
                "Represented Addnode India at the ESRI European Summit, collaborating with ESRI experts and GIS professionals."
            ],
            [
                "Platform used by ~100 Swedish municipalities",
                "Cross-functional collaboration across 3 countries",
                "Enterprise desktop and GIS application development"
            ],
            ["C#", ".NET", "WPF", "ArcGIS Pro SDK", "Python", "SQL Server", "REST APIs", "GIS"]
        ),
        new(
            "Cognizant", "https://www.cognizant.com",
            "Senior Consultant", "Dec 2021 — Oct 2022", "Pune, India",
            "Medical Device Registration Platform",
            "Developed the Device Registration module responsible for securely onboarding infusion pumps " +
            "into a connected medical device ecosystem.",
            [
                "Designed and implemented REST APIs and MQTT-based communication for secure device registration.",
                "Mentored 3–5 developers, providing technical guidance, code reviews, and implementation support.",
                "Built a proof of concept that enabled the complete application stack to run on a local Kubernetes cluster.",
                "The Kubernetes proof of concept was later adopted by the DevOps team as the foundation for local development and deployment.",
                "Collaborated with architects and product teams to deliver secure and scalable healthcare solutions."
            ],
            new[]
            {
                "Mentored junior developers",
                "Kubernetes POC adopted by DevOps",
                "Enterprise IoT and healthcare platform"
            },
            ["C#", "ASP.NET Core", "WPF", "MQTT", "IoT", "Docker", "Kubernetes", "REST APIs"]
        ),
        new(
            "CoreView Systems", "https://coreviewsystems.com",
            "Senior Software Engineer", "Sep 2021 — Nov 2021", "Pune, India",
            "Electricity Customer Management System",
            "Developed enterprise desktop applications supporting electricity customer management, billing, " +
            "and service operations.",
            [
                "Developed WPF applications following the MVVM architecture.",
                "Built background services for automated billing and meter-reading processing.",
                "Designed and implemented REST APIs supporting customer management and billing operations.",
                "Collaborated with the development team to deliver new features and maintain application reliability."
            ],
            [],
            ["C#", ".NET", "WPF", "MVVM", "SQL Server", "REST APIs"]
        ),
        new(
            "S&P Global", "https://www.spglobal.com/market-intelligence",
            "Senior Software Developer", "Mar 2017 — Sep 2021", "Gurgaon, India",
            "Enterprise Financial Data Processing Platform",
            "Developed enterprise applications responsible for processing financial data, analytics, and " +
            "transaction reporting used across global financial products.",
            [
                "Developed REST APIs consumed by enterprise desktop and web applications.",
                "Migrated backend services from .NET Framework to modern .NET, improving maintainability and application performance.",
                "Built and maintained CI/CD pipelines using Azure DevOps.",
                "Developed backend services that consumed Kafka events generated from Attunity CDC, processing changes to financial data items and ratios.",
                "Implemented business logic that executed hundreds of financial calculations on every incoming change before publishing the processed results for downstream enterprise applications.",
                "Collaborated with distributed engineering teams across India, the United States, and Canada throughout the software development lifecycle."
            ],
            [
                "Processed thousands of financial data change events",
                "Performed hundreds of financial calculations for each incoming data update",
                "Worked with globally distributed engineering teams"
            ],
            ["C#", ".NET", "ASP.NET Core", "WPF", "MVVM", "SQL Server", "Azure DevOps", "Kafka", "REST APIs"]
        ),
        new(
            "Capgemini", "https://www.capgemini.com",
            "Software Developer", "Aug 2014 — Mar 2017", "Noida, India",
            "Insurance Policy Management System (Client: RSA Insurance Group)",
            "Started my software engineering career by developing enterprise desktop applications for policy " +
            "administration and insurance operations.",
            [
                "Developed and enhanced WPF applications using the MVVM architecture.",
                "Implemented new business features and resolved production issues.",
                "Participated in requirement analysis, effort estimation, and application enhancements.",
                "Collaborated with multiple development teams across India and Sweden to deliver enterprise solutions.",
                "Worked directly with client stakeholders to investigate and resolve production incidents."
            ],
            [
                "Contributed to enterprise insurance applications",
                "International collaboration with teams in India and Sweden",
                "Built a strong foundation in enterprise software development"
            ],
            ["C#", ".NET", "WPF", "MVVM", "SQL Server"]
        ),
    ];

    // Add personal/side projects here as you build them.
    public IReadOnlyList<SideProjectEntry> SideProjects { get; } =
    [
        new("Portfolio.sln", "Portfolio website", "The site you're looking at right now.", ["ASP.NET Core"], "https://github.com/ritashkoul/ritash-portfolio"),
    ];

    public void OnGet()
    {
    }
}

public record ExperienceEntry(
    string Company,
    string CompanyUrl,
    string Role,
    string Duration,
    string Location,
    string ProjectTitle,
    string ProjectSummary,
    string[] KeyContributions,
    string[] Highlights,
    string[] Tech);

public record SideProjectEntry(string FileName, string Title, string Description, string[] Tags, string? Link);
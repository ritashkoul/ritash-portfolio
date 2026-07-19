using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio.Pages;

public record ExperienceEntry(
    string Company,
    string CompanyUrl,
    string Role,
    string Duration,
    string Location,
    string ProjectTitle,
    string Description,
    string[] Tech);

public record SideProjectEntry(string FileName, string Title, string Description, string[] Tags, string? Link);

public class ExperienceModel : PageModel
{
    // Drawn from the résumé. Descriptions focus on the problem, my role, and
    // the tech used - not internal/proprietary specifics.
    public IReadOnlyList<ExperienceEntry> Roles { get; } = new List<ExperienceEntry>
    {
        new(
            "Addnode Group", "https://www.addnodegroup.com",
            "Lead Software Developer", "Oct 2022 — Present", "Pune, India / Karlskrona, Sweden",
            "Map and Planning",
            "Developing an enterprise GIS application on ESRI's ArcGIS Pro platform for Swedish municipalities, " +
"supporting GIS-driven town planning and urban development workflows. Collaborating with product " +
"owners and project managers to design and deliver scalable GIS solutions. " +
"Building custom WPF and Python add-ins for ArcGIS Pro to streamline spatial analysis and " +
"planning workflows. Working closely with the ESRI Sweden team to integrate new ArcGIS Pro " +
"capabilities. Designing and developing REST APIs that integrate third-party geospatial data " +
"services with our enterprise platform. Represented Addnode India at the ESRI European Summit, " +
"engaging with ESRI experts and industry leaders on enterprise GIS solutions.",
            ["C#", ".NET", ".NET Core", "WPF", "SQL Server", "REST APIs", "ArcGIS Pro SDK", "Python", "GIS"]
        ),
        new(
    "Cognizant", "https://www.cognizant.com",
    "Senior Consultant", "Dec 2021 — Oct 2022", "Pune, India",
     "FK VSS Suite — Device Registration",
    "Led the development of the Device Registration module, the primary entry point of the medical " +
    "device ecosystem, enabling secure onboarding of infusion pumps into the platform. Designed and " +
    "implemented REST APIs and MQTT-based IoT communication for device provisioning and registration. " +
    "Led a team of developers, driving technical design, implementation, and delivery of key features. " +
    "Additionally, built a proof of concept for running the complete application stack on a local " +
    "Kubernetes cluster, laying the foundation for the team's containerization and Kubernetes adoption.",
    ["C#", ".NET", "ASP.NET Core", "WPF", "MQTT", "IoT", "REST APIs", "Kubernetes", "Docker"]
),
        new(
        "CoreView Systems", "https://coreviewsystems.com",
        "Senior Software Engineer", "Sep 2021 — Nov 2021", "Pune, India",
        "ECMS",
        "Developed a WPF application using the MVVM architecture for an electricity customer management " +
        "system, delivering a responsive and maintainable user experience. Implemented background " +
        "services for automated billing, meter-reading processing, and data synchronization. Designed " +
        "and integrated REST APIs to support real-time customer information, billing operations, and " +
        "service request management.",
        ["C#", ".NET", "WPF", "MVVM", "SQL Server", "REST APIs"]
    ),
      new(
    "S&P Global", "https://www.spglobal.com/market-intelligence",
    "Senior Software Developer", "Mar 2017 — Sep 2021", "Gurgaon, India",
    "Financial Data & Transaction Processing",
    "Developed and maintained enterprise applications for financial data processing and transaction " +
    "reporting, building REST APIs consumed by WPF and web applications to calculate and deliver " +
    "large-scale financial analytics. Led the migration of backend services from .NET Framework to " +
    ".NET, improving performance and maintainability. Established CI/CD pipelines using Azure DevOps " +
    "and designed a Kafka-based publish-subscribe system to synchronize real-time data across " +
    "distributed applications during a large-scale company integration.",
    ["C#", ".NET", "ASP.NET Core", "WPF", "MVVM", "SQL Server", "REST APIs", "Azure DevOps", "Kafka"]
),
       new(
    "Capgemini", "https://www.capgemini.com",
    "Software Developer", "Aug 2014 — Mar 2017", "Noida, India",
    "Insurance Policy Management System (Client: RSA Insurance Group)",
    "Developed and enhanced WPF applications using the MVVM architecture for an enterprise insurance " +
    "platform. Implemented new features, integrated business logic, and resolved production issues " +
    "to improve application stability and user experience. Collaborated with business stakeholders " +
    "on requirement analysis, effort estimation, and change requests, while working directly with " +
    "the client to troubleshoot and resolve production incidents.",
    ["C#", ".NET Framework", "WPF", "MVVM", "WCF", "SQL Server"]
),
    };

    // Optional - add personal/side projects here as you build them.
    public IReadOnlyList<SideProjectEntry> SideProjects { get; } = new List<SideProjectEntry>
    {
        // new("ThisPortfolio.sln", "This Portfolio Site", "The site you're looking at right now.", new[] { "ASP.NET Core", "Security" }, "https://github.com/your-handle/portfolio"),
    };

    public void OnGet()
    {
    }
}

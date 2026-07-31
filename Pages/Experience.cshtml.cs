using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio.Pages;

public class ExperienceModel : PageModel
{
    public IReadOnlyList<ExperienceEntry> Roles { get; } =
    [
        new(
            Company: "Addnode Group",
            CompanyUrl: "https://www.addnodegroup.com",
            Role: "Senior Software Developer",
            Duration: "Oct 2022 — Present",
            Location: "Pune, India",
            ProjectTitle: "Gaida — Mapping and Town Planning",
            Overview:
                "I work on the modernization of Gaida, an enterprise GIS platform used by more than " +
                "100 Swedish municipalities for mapping, town planning, zoning, " +
                "and urban development. The work involves rebuilding mature " +
                "ArcMap-based products on the ArcGIS Pro platform.",
            KeyContributions:
            [
                "Designed and developed multiple ArcGIS Pro add-ins from scratch using C#, .NET, WPF, MVVM, and the ArcGIS Pro SDK.",
                "Built GIS tools covering map interaction, editing, symbology, layouts, enterprise geodatabases, and geoprocessing workflows.",
                "Developed Plugin Data Sources that allow supported GIS formats to be loaded and represented as spatial features within ArcGIS Pro.",
                "Built Geoprocessing tools using Python and ArcPy to automate GIS and planning workflows.",
                "Developed REST API integrations with Lantmäteriet, Sweden's national mapping and cadastral authority.",
                "Contributed to application architecture, technical design, code reviews, maintainability, and long-term product evolution."
            ],
            DetailSections:
            [
                new(
                    Title: "Rebuilding mature GIS products",
                    Paragraphs:
                    [
                        "This is not a direct code migration. ArcMap and ArcGIS Pro use substantially different SDKs, so existing workflows must often be redesigned rather than simply ported.",
                        "The work requires preserving established municipal planning processes while rebuilding the underlying desktop architecture, GIS integrations, user experience, and data-access workflows for ArcGIS Pro."
                    ],
                    Points:
                    [
                        "Redesigning legacy ArcMap workflows for ArcGIS Pro.",
                        "Integrating enterprise geodatabases with desktop editing workflows.",
                        "Maintaining compatibility with existing municipal business processes."
                    ]
                ),
                new(
                    Title: "ArcGIS Pro Platform Development",
                    Paragraphs:
                    [
                        "My work uses a broad range of ArcGIS Pro SDK capabilities rather than focusing on a single map tool or screen.",
                        "The add-ins combine WPF-based user interfaces with GIS-specific services for editing, rendering, data access, geoprocessing, layouts, and map interaction."
                    ],
                    Points:
                    [
                        "Mapping and map interaction.",
                        "Feature and attribute editing.",
                        "Geometry and spatial operations.",
                        "Symbology and rendering.",
                        "Layouts and map presentation.",
                        "Enterprise geodatabase operations.",
                        "Geoprocessing and ArcPy automation.",
                        "Custom Plugin Data Sources."
                    ]
                ),
                new(
                    Title: "Global cross-functional collaboration",
                    Paragraphs:
                    [
                        "I collaborate with distributed product and engineering teams working across India, Sweden, and Lithuania.",
                        "This includes technical discussions, code reviews, knowledge sharing, and aligning implementation decisions across teams."
                    ],
                    Points:
                    [
                        "Worked onsite with Addnode teams in Sweden and Lithuania.",
                        "Represented Addnode India at the Esri European Developer Summit 2024."
                    ]
                )
            ],
            Highlights:
            [
                "Enterprise GIS products used by 100+ Swedish municipalities",
                "Rebuilding ArcMap products on ArcGIS Pro",
                "Esri European Developer Summit 2024"
            ],
            Tech:
            [
                "C#",
                ".NET",
                "WPF",
                "MVVM",
                "ArcGIS Pro SDK",
                "Python",
                "ArcPy",
                "SQL Server",
                "Enterprise Geodatabase",
                "REST APIs",
                "GIS"
            ],
            IsFeatured: true
        ),

        new(
            Company: "Cognizant",
            CompanyUrl: "https://www.cognizant.com",
            Role: "Senior Consultant",
            Duration: "Dec 2021 — Oct 2022",
            Location: "Pune, India",
            ProjectTitle: "FK VSS Suite — Medical Device Registration",
            Overview:
                "I worked on an enterprise IoT platform for medical infusion devices. " +
                "The devices consisted of medical racks containing infusion pumps used to deliver " +
                "medication to patients. My primary responsibility was leading the Device Registration " +
                "module that onboarded these devices into the software ecosystem.",
            KeyContributions:
            [
                "Led the Device Registration module and mentored two developers through design, implementation, debugging, and code reviews.",
                "Developed microservices, background services, and REST APIs for registering and managing medical devices.",
                "Integrated Mosquitto for communication between medical devices and backend services.",
                "Used Kafka for asynchronous event processing and communication across backend services.",
                "Worked with Product Owners, Business Analysts, QA, architects, and DevOps teams throughout feature delivery.",
                "Created the initial Kubernetes Proof of Concept before the dedicated DevOps environment was established."
            ],
            DetailSections:
            [
                new(
                    Title: "Device registration and IoT communication",
                    Paragraphs:
                    [
                        "Medical devices communicated with the platform through MQTT. Mosquitto acted as the MQTT broker, receiving device messages and making them available to the registration and backend services.",
                        "Kafka served a different purpose: backend services published and consumed asynchronous events after processing device-related data, enabling communication between independently deployed services."
                    ],
                    Points:
                    [
                        "MQTT for communication between devices and the application.",
                        "Mosquitto as the MQTT message broker.",
                        "Kafka for asynchronous backend event processing.",
                        "REST APIs for registration and management workflows.",
                        "Background services for message and event handling."
                    ]
                ),
                new(
                    Title: "Kubernetes platform Proof of Concept",
                    Paragraphs:
                    [
                        "When I joined, product development was starting and a dedicated DevOps setup was not yet available. I was assigned to prove that the application and its supporting infrastructure could run together on a local Kubernetes cluster.",
                        "I created and deployed a sample API and validated that services inside the cluster could communicate with databases, Kafka, MQTT, and monitoring components. The PoC became a starting point for the DevOps team."
                    ],
                    Points:
                    [
                        "Ran Kubernetes locally using Docker Desktop and Minikube.",
                        "Containerized and deployed sample application services and other components like PostgreSQL, Kafka, Mosquitto, Prometheus, and Grafana.",
                        "Established the initial local development and deployment model."
                    ]
                ),
                new(
                    Title: "Monitoring and observability",
                    Paragraphs:
                    [
                        "Prometheus and Grafana were used to collect and visualize platform metrics.",
                        "Because some application information was written as unstructured log entries, Grok Exporter was introduced to parse those logs, convert meaningful values into metrics, and expose them to Prometheus for visualization in Grafana."
                    ],
                    Points:
                    [
                        "Prometheus for metrics collection.",
                        "Grafana for dashboards and visualization.",
                        "Grok Exporter for converting structured information from log files into metrics."
                    ]
                )
            ],
            Highlights:
            [
                "Led the Device Registration module",
                "Mentored two developers",
                "Created the project's initial Kubernetes foundation",
                "Worked across IoT, backend, messaging, DevOps, and observability"
            ],
            Tech:
            [
                "C#",
                ".NET",
                "ASP.NET Core",
                "WPF",
                "REST APIs",
                "Microservices",
                "Kafka",
                "MQTT",
                "Mosquitto",
                "PostgreSQL",
                "Docker",
                "Kubernetes",
                "Prometheus",
                "Grafana",
                "Grok Exporter"
            ],
            IsFeatured: true
        ),

        new(
            Company: "CoreView Systems",
            CompanyUrl: "https://coreviewsystems.com",
            Role: "Senior Software Engineer",
            Duration: "Sep 2021 — Nov 2021",
            Location: "Pune, India",
            ProjectTitle: "Electricity Customer Management System",
            Overview:
                "Worked briefly on an enterprise electricity customer-management application supporting " +
                "customer records, billing, meter-reading processing, synchronization, and service operations.",
            KeyContributions:
            [
                "Developed WPF user interfaces using the MVVM architectural pattern.",
                "Implemented background services for billing, meter-reading processing, and data synchronization.",
                "Developed and integrated REST APIs for customer information, billing updates, and service requests."
            ],
            DetailSections: [],
            Highlights: [],
            Tech:
            [
                "C#",
                ".NET",
                "WPF",
                "MVVM",
                "SQL Server",
                "REST APIs"
            ],
            IsFeatured: false
        ),

        new(
            Company: "S&P Global",
            CompanyUrl: "https://www.spglobal.com/market-intelligence",
            Role: "Senior Software Developer",
            Duration: "Mar 2017 — Sep 2021",
            Location: "Gurgaon, India",
            ProjectTitle: "CTS, Transaction Data Pipeline and Ratio Dissection Engine",
            Overview:
                "I worked on enterprise applications supporting S&P Global's Mergers & Acquisitions business. " +
                "The systems captured detailed transaction data, synchronized information across platforms, " +
                "and calculated financial data consumed by downstream S&P Global products.",
            KeyContributions:
            [
                "Developed multiple tools in Content Tool Suite, a WPF desktop application used by analysts to capture detailed M&A transaction data.",
                "Worked on the development of Ratio Dissection Engine for visualizing financial calculation dependencies as interactive trees.",
                "Developed event-driven backend services for near-real-time financial calculations.",
                "Worked on Kafka-based transaction pipeline for synchronizing data between S&P Global and SNL systems.",
                "Migrated REST APIs from .NET Framework to .NET Core."
            ],
            DetailSections:
            [
                new(
                    Title: "Content Tool Suite",
                    Paragraphs:
                    [
                        "CTS was a WPF desktop application used internally by financial analysts to capture complex Mergers & Acquisitions transaction data.",
                        "A single transaction could contain deeply structured financial information, including data items whose values depended on multiple underlying calculations. The data captured through CTS served as a primary source for downstream S&P Global products."
                    ],
                    Points:
                    [
                        "WPF and MVVM-based desktop development.",
                        "Complex financial data-entry workflows.",
                        "Business validation and calculation logic.",
                        "REST API and database integration.",
                        "Production support for business-critical analyst workflows."
                    ]
                ),
                new(
                    Title: "Transaction Data Pipeline",
                    Paragraphs:
                    [
                        "Following S&P Global's acquisition of SNL, M&A data needed to be moved from the existing S&P content system into SNL's data model while analysts continued using the original application.",
                        "The pipeline used two primary Windows Services: a transformer and a persister. Transaction data was published through Kafka, transformed into reusable C# domain models distributed through NuGet packages, published again, and then persisted into the target database model."
                    ],
                    Points:
                    [
                        "Kafka-based publish-subscribe processing.",
                        "Windows Services for transformation and persistence.",
                        "Continuous synchronization while the source system remained active.",
                        "Backfill processing through SQL-based jobs for historical data."
                    ]
                ),
                new(
                    Title: "Ratio Dissection and calculation engine",
                    Paragraphs:
                    [
                        "Financial data items often depended on other calculated data items, producing multi-level dependency trees.",
                        "The Ratio Dissection interface allowed users to search for a data item and navigate its complete calculation hierarchy, including the formulas and values associated with each dependency.",
                        "For near-real-time recalculation, Attunity captured SQL Server changes and published them through Kafka. Multiple instances of our consumer services processed partitioned events, performed the required calculations, and stored the updated results."
                    ],
                    Points:
                    [
                        "Near-real-time Change Data Capture processing.",
                        "Attunity CDC integration through Kafka.",
                        "Multiple Kafka consumers and partitions for parallel processing.",
                        "Calculation and persistence of thousands of financial data items."
                    ]
                ),
                new(
                    Title: "Platform modernization",
                    Paragraphs:
                    [
                        "Alongside product development, I helped modernize the backend platform by migrating REST APIs from .NET Framework to .NET Core."
                    ],
                    Points:
                    []
                )
            ],
            Highlights:
            [
                "Enterprise M&A platform used by financial analysts",
                "Kafka-based cross-platform data synchronization",
                "Near-real-time financial calculation processing",
                "Post-acquisition integration between S&P Global and SNL",
                ".NET modernization and CI/CD adoption"
            ],
            Tech:
            [
                "C#",
                ".NET Framework",
                ".NET Core",
                "WPF",
                "MVVM",
                "ASP.NET Web API",
                "SQL Server",
                "Kafka",
                "Windows Services",
                "Attunity CDC",
                "NuGet",
                "Azure DevOps",
                "Git"
            ],
            IsFeatured: true
        ),

        new(
            Company: "Capgemini",
            CompanyUrl: "https://www.capgemini.com",
            Role: "Software Developer",
            Duration: "Aug 2014 — Mar 2017",
            Location: "Noida, India",
            ProjectTitle: "NFOS — RSA Insurance Group",
            Overview:
                "Started my software development career working on a WPF-based insurance application " +
                "used to create and manage motor, home, and other insurance policies.",
            KeyContributions:
            [
                "Developed and enhanced WPF screens using MVVM for insurance-policy creation and management.",
                "Implemented business logic and integrated WCF services supporting backend policy operations.",
                "Worked with SQL Server and supported requirement analysis, estimation, testing, and production issue resolution."
            ],
            DetailSections: [],
            Highlights: [],
            Tech:
            [
                "C#",
                ".NET Framework",
                "WPF",
                "MVVM",
                "WCF",
                "SQL Server"
            ],
            IsFeatured: false
        )
    ];

    public IReadOnlyList<SideProjectEntry> SideProjects { get; } =
    [
        new(
            FileName: "ritash-portfolio",
            Title: "Developer Portfolio",
            Description:
                "An ASP.NET Core Razor Pages portfolio designed as a developer workspace, " +
                "with a resume viewer, experience timeline, project showcase, theme switching and responsive UI.",
            Tags:
            [
                "ASP.NET Core",
                "Razor Pages",
                "C#",
                "CSS"
            ],
            Link: "https://github.com/ritashkoul/ritash-portfolio"
        ),

        new(
            FileName: "DeskRAG",
            Title: "DeskRAG",
            Description:
                "A Windows desktop application for indexing personal documents and performing " +
                "semantic search and retrieval-augmented question answering using local language models.",
            Tags:
            [
                ".NET",
                "WPF",
                "MVVM",
                "AI",
                "Semantic Search",
                "RAG",
                "Ollama"
            ],
            Link: "https://github.com/ritashkoul/DeskRAG-releases"
        )
    ];
}

public record ExperienceEntry(
    string Company,
    string CompanyUrl,
    string Role,
    string Duration,
    string Location,
    string ProjectTitle,
    string Overview,
    string[] KeyContributions,
    ExperienceDetailSection[] DetailSections,
    string[] Highlights,
    string[] Tech,
    bool IsFeatured);

public record ExperienceDetailSection(
    string Title,
    string[] Paragraphs,
    string[] Points);

public record SideProjectEntry(
    string FileName,
    string Title,
    string Description,
    string[] Tags,
    string? Link);
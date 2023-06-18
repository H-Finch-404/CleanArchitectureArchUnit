using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo($"{nameof(CleanArchitectureArchUnit)}.Bootstrap")]
[assembly:InternalsVisibleTo($"{nameof(CleanArchitectureArchUnit)}.FunctionalTests")]
[assembly:InternalsVisibleTo($"{nameof(CleanArchitectureArchUnit)}.IntegrationTests")]
[assembly:InternalsVisibleTo($"{nameof(CleanArchitectureArchUnit)}.ArchitectureTests")]
// [assembly:InternalsVisibleTo($"{nameof(CleanArchitectureArchUnit)}.Web")]

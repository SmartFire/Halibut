using System;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Reflection;

namespace Halibut.Tests
{
    public class Certificates
    {
        public static X509Certificate2 TentacleListening;
        public static string TentacleListeningPublicThumbprint;
        public static X509Certificate2 Octopus;
        public static string OctopusPublicThumbprint;
        public static X509Certificate2 TentaclePolling;
        public static string TentaclePollingPublicThumbprint;

        static Certificates()
        {
            //jump through hoops to find certs because the nunit test runner is messing with directories
#if NET40
                var directory = Path.Combine(Path.GetDirectoryName(new Uri(typeof(Certificates).Assembly.CodeBase).LocalPath), "Certificates");
#else
                var directory = Path.Combine(Path.GetDirectoryName(new Uri(typeof(Certificates).GetTypeInfo().Assembly.CodeBase).LocalPath), "Certificates");
#endif
            TentacleListening = new X509Certificate2(Path.Combine(directory, "TentacleListening.pfx"));
            TentacleListeningPublicThumbprint = TentacleListening.Thumbprint;
            Octopus = new X509Certificate2(Path.Combine(directory, "Octopus.pfx"));
            OctopusPublicThumbprint = Octopus.Thumbprint;
            TentaclePolling = new X509Certificate2(Path.Combine(directory, "TentaclePolling.pfx"));
            TentaclePollingPublicThumbprint = TentaclePolling.Thumbprint;
        }
    }
}
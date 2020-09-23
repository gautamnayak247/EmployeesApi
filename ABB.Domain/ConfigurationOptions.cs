namespace ABB.Domain
{
    public class ConfigurationOptions : IConfigurationOptions
    {
        public Auth0 Auth0 { get; set; }
        public string SQLConnectionString { get; set; }
    }
}

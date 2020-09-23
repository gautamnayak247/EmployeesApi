namespace ABB.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IConfigurationOptions
    {
        Auth0 Auth0 { get; set; }
        string SQLConnectionString { get; set; }
    }
    public class Auth0
    {
        public string Domain { get; set; }
        public string ApiIdentifier { get; set; }
    }
}

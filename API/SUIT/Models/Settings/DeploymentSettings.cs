using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUIT.Models.Settings
{
    public class DeploymentSettings : IDeploymentSettings
    {
        public string[] CORS { get; set; }
    }

    public interface IDeploymentSettings
    {
        string[] CORS { get; set; }
    }
}
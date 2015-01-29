using FBDConfigurator.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FBDConfigurator.Helpers
{
  public class NpgsqlModelContextFactory : IModelContextFactory
    {
      public IModelContext Create(string connectionString)
      {
          var entityConnection = new EntityConnection(
                  new MetadataWorkspace(
                      new[] { "res://*/" },
                      new[] { Assembly.GetAssembly(typeof(PHmiModelContext)) }),
                      new NpgsqlConnection(connectionString));
          var context = new PHmiModelContext(entityConnection);
          context.StartTrackingChanges();
          return context;
      }
    }
}

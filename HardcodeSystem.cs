using System;
using System.Collections.Generic;
using EPiServer.Forms.Core.Internal.ExternalSystem;

namespace test.epi.forms
{
    public class HardcodeSystem : IExternalSystem
    {
        public virtual string Id
        {
            get { return "HardcodeSystem"; }
        }

        public virtual IEnumerable<IDatasource> Datasources
        {
            get
            {
                throw new Exception(); //First insert a published form with the data source and publish page
                var ds1 = new Datasource
                {
                    Id = "HardcodeSystemDS",
                    Name = "Hardcode System Datasource",
                    OwnerSystem = this,
                    Columns = new Dictionary<string, string>
                    {
                        { "firstname", "First Name" },
                        { "lastname", "Last Name" },
                        { "email", "Email" },
                    }
                };

                return new[] { ds1 };
            }
        }
    }
}
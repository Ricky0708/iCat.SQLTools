using iCat.SQLTools.enums;
using iCat.SQLTools.Repositories.Interfaces;
using iCat.SQLTools.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Services.Implements
{
    public class SchemaService : ISchemaService
    {
        public string Category => _category;
        private string _category;
        private readonly ISchemaRepository _repository;
        private static DataSet? _ds;
        public SchemaService(
            ConnectionType connectionType,
            IServiceProvider provider
            )
        {
            _category = connectionType.ToString();
            _repository = provider.CreateScope()
                .ServiceProvider
                .GetRequiredService<IEnumerable<ISchemaRepository>>()
                .First(p => p.Category == connectionType.ToString()) ?? throw new ArgumentNullException(nameof(ISchemaRepository));
        }

    }
}

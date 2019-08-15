namespace Npgsql.Jsonb
{
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
    using Microsoft.Extensions.DependencyInjection;

    /// <inheritdoc />
    /// <summary>
    ///     Расширение для работы с JsonB.
    /// </summary>
    public class JsonbOptionsExtension : IDbContextOptionsExtension
    {
        public bool ApplyServices(IServiceCollection services)
        {
            // Подключаем плагин для трансляции методов.
            new EntityFrameworkRelationalServicesBuilder(services).TryAddProviderSpecificServices(m =>
                m.TryAddSingletonEnumerable<IMethodCallTranslatorPlugin, JsonValueAccessorTranslatorPlugin>());
            return false;
        }

        public long GetServiceProviderHashCode()
        {
            return 0;
        }

        public string LogFragment => "using JsonbExtension";

        public void Validate(IDbContextOptions options)
        {
        }
    }
}
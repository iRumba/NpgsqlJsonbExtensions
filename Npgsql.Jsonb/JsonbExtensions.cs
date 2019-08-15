namespace Npgsql.Jsonb
{
    using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

    using Microsoft.EntityFrameworkCore.Infrastructure;

    /// <summary>
    ///     Методы расширения для работы с JsonB в Npgsql.
    /// </summary>
    public static class JsonbExtensions
    {
        public static NpgsqlDbContextOptionsBuilder UseJsonb(this NpgsqlDbContextOptionsBuilder builder)
        {
            // Преобразование нужно, так как в RelationalDbContextOptionsBuilder<TBuilder, TExtension>
            // свойство интерфейса IRelationalDbContextOptionsBuilderInfrastructure.OptionsBuilder
            // реализовано явно и не является public
            var optionsBuilder = ((IRelationalDbContextOptionsBuilderInfrastructure) builder).OptionsBuilder;

            // Подключаем свое расширение.
            // Преобразование нужно, так как в DbContextOptionsBuilder метод
            // IDbContextOptionsBuilderInfrastructure.AddOrUpdateExtension(...) реализован явно и не является public
            ((IDbContextOptionsBuilderInfrastructure) optionsBuilder).AddOrUpdateExtension(new JsonbOptionsExtension());

            return builder;
        }
    }
}
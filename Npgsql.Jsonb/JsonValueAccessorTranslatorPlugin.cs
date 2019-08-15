namespace Npgsql.Jsonb
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;

    /// <inheritdoc />
    /// <summary>
    ///     Плагин для подключения трансляторов методов работы с JsonB полями.
    /// </summary>
    public class JsonValueAccessorTranslatorPlugin : IMethodCallTranslatorPlugin
    {
        public IEnumerable<IMethodCallTranslator> Translators
        {
            get { yield return new JsonValueAccessorTranslator(); }
        }
    }
}
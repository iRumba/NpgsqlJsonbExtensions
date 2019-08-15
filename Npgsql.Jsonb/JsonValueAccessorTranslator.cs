namespace Npgsql.Jsonb
{
    using System.Linq.Expressions;
    using System.Reflection;

    using Microsoft.EntityFrameworkCore.Query.Expressions;
    using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;

    /// <inheritdoc />
    /// <summary>
    ///     Транслятор для метода доступа к полю внутри Jsonb.
    /// </summary>
    public class JsonValueAccessorTranslator : IMethodCallTranslator
    {
        /// <summary>
        ///     Метод доступа к свойству внутри поля Jsonb.
        /// </summary>
        private static readonly MethodInfo Method = typeof(JsonbMethods)
            .GetMethod(nameof(JsonbMethods.Value));

        public Expression Translate(MethodCallExpression methodCallExpression)
        {
            if (!methodCallExpression.Method.IsGenericMethod)
                return null;

            if (methodCallExpression.Method.GetGenericMethodDefinition() != Method)
                return null;

            var genericType = methodCallExpression.Method.GetGenericArguments()[0];

            var col = methodCallExpression.Arguments[0] as ColumnExpression;
            var con = methodCallExpression.Arguments[1] as ConstantExpression;

            return new ExplicitCastExpression(new JsonbPropertyAccessorExpression(col, con), genericType);
        }
    }
}
namespace Npgsql.Jsonb
{
    using System;
    using System.Linq.Expressions;

    using Microsoft.EntityFrameworkCore.Query.Expressions;
    using Microsoft.EntityFrameworkCore.Query.Sql;

    /// <inheritdoc />
    /// <summary>
    ///     Выражение для доступа к свойствам внутри поля Jsonb.
    /// </summary>
    public class JsonbPropertyAccessorExpression : Expression
    {
        public JsonbPropertyAccessorExpression(ColumnExpression columnExpression, ConstantExpression jsonField)
        {
            ColumnExpression = columnExpression;
            JsonField = jsonField;
        }

        public ColumnExpression ColumnExpression { get; }
        public ConstantExpression JsonField { get; }

        public override ExpressionType NodeType => ExpressionType.Extension;

        public override Type Type => ColumnExpression.Type;

        protected override Expression Accept(ExpressionVisitor visitor)
        {
            if (visitor is ISqlExpressionVisitor expressionVisitor)
            {
                expressionVisitor.VisitColumn(ColumnExpression);
                expressionVisitor.VisitSqlFragment(new SqlFragmentExpression($"->>'{JsonField.Value}'"));
            }
            else
            {
                base.Accept(visitor);
            }

            return this;
        }
    }
}
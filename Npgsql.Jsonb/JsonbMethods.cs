namespace Npgsql.Jsonb
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Класс со свойствами для трансляции при работе с Jsonb полями.
    /// </summary>
    public static class JsonbMethods
    {
        /// <summary>
        ///     Доступ к свойству внутри поля Jsonb.
        /// </summary>
        /// <typeparam name="TSource">Тип значения поля Json. </typeparam>
        /// <param name="jsonbProperty">Поле, имеющее тип Jsonb. </param>
        /// <param name="jsonbPropertyName">Свойство объекта Jsonb, к которому нужен доступ. </param>
        /// <returns>Доступ к значению поля. </returns>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        public static TSource Value<TSource>(object jsonbProperty, string jsonbPropertyName)
        {
            throw new NotSupportedException();
        }
    }
}
# NpgsqlJsonbExtensions

## Including

```csharp
dbContextOptionsBuilder.UseNpdsql(connectionString, o => o.UseJsonb())
```

## Usage

```csharp
context.MyEntityWithJsonbField
	.Where(x => JsonbMethods.Value<string>(x.JsonbField, "jsonPropertyName") == "someValue")
	.OrderBy(x => JsonbMethods.Value<int>(x.JsonbField, "otherJsonPropertyName"))
	.Select(x => JsonbMethods.Value<int>(x.JsonbField, "thirdJsonPropertyName")).ToList();
```

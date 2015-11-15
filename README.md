# Folke.Localization.Json

This is an implementation of IStringLocalizer from ASP.NET 5 that uses Json files.

Initialize it in you `Startup` `ConfigureServices` method:

```csharp
services.AddJsonLocalization();

services.Configure<JsonStringLocalizerOptions>(options =>
{
	options.ResourceFilesDirectory = "res"; // The directory that contains the resources
	options.DefaultBaseName = "text"; // The default sub-directory name
});
```

For a `Sample.Type` type and the culture `ab-CD`, the service will look for a JSON file
in the following order:
- `{ResourceFilesDirectory}/{Sample.Type}/{ab-CD}.json`
- `{ResourceFilesDirectory}/{Sample.Type}/default.json`
- `{ResourceFilesDirectory}/{DefaultBaseName}/{ab-CD}.json`
- `{ResourceFilesDirectory}/{DefaultBaseName}/default.json`

The JSON file maybe a tree a string values. The values are accessed using the `:` separator.
For example for the file:

```json
{
	"first": {
		"second": "value"
	},
	"third": "other value"
}
```

The key `first:second` would return `value` and the key `third` would return `other value`.
Any other key would result in an error.
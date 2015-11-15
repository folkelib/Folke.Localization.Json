using System;
using Microsoft.Framework.Localization;
using Microsoft.Framework.OptionsModel;

namespace Folke.Localization.Json
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly JsonStringLocalizerOptions options;

        public JsonStringLocalizerFactory(IOptions<JsonStringLocalizerOptions> options)
        {
            this.options = options.Value;
        }

        /// <summary>
        /// Creates an <see cref="T:Microsoft.Framework.Localization.IStringLocalizer"/> using the <see cref="T:System.Reflection.Assembly"/> and
        ///             <see cref="P:System.Type.FullName"/> of the specified <see cref="T:System.Type"/>.
        /// </summary>
        /// <param name="resourceSource">The <see cref="T:System.Type"/>.</param>
        /// <returns>
        /// The <see cref="T:Microsoft.Framework.Localization.IStringLocalizer"/>.
        /// </returns>
        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer(options.ResourceFilesDirectory, resourceSource.FullName, options.DefaultBaseName, null);
        }

        /// <summary>
        /// Creates an <see cref="T:Microsoft.Framework.Localization.IStringLocalizer"/>.
        /// </summary>
        /// <param name="baseName">The base name of the resource to load strings from.</param><param name="location">The location to load resources from.</param>
        /// <returns>
        /// The <see cref="T:Microsoft.Framework.Localization.IStringLocalizer"/>.
        /// </returns>
        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer(location ?? options.ResourceFilesDirectory, baseName, options.DefaultBaseName, null);
        }
    }

    public class JsonStringLocalizerOptions
    {
        /// <summary>
        /// Where the resource files are stored
        /// </summary>
        public string ResourceFilesDirectory { get; set; }
        /// <summary>
        /// If the json file for the type is not found, use this name
        /// </summary>
        public string DefaultBaseName { get; set; }
    }
}

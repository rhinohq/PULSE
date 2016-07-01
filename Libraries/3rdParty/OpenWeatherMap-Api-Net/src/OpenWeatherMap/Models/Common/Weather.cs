
namespace OpenWeatherMap
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Weather.
    /// </summary>
    public sealed class Weather
    {
        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        [XmlAttribute("number")]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        [XmlAttribute("value")]
        public string Value { get; set; }

        /// <summary>
        ///     Gets or sets the icon filename without extension.
        /// </summary>
        /// <value>
        ///     The icon.
        /// </value>
        [XmlAttribute("icon")]
        public string Icon { get; set; }
    }
}

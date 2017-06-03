using Net.Chdk.Detectors.Software.Binary;
using Net.Chdk.Providers.Software;
using System;
using System.Globalization;

namespace Net.Chdk.Detectors.Software.Fhp
{
    sealed class FhpSoftwareDetector : ProductBinarySoftwareDetector
    {
        private const string CameraPlatform = "400D";
        private const string CameraRevision = "111";

        public FhpSoftwareDetector(ISourceProvider sourceProvider)
            : base(sourceProvider)
        {
        }

        public override string CategoryName => "EOS";
        public override string ProductName => "400plus";

        protected override string String => "VER-";

        protected override int StringCount => 2;

        protected override Version GetProductVersion(string[] strings)
        {
            if (!"%u".Equals(strings[1], StringComparison.InvariantCulture))
                return null;

            var split = strings[0].Split('-');
            if (split.Length != 2)
                return null;

            DateTime date;
            if (!DateTime.TryParseExact(split[0], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out date))
                return null;

            if ("BETA".Equals(split[1], StringComparison.InvariantCulture))
                return new Version(date.Year, date.Month, date.Day);

            int revision;
            if (!int.TryParse(split[1], out revision))
                return null;
            return new Version(date.Year, date.Month, date.Day, revision);
        }

        protected override CultureInfo GetLanguage(string[] strings)
        {
            return CultureInfo.GetCultureInfo("en");
        }

        protected override string GetPlatform(string[] strings)
        {
            return CameraPlatform;
        }

        protected override string GetRevision(string[] strings)
        {
            return CameraRevision;
        }
    }
}

using Net.Chdk.Detectors.Software.Product;
using Net.Chdk.Providers.Boot;
using System;
using System.Globalization;

namespace Net.Chdk.Detectors.Software.Fhp
{
    sealed class FhpProductDetector : ProductDetector
    {
        public FhpProductDetector(IBootProviderResolver bootProviderResolver)
            : base(bootProviderResolver)
        {
        }

        public override string CategoryName => "EOS";
        protected override string ProductName => "400plus";

        protected override Version GetVersion(string rootPath)
        {
            return null;
        }

        protected override CultureInfo GetLanguage(string rootPath)
        {
            return CultureInfo.GetCultureInfo("en");
        }
    }
}

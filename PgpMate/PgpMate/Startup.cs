﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using PgpMate.Data;
using PgpCore;
using Org.BouncyCastle.Bcpg.OpenPgp;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace PgpMate
{
    public class EncryptionKeyPrivate : IEncryptionKeys
    {
        private readonly string _privateKey;

        public EncryptionKeyPrivate(string privateKey)
        {
            _privateKey = privateKey;
        }
        public PgpPublicKey PublicKey => null;

        public IEnumerable<PgpPublicKey> PublicKeys => throw new NotImplementedException();

        public PgpPrivateKey PrivateKey => throw new NotImplementedException();

        public PgpSecretKey SecretKey => throw new NotImplementedException();

        public PgpSecretKeyRingBundle SecretKeys => throw new NotImplementedException();

        public PgpPrivateKey FindSecretKey(long keyId)
        {
            throw new NotImplementedException();
        }
    }
    public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.RegisterBlazorMauiWebView()
				.UseMicrosoftExtensionsServiceProviderFactory()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				})
				.ConfigureServices(services =>
				{
					services.AddBlazorWebView();
					services.AddSingleton<WeatherForecastService>();
				});
		}
	}
}
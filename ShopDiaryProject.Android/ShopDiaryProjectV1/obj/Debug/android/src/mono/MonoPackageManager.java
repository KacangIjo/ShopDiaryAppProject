package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (context instanceof android.app.Application) {
				Context = context;
			}
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);
				
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	public static void setContext (Context context)
	{
		// Ignore; vestigial
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "ShopDiaryProjectV1.dll" comes first in this list. */
		"ShopDiaryProjectV1.dll",
		"Newtonsoft.Json.dll",
		"System.Configuration.dll",
		"Xamarin.Android.Support.Animated.Vector.Drawable.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.RecyclerView.dll",
		"Xamarin.Android.Support.Vector.Drawable.dll",
		"Xamarin.GooglePlayServices.Base.dll",
		"Xamarin.GooglePlayServices.Basement.dll",
		"Xamarin.GooglePlayServices.Vision.dll",
		"ZXing.Net.Mobile.Core.dll",
		"zxing.portable.dll",
		"ZXingNetMobile.dll",
		"ShopDiaryApp.API.dll",
		"ShopDiaryProject.Domain.dll",
		"Microsoft.Owin.dll",
		"Owin.dll",
		"System.Web.Optimization.dll",
		"System.Web.dll",
		"System.Drawing.dll",
		"System.DirectoryServices.dll",
		"System.Web.RegularExpressions.dll",
		"System.Design.dll",
		"System.Windows.Forms.dll",
		"Accessibility.dll",
		"System.Deployment.dll",
		"System.Runtime.Serialization.Formatters.Soap.dll",
		"System.Data.OracleClient.dll",
		"System.Drawing.Design.dll",
		"System.Web.ApplicationServices.dll",
		"System.DirectoryServices.Protocols.dll",
		"System.ServiceProcess.dll",
		"System.Configuration.Install.dll",
		"Microsoft.Build.Utilities.v4.0.dll",
		"Microsoft.Build.Framework.dll",
		"System.Xaml.dll",
		"Microsoft.Build.Tasks.v4.0.dll",
		"System.Runtime.Caching.dll",
		"WebGrease.dll",
		"Antlr3.Runtime.dll",
		"Microsoft.Web.Infrastructure.dll",
		"System.Web.Mvc.dll",
		"System.Web.Razor.dll",
		"System.Web.WebPages.Razor.dll",
		"System.Web.WebPages.dll",
		"System.Data.Linq.dll",
		"System.Web.WebPages.Deployment.dll",
		"System.Web.Extensions.dll",
		"System.Data.Services.Design.dll",
		"System.Data.Entity.dll",
		"System.ServiceModel.Activation.dll",
		"System.ServiceModel.Activities.dll",
		"System.Activities.dll",
		"Microsoft.VisualBasic.Activities.Compiler.dll",
		"Microsoft.VisualBasic.dll",
		"System.Management.dll",
		"Microsoft.JScript.dll",
		"System.Runtime.Remoting.dll",
		"System.Runtime.DurableInstancing.dll",
		"System.Activities.DurableInstancing.dll",
		"System.Xaml.Hosting.dll",
		"SMDiagnostics.dll",
		"Microsoft.AspNet.Identity.Core.dll",
		"Microsoft.AspNet.Identity.Owin.dll",
		"Microsoft.Owin.Security.OAuth.dll",
		"Microsoft.Owin.Security.dll",
		"Microsoft.Owin.Security.Cookies.dll",
		"System.Web.Http.dll",
		"System.Net.Http.Formatting.dll",
		"System.Web.Http.Owin.dll",
		"Microsoft.AspNet.Identity.EntityFramework.dll",
		"EntityFramework.dll",
		"ShopDiaryProject.Repository.dll",
		"ShopDiaryProject.EF.dll",
		"System.Web.Http.WebHost.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_25";
}

package md5d06ba3291c07b39e0ba8c1cee19894e9;


public class StorageViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ShopDiaryProjectV1.StorageViewHolder, ShopDiaryProjectV1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", StorageViewHolder.class, __md_methods);
	}


	public StorageViewHolder () throws java.lang.Throwable
	{
		super ();
		if (getClass () == StorageViewHolder.class)
			mono.android.TypeManager.Activate ("ShopDiaryProjectV1.StorageViewHolder, ShopDiaryProjectV1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

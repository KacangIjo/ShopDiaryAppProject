package md5d42ad163a63e50fddfa0b88e085f80dd;


public class CategoryRecyclerAdapter_ViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ShopDiaryProjectV1.Adapter.CategoryRecyclerAdapter+ViewHolder, ShopDiaryProjectV1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CategoryRecyclerAdapter_ViewHolder.class, __md_methods);
	}


	public CategoryRecyclerAdapter_ViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CategoryRecyclerAdapter_ViewHolder.class)
			mono.android.TypeManager.Activate ("ShopDiaryProjectV1.Adapter.CategoryRecyclerAdapter+ViewHolder, ShopDiaryProjectV1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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

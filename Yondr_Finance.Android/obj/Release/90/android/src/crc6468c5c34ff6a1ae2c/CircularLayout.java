package crc6468c5c34ff6a1ae2c;


public class CircularLayout
	extends android.widget.AbsoluteLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Syncfusion.Android.ProgressBar.CircularLayout, Syncfusion.SfProgressBar.XForms.Android", CircularLayout.class, __md_methods);
	}


	public CircularLayout (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CircularLayout.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.CircularLayout, Syncfusion.SfProgressBar.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CircularLayout (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CircularLayout.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.CircularLayout, Syncfusion.SfProgressBar.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CircularLayout (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CircularLayout.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.CircularLayout, Syncfusion.SfProgressBar.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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

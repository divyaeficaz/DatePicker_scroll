package crc64c4292a9f15cebec1;


public class MyRenderer
	extends crc643f46942d9dd1fff9.RadioButtonRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Yondr_Finance.Droid.MyRenderer, Yondr_Finance.Android", MyRenderer.class, __md_methods);
	}


	public MyRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MyRenderer.class)
			mono.android.TypeManager.Activate ("Yondr_Finance.Droid.MyRenderer, Yondr_Finance.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public MyRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MyRenderer.class)
			mono.android.TypeManager.Activate ("Yondr_Finance.Droid.MyRenderer, Yondr_Finance.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MyRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MyRenderer.class)
			mono.android.TypeManager.Activate ("Yondr_Finance.Droid.MyRenderer, Yondr_Finance.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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

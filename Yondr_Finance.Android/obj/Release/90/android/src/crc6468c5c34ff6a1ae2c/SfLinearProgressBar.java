package crc6468c5c34ff6a1ae2c;


public class SfLinearProgressBar
	extends crc6468c5c34ff6a1ae2c.ProgressBarBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"n_onSizeChanged:(IIII)V:GetOnSizeChanged_IIIIHandler\n" +
			"n_onFinishInflate:()V:GetOnFinishInflateHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.Android.ProgressBar.SfLinearProgressBar, Syncfusion.SfProgressBar.XForms.Android", SfLinearProgressBar.class, __md_methods);
	}


	public SfLinearProgressBar (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SfLinearProgressBar.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.SfLinearProgressBar, Syncfusion.SfProgressBar.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SfLinearProgressBar (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SfLinearProgressBar.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.SfLinearProgressBar, Syncfusion.SfProgressBar.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SfLinearProgressBar (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SfLinearProgressBar.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.SfLinearProgressBar, Syncfusion.SfProgressBar.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SfLinearProgressBar (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SfLinearProgressBar.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.SfLinearProgressBar, Syncfusion.SfProgressBar.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);


	public void onSizeChanged (int p0, int p1, int p2, int p3)
	{
		n_onSizeChanged (p0, p1, p2, p3);
	}

	private native void n_onSizeChanged (int p0, int p1, int p2, int p3);


	public void onFinishInflate ()
	{
		n_onFinishInflate ();
	}

	private native void n_onFinishInflate ();

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

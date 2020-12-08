package crc6468c5c34ff6a1ae2c;


public class GradientShaderFactory
	extends android.graphics.drawable.ShapeDrawable.ShaderFactory
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_resize:(II)Landroid/graphics/Shader;:GetResize_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.Android.ProgressBar.GradientShaderFactory, Syncfusion.SfProgressBar.XForms.Android", GradientShaderFactory.class, __md_methods);
	}


	public GradientShaderFactory ()
	{
		super ();
		if (getClass () == GradientShaderFactory.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.GradientShaderFactory, Syncfusion.SfProgressBar.XForms.Android", "", this, new java.lang.Object[] {  });
	}

	public GradientShaderFactory (int p0)
	{
		super ();
		if (getClass () == GradientShaderFactory.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.ProgressBar.GradientShaderFactory, Syncfusion.SfProgressBar.XForms.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public android.graphics.Shader resize (int p0, int p1)
	{
		return n_resize (p0, p1);
	}

	private native android.graphics.Shader n_resize (int p0, int p1);

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

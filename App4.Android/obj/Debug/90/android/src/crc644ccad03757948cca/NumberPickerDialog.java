package crc644ccad03757948cca;


public class NumberPickerDialog
	extends android.support.v4.app.DialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App4.Droid.NumberPickerDialog, App4.Android", NumberPickerDialog.class, __md_methods);
	}


	public NumberPickerDialog ()
	{
		super ();
		if (getClass () == NumberPickerDialog.class)
			mono.android.TypeManager.Activate ("App4.Droid.NumberPickerDialog, App4.Android", "", this, new java.lang.Object[] {  });
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

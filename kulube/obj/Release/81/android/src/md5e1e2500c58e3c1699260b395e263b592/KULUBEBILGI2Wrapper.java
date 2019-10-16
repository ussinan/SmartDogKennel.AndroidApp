package md5e1e2500c58e3c1699260b395e263b592;


public class KULUBEBILGI2Wrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("kulube.KULUBEBILGI2Wrapper, kulube", KULUBEBILGI2Wrapper.class, __md_methods);
	}


	public KULUBEBILGI2Wrapper ()
	{
		super ();
		if (getClass () == KULUBEBILGI2Wrapper.class)
			mono.android.TypeManager.Activate ("kulube.KULUBEBILGI2Wrapper, kulube", "", this, new java.lang.Object[] {  });
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

package crc64411566ff043543ac;


public class loginForm
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Registro_y_control_de_extintores_Movil.Activities.loginForm, Registro-y-control-de-extintores-Movil", loginForm.class, __md_methods);
	}


	public loginForm ()
	{
		super ();
		if (getClass () == loginForm.class)
			mono.android.TypeManager.Activate ("Registro_y_control_de_extintores_Movil.Activities.loginForm, Registro-y-control-de-extintores-Movil", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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

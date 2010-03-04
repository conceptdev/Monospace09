using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Monospace2
{
	/// <summary>
	/// Display sponsor logos and links
	/// </summary>
	/// <remarks>
	/// Uses UIWebView since we want to format the text display (with HTML)
	/// </remarks>
	public class SponsorsViewController : UIViewController
	{
		public UITextView textView;
		public UIWebView webView;
		private string basedir;
		
		public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
			// no XIB !
			webView = new UIWebView()
			{
				ScalesPageToFit = false
			};
			
			basedir = Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			basedir = basedir.Replace("Documents", "Monospace2.app");
			
			webView.LoadHtmlString(FormatText(), new NSUrl(basedir+"/Sponsors/", true));
			
			// Set the web view to fit the width of the app.
            webView.SizeToFit();

            // Reposition and resize the receiver
            webView.Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height-90);

            // Add the table view as a subview
            this.View.AddSubview(webView);
		}		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			
			try {
				basedir = Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
				basedir = basedir.Replace("Documents", "Monospace2.app");
				webView.LoadHtmlString(FormatText(), new NSUrl(basedir+"/Sponsors/", true));
			} catch (Exception ex) {Console.WriteLine(ex);}
		}
		/// <summary>
		/// Format the parts-of-speech text for UIWebView
		/// </summary>
		private string FormatText()
		{
			StringBuilder sb = new StringBuilder();
			
			var basedir = Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			basedir = basedir.Replace("Documents", "Monospace2.app");
			
			sb.Append("<style>body,b,i,p{font-family:Helvetica;}" +
				"i{color:#666666;}" +
				"#divider {background-color: #42a8c6; height:1px; margin-top: 10px;}" +
				"</style>");
			
			sb.Append("<center><i>title sponsor</i>");
			sb.Append("<p><a href='http://www.novell.com'><img src='novell_logo.jpg' /></a></p>");
			
			sb.Append("<div id='divider'>&nbsp;</div>");
			
			sb.Append("<p><i>principal sponsors</i>");
			sb.Append("<p><a href='http://www.headspringsystems.com'><img src='headspring_logo.gif' /></a></p>");
			sb.Append("<p><a href='http://www.thoughtworks.com'><img src='thoughtworks_logo.png' /></a></p>");
			
			sb.Append("<div id='divider'>&nbsp;</div>");
			
			sb.Append("<p><i>supporting sponsors</i>");
			sb.Append("<p><a href='http://www.telerik.com'><img src='telerik_logo.jpg' /></a></p>");
			sb.Append("<p><a href='http://www.opensuse.com'><img src='open_suse_logo.jpg' /></a></p>");
			sb.Append("<p><a href='http://www.ampgt.com'><img src='ampgt_text_logo.gif' /></a></p>");
			
			sb.Append("<div id='divider'>&nbsp;</div>");
			
			sb.Append("<p><i>in participation with</i>");
			sb.Append("<p><a href='http://www.codeplex.org'><img src='codeplex_foundation_logo.gif' /></a></p>");
			sb.Append("<p><a href='http://www.nhprof.com'><img src='nhibernate_profiler_logo.png' /></a></p>");
			sb.Append("<p><a href='http://www.innotechconference.com/austin'><img src='innotech_logo.jpg' /></a></p>");
			
			sb.Append("</center>");
			
			//sb.Append("<br/>"+basedir+""); 	// debugging the path
			return sb.ToString();
		}
	}

}



















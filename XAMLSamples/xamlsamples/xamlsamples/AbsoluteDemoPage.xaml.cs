using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlSamples
{
	public partial class AbsoluteDemoPage
	{
		public AbsoluteDemoPage ()
		{
			InitializeComponent ();
			myLayout.Children.Add (new BoxView { Color = Color.Green }, new Rectangle (0, 0, 0.3, 0.3), AbsoluteLayoutFlags.All);
		}

		void OnSliderValueChanged (object sender, 
		                           ValueChangedEventArgs args)
		{
			var x = args.NewValue;
			var sss = new AbsoluteLayout ();
			//this.myBox.Layout (new Xamarin.Forms.Rectangle (x, 0, 0.25, 0.25));
			
		}
	}
}

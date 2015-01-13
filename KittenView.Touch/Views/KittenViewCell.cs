using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using KittenView.Core.ViewModels;
using MonoTouch.CoreFoundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using KittenView.Core.Services;

namespace KittenView.Touch.Views
{
	[Register("KittenViewCell")]
	public class KittenViewCell : MvxTableViewCell
	{
		public UILabel label1;
		public UILabel label2;

		public KittenViewCell(IntPtr handle)
			: base(handle)
		{
			label1 = new UILabel(new RectangleF(10, 10, 150, 40));
			label1.Text = "Label 1";
			label1.HighlightedTextColor = label1.TextColor;
			this.Add(label1);
			label2 = new UILabel(new RectangleF(150, 10, 440, 40));
			label2.HighlightedTextColor = label2.TextColor;
			label2.Text = "Label 2";
			this.Add(label2);

			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<KittenViewCell, Kitten>();
				set.Bind(label1).To(kitten => kitten.Name);
				set.Bind(label2).To(kitten => kitten.Price);
				set.Apply();
			});
		}
	}
}

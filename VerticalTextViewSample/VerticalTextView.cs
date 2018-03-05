using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace VerticalTextViewSample
{
    public class VerticalTextView : Android.Support.V7.Widget.AppCompatTextView
    {
        private bool _isTopDown;
        public VerticalTextView(Context context) : base(context)
        {
            Initialize();
        }

        public VerticalTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        public VerticalTextView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize();
        }

        private void Initialize()
        {
            GravityFlags gravity = Gravity;
            if (Android.Views.Gravity.IsVertical(gravity) && (gravity & GravityFlags.VerticalGravityMask) == GravityFlags.Bottom)
            {
                Gravity = (gravity & GravityFlags.HorizontalGravityMask) | GravityFlags.Top;
                _isTopDown = false;
            }
            else
            {
                _isTopDown = true;
            }
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(heightMeasureSpec, widthMeasureSpec);
            SetMeasuredDimension(MeasuredHeight, MeasuredWidth);
        }

        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            if (_isTopDown)
            {
                canvas.Translate(Width, 0);
                canvas.Rotate(90);
            }
            else
            {
                canvas.Translate(0, Height);
                canvas.Rotate(-90);
            }

            canvas.Translate(CompoundPaddingLeft, ExtendedPaddingTop);

            Layout.Draw(canvas);
        }
    }
}
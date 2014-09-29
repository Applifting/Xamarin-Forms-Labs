using System;
using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;

namespace Xamarin.Forms.Labs.Droid.Controls
{
	public class SegmentedGroup : RadioGroup
	{
		private int oneDP;


		private Android.Graphics.Color _tintColor;
		public Android.Graphics.Color TintColor{
			set{
				_tintColor = value;
				UpdateBackground();
			}
			get{
				return _tintColor;
			}
		}

		public override void ChildDrawableStateChanged(Android.Views.View child)
		{
			base.ChildDrawableStateChanged(child);
			//((RadioButton)child).Text = ((RadioButton)child).Text;
		}

		private Android.Graphics.Color _checkedTextColor = Android.Graphics.Color.White;
		public Android.Graphics.Color CheckedTextColor{
			set{
				_checkedTextColor = value;
				UpdateBackground();
			}
			get{
				return _checkedTextColor;
			}
		}


		public SegmentedGroup(Context context) : base(context)
		{
			SharedConstructor();
		}

		public SegmentedGroup(Context context, IAttributeSet attrs):base(context,attrs){
			SharedConstructor();
		}

		private void SharedConstructor(){
			oneDP = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, 1, Context.Resources.DisplayMetrics);
			_tintColor = Android.Graphics.Color.ParseColor("#ff33b5e5");
		}




		public void UpdateBackground() {
			int count = base.ChildCount;
			if(count > 1){
				Android.Views.View child = GetChildAt(0);
				LayoutParams initParams = (LayoutParams)child.LayoutParameters;
				LayoutParams lParams = new LayoutParams(initParams.Width,initParams.Height,initParams.Weight);
				lParams.SetMargins(0, 0, -oneDP, 0);
				child.LayoutParameters = lParams;
				UpdateBackground(child, Resource.Drawable.radio_checked_left, Resource.Drawable.radio_unchecked_left);
				for(int i = 1; i< count - 1; i++){
					Android.Views.View  middleChild = GetChildAt(i);
					UpdateBackground(middleChild, Resource.Drawable.radio_checked_middle, Resource.Drawable.radio_unchecked_middle);
					initParams = (LayoutParams)middleChild.LayoutParameters;
					lParams = new LayoutParams(initParams.Width, initParams.Height, initParams.Weight);
					lParams.SetMargins(0, 0, -oneDP, 0);
					middleChild.LayoutParameters = lParams;
				}
				UpdateBackground(GetChildAt(count - 1), Resource.Drawable.radio_checked_right, Resource.Drawable.radio_unchecked_right);
			}else if(count == 1){
				UpdateBackground(GetChildAt(0), Resource.Drawable.radio_checked_default, Resource.Drawable.radio_unchecked_default);
			}
		
		}


		/*
		public void updateBackground() {
	        int count = super.getChildCount();
	        if (count > 1) {
	            View child = getChildAt(0);
	            LayoutParams initParams = (LayoutParams) child.getLayoutParams();
	            LayoutParams params = new LayoutParams(initParams.width, initParams.height, initParams.weight);
	            params.setMargins(0, 0, -oneDP, 0);
	            child.setLayoutParams(params);
	            updateBackground(getChildAt(0), R.drawable.radio_checked_left, R.drawable.radio_unchecked_left);
	            for (int i = 1; i < count - 1; i++) {
	                updateBackground(getChildAt(i), R.drawable.radio_checked_middle, R.drawable.radio_unchecked_middle);
	                View child2 = getChildAt(i);
	                initParams = (LayoutParams) child2.getLayoutParams();
	                params = new LayoutParams(initParams.width, initParams.height, initParams.weight);
	                params.setMargins(0, 0, -oneDP, 0);
	                child2.setLayoutParams(params);
	            }
	            updateBackground(getChildAt(count - 1), R.drawable.radio_checked_right, R.drawable.radio_unchecked_right);
	        } else if (count == 1) {
	            updateBackground(getChildAt(0), R.drawable.radio_checked_default, R.drawable.radio_unchecked_default);
	        }
	    }
		 * /
		*/



/*
		/*

package info.hoang8f.android.segmented;

import android.content.Context;
import android.content.res.ColorStateList;
import android.content.res.Resources;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.GradientDrawable;
import android.graphics.drawable.StateListDrawable;
import android.os.Build;
import android.util.AttributeSet;
import android.util.TypedValue;
import android.view.View;
import android.widget.Button;
import android.widget.RadioGroup;

public class SegmentedGroup extends RadioGroup {

    private int oneDP;
    private Resources resources;
    private int mTintColor;
    private int mCheckedTextColor = Color.WHITE;

    public SegmentedGroup(Context context) {
        super(context);
        resources = getResources();
        mTintColor = resources.getColor(R.color.radio_button_selected_color);
        oneDP = (int) TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, 1, resources.getDisplayMetrics());
    }

    public SegmentedGroup(Context context, AttributeSet attrs) {
        super(context, attrs);
        resources = getResources();
        mTintColor = resources.getColor(R.color.radio_button_selected_color);
        oneDP = (int) TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, 1, resources.getDisplayMetrics());
    }

    @Override
    protected void onFinishInflate() {
        super.onFinishInflate();
        //Use holo light for default
        updateBackground();
    }

    public void setTintColor(int tintColor) {
        mTintColor = tintColor;
        updateBackground();
    }

    public void setTintColor(int tintColor, int checkedTextColor) {
        mTintColor = tintColor;
        mCheckedTextColor = checkedTextColor;
        updateBackground();
    }

    public void updateBackground() {
        int count = super.getChildCount();
        if (count > 1) {
            View child = getChildAt(0);
            LayoutParams initParams = (LayoutParams) child.getLayoutParams();
            LayoutParams params = new LayoutParams(initParams.width, initParams.height, initParams.weight);
            params.setMargins(0, 0, -oneDP, 0);
            child.setLayoutParams(params);
            updateBackground(getChildAt(0), R.drawable.radio_checked_left, R.drawable.radio_unchecked_left);
            for (int i = 1; i < count - 1; i++) {
                updateBackground(getChildAt(i), R.drawable.radio_checked_middle, R.drawable.radio_unchecked_middle);
                View child2 = getChildAt(i);
                initParams = (LayoutParams) child2.getLayoutParams();
                params = new LayoutParams(initParams.width, initParams.height, initParams.weight);
                params.setMargins(0, 0, -oneDP, 0);
                child2.setLayoutParams(params);
            }
            updateBackground(getChildAt(count - 1), R.drawable.radio_checked_right, R.drawable.radio_unchecked_right);
        } else if (count == 1) {
            updateBackground(getChildAt(0), R.drawable.radio_checked_default, R.drawable.radio_unchecked_default);
        }
    }

    private void updateBackground(View view, int checked, int unchecked) {
        //Set text color
        ColorStateList colorStateList = new ColorStateList(new int[][]{
                {android.R.attr.state_pressed},
                {-android.R.attr.state_pressed, -android.R.attr.state_checked},
                {-android.R.attr.state_pressed, android.R.attr.state_checked}},
                new int[]{Color.GRAY, mTintColor, mCheckedTextColor});
        ((Button) view).setTextColor(colorStateList);

        //Redraw with tint color
        Drawable checkedDrawable = resources.getDrawable(checked).mutate();
        Drawable uncheckedDrawable = resources.getDrawable(unchecked).mutate();
        ((GradientDrawable) checkedDrawable).setColor(mTintColor);
        ((GradientDrawable) uncheckedDrawable).setStroke(oneDP, mTintColor);

        //Create drawable
        StateListDrawable stateListDrawable = new StateListDrawable();
        stateListDrawable.addState(new int[]{-android.R.attr.state_checked}, uncheckedDrawable);
        stateListDrawable.addState(new int[]{android.R.attr.state_checked}, checkedDrawable);

        //Set button background
        if (Build.VERSION.SDK_INT >= 16) {
            view.setBackground(stateListDrawable);
        } else {
            view.setBackgroundDrawable(stateListDrawable);
        }
    }

*/
		private void UpdateBackground(Android.Views.View view, int isCheckedResourceID, int uncheckedResourceID){
			//Set text colror
			var states = new int[][]
			{
				new int[]{ Android.Resource.Attribute.StatePressed },
				new int[]{ -Android.Resource.Attribute.StatePressed, -Android.Resource.Attribute.StateChecked },
				new int[]{ -Android.Resource.Attribute.StatePressed, Android.Resource.Attribute.StateChecked }
			};
			ColorStateList colorStateList = new ColorStateList(states,
				new int[]{
					Android.Graphics.Color.Gray.ToArgb()
					,this._tintColor.ToArgb(),
					this._checkedTextColor.ToArgb()});
			((Android.Widget.Button)view).SetTextColor(colorStateList);

			//Redraw with tint color
			Drawable checkedDrawable = Resources.GetDrawable(isCheckedResourceID).Mutate();
			Drawable uncheckedDrawable = Resources.GetDrawable(uncheckedResourceID).Mutate();
			((GradientDrawable)checkedDrawable).SetColor(TintColor.ToArgb());
			((GradientDrawable)uncheckedDrawable).SetStroke(oneDP, TintColor);

			//Create drawable
			StateListDrawable stateListDrawable = new StateListDrawable();
			stateListDrawable.AddState(new int[]{ -Android.Resource.Attribute.StateChecked }, uncheckedDrawable);
			stateListDrawable.AddState(new int[]{ Android.Resource.Attribute.StateChecked }, checkedDrawable);
			((SegmentView)view).Text = ((SegmentView)view).Text;
			//Set button brackgeound
			if((int)Build.VERSION.SdkInt >= 16){
				view.Background = stateListDrawable;
			}else{
				view.SetBackgroundDrawable(stateListDrawable);
			}
		}

		/*
}


		*/
	}
}


﻿namespace VisualPlus.Designer
{
    #region Namespace

    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    #endregion

    internal class VisualScrollBarDesigner : ControlDesigner
    {
        #region Properties

        /// <summary>Gets the <see cref="SelectionRules" /> for the control.</summary>
        public override SelectionRules SelectionRules
        {
            get
            {
                // gets the property descriptor for the property "Orientation"
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(Component)["Orientation"];

                // if not null - we can read the current orientation of the scroll bar
                if (propDescriptor != null)
                {
                    // get the current orientation
                    ScrollOrientation orientation = (ScrollOrientation)propDescriptor.GetValue(Component);

                    // if vertical orientation
                    if (orientation == ScrollOrientation.VerticalScroll)
                    {
                        return SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }

                    return SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
                }

                return base.SelectionRules;
            }
        }

        #endregion

        #region Events

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("Text");
            properties.Remove("ForeColor");
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("Font");
            properties.Remove("RightToLeft");

            base.PreFilterProperties(properties);
        }

        #endregion
    }
}
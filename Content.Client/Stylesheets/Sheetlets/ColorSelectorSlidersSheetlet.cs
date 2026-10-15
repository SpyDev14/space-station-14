using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Client.Stylesheets.Sheetlets;


[CommonSheetlet]
public sealed class ColorSelectorsSlidersSheetlet<T> : Sheetlet<T> where T : PalettedStylesheet
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        // Spacing between items in horizontal row
        const int horizontalGap = 4;

        return
        [
            // Root box: Header + Body + Hex input
            E().Class(ColorSelectorSliders.StyleClassRootBox)
                // Spacing between header, body and hex input
                .Prop(BoxContainer.StylePropertySeparation, 2),

            // Header: HSV/RGB mode selector + color name Label
            E().Class(ColorSelectorSliders.StyleClassHeaderBox)
                // Spacing between selector and color name
                .Prop(BoxContainer.StylePropertySeparation, horizontalGap)
                // Additional spacing between header and slider boxes
                .Margin(new Thickness(0, 0, 0, 2)),

            // Body: slider boxes
            E().Class(ColorSelectorSliders.StyleClassBodyBox)
                // Spacing between slider rows
                .Prop(BoxContainer.StylePropertySeparation, 1),

            // Slider box: Param letter (R/G/B or H/S/V) + color slider + value spin box
            E().Class(ColorSelectorSliders.StyleClassSliderRow)
                // Spacing between rune, color slider and spin box
                .Prop(BoxContainer.StylePropertySeparation, horizontalGap),

            // Hex input: "Hex:" Label + LineEdit
            E().Class(ColorSelectorSliders.StyleClassHexInputBox)
                // Spacing between label and input
                .Prop(BoxContainer.StylePropertySeparation, horizontalGap),
        ];
    }
}

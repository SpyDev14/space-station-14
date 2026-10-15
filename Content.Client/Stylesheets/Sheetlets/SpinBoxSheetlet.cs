using Content.Client.Stylesheets.SheetletConfigs;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Client.Stylesheets.Sheetlets;


[CommonSheetlet]
public sealed class SpinBoxSheetlet<T> : Sheetlet<T> where T : PalettedStylesheet, IButtonConfig
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        return
        [
            // SpinBox use "private SpinBoxButton : Button"
            E<Button>()
                .Class(SpinBox.MiddleButtonStyle)
                .Box(StyleBoxHelpers.SquareStyleBox(sheet)),
            E<Button>()
                .Class(SpinBox.LeftButtonStyle)
                .Box(StyleBoxHelpers.OpenRightStyleBox(sheet)),
            E<Button>()
                .Class(SpinBox.RightButtonStyle)
                .Box(StyleBoxHelpers.OpenLeftStyleBox(sheet)),

            E<SpinBox>() // Nested from BoxContainer
                .Prop(BoxContainer.StylePropertySeparation, 1),
        ];
    }
}

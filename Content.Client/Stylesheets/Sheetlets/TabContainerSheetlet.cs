using Content.Client.Stylesheets.SheetletConfigs;
using Content.Client.Stylesheets.Stylesheets;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Client.Stylesheets.Sheetlets;

[CommonSheetlet]
public sealed class TabContainerSheetlet<T> : Sheetlet<T> where T: PalettedStylesheet, ITabContainerConfig
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        var defaultStyle = new
        {
            Panel = sheet
                .GetTextureOr(sheet.TabContainerPanelPath, NanotrasenStylesheet.TextureRoot)
                .IntoPatch(StyleBox.Margin.All, 2),
            TabActive = new StyleBoxFlat()
            {
                BackgroundColor = sheet.SecondaryPalette.Element,
                ContentMarginRightOverride = 5,
                ContentMarginLeftOverride = 5,
            },
            TabInactive = new StyleBoxFlat()
            {
                BackgroundColor = sheet.SecondaryPalette.Background,
                ContentMarginRightOverride = 5,
                ContentMarginLeftOverride = 5,
            },
        };

        var noBorderedSecondaryStyle = new
        {
            Panel = new StyleBoxFlat()
            {
                BackgroundColor = sheet.SecondaryPalette.BackgroundLight,
            },
            TabActive = new StyleBoxFlat()
            {
                BackgroundColor = sheet.SecondaryPalette.BackgroundLight,
                ContentMarginRightOverride = 5,
                ContentMarginLeftOverride = 5,
            },
            TabInactive = new StyleBoxFlat()
            {
                BackgroundColor = sheet.SecondaryPalette.Background,
                ContentMarginRightOverride = 5,
                ContentMarginLeftOverride = 5,
            },
        };

        return
        [
            E<TabContainer>()
                .Prop(TabContainer.StylePropertyPanelStyleBox, defaultStyle.Panel)
                .Prop(TabContainer.StylePropertyTabStyleBox, defaultStyle.TabActive)
                .Prop(TabContainer.StylePropertyTabStyleBoxInactive, defaultStyle.TabInactive),

            E<TabContainer>().Class("TabNoBorderedSecondary")
                .Prop(TabContainer.StylePropertyPanelStyleBox, defaultStyle.Panel)
                .Prop(TabContainer.StylePropertyTabStyleBox, defaultStyle.TabActive)
                .Prop(TabContainer.StylePropertyTabStyleBoxInactive, defaultStyle.TabInactive),
        ];
    }
}

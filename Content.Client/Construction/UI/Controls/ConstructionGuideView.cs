using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Content.Shared.Construction;
using Content.Shared.Construction.Prototypes;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.RichText;

namespace Content.Client.Construction.UI.Controls;

public sealed class ConstructionGuideView : Control
{
    private sealed class RecipeRecordRow : BoxContainer
    {
        public Vector2 IconSize { get; set; } = new(24);

        public RecipeRecordRow(
            int number,
            IEnumerable<Texture> icons,
            FormattedString descriprion,
            IEnumerable<FormattedString> conditions
        )
        {
            var iconsBox = new VBox()
            {
                SeparationOverride = 1
            };

            foreach (var icon in icons)
            {
                var iconView = new TextureRect() {
                    Texture = icon,
                    SetSize = IconSize,
                };
                iconsBox.AddChild(iconView);
            }

            AddChild(new Label() { Text = $"{number}." });
        }
    }

    public ConstructionGuide? CurrentGuide { get; private set; }

    private BoxContainer _rootBox;

    public ConstructionGuideView()
    {
        AddChild(_rootBox = new VBox() { SeparationOverride = 4 });
    }

    public void SetGuide(ConstructionGuide guide)
    {
        if (guide == CurrentGuide)
            return;

        CurrentGuide = guide;
        ClearSteps();

        foreach (var entry in guide.Entries)
        {

        }
    }


    private void ClearSteps()
    {
        _rootBox.RemoveAllChildren();
    }

    private void AddStep(FormattedString description, string[] conditions)
    {

    }
}

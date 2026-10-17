using System;
using System.Collections.Generic;
using System.Text;
using Content.Shared.Construction.Prototypes;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Client.Construction.UI.Controls;

public sealed class RecipeStepsList : Control
{
    public ConstructionPrototype? CurrentRecipe { get; private set; }

    public RecipeStepsList()
    {
        var rootBox = new VBox();
        AddChild(rootBox);
    }

    public void SetRecipe(ConstructionPrototype recipeProto)
    {

    }
}

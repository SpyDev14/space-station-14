using Content.Shared.Construction;
using Content.Shared.Construction.Prototypes;
using Robust.Shared.Prototypes;

namespace Content.Client.Construction.UI.DTO;


// All this stuff represent buldings & items


/// <summary>
/// Data about category what needs for show
/// </summary>
/// <param name="Id">Unique ID from and for presenter, not a <see cref="ConstructionPrototype"/> id</param>
/// <param name="Name">Displayed name locale key</param>
public readonly record struct Category(
    string Id,
    string Name
);

/// <summary>
/// Main info about recipe, what needs for showing in list.
/// <paramref name="Name"/> and <paramref name="Description"/>
/// also used in info panel.
/// </summary>
/// <param name="Id">Unique ID from and for presenter, not a <see cref="ConstructionPrototype"/> id</param>
/// <param name="Name">Displayed name locale key</param>
/// <param name="Description">Displayed desc loc key</param>
/// <param name="EntityProtoId">Entity prototype for show icon</param>
public readonly record struct RecipeInfo(
    string Id,
    string Name,
    string Description,
    EntProtoId EntityProtoId
);

/// <summary>
/// Extra info for show recipe in information panel.
/// Complements <see cref="RecipeInfo"/>.
/// </summary>
public readonly record struct RecipeExtraInfo(
    ConstructionGuide ConstructionGuide,
    bool IsFavorited
);

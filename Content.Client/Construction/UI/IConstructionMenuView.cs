using Content.Client.UserInterface.Controls;
using Content.Shared.Construction.Conditions;
using Content.Shared.Construction.Prototypes;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;
using System.Collections.Immutable;

namespace Content.Client.Construction.UI;


// TEMPOARY HERE //
public enum Tool : byte
{
    Erase,
    Pipette,
}

/// <summary>
/// Data about category what needs for show
/// </summary>
/// <param name="Id">Unique ID from and for presenter</param>
/// <param name="Name">Displayed name locale key</param>
public readonly record struct Category(
    string Id,
    LocId Name
);

/// <summary>
/// Main info about recipe, what needs for showing in list.
/// <paramref name="Name"/> and <paramref name="Description"/>
/// also used in info panel.
/// </summary>
/// <param name="Id">Unique ID from and for presenter</param>
/// <param name="Name">Displayed name locale key</param>
/// <param name="Description">Displayed desc loc key</param>
/// <param name="EntityPrototype">Entity prototype for show good icon</param>
public readonly record struct Recipe(
    string Id,
    LocId Name,
    LocId Description,
    /// For icon; some abstract thing, like "Texture" will be better,
    /// but EntityPrototypeView too comfy to use, so...
    EntityPrototype EntityPrototype
);

/// <summary>
/// Extra info for show recipe in information panel.
/// Name and Description already has from <see cref="Recipe"/>.
/// </summary>
public readonly record struct RecipeExtraInfo(
    ImmutableArray<RecipeConstructionStep> ConstructionSteps,
    bool IsFavorited
);

public readonly record struct RecipeConstructionStep(
    SpriteSpecifier Icon
// TODO
);


/// <summary>
/// This is the interface for a UI View of the construction window. The point of it is to abstract away the actual
/// UI controls and just provide higher level operations on the entire window. This View is completely passive and
/// just raises events to the outside world. This class is controlled by the <see cref="LegacyConstructionMenuPresenter"/>.
/// </summary>
public interface IConstructionMenuView : IDisposable
{
    // I use Category & Recipe as ids instead raw strings
    // just for readabillity. It's equals to "Category.Id" & "Recipe.Id"

    #region Categories
    void SetCategories(IEnumerable<Category> categories);

    /// <summary>
    /// Called when some category is selected
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see langword="null"/> means "All" category.
    /// </para>
    /// <para>
    /// Favorites can be displayed as category, but handled by other event:
    /// <see cref="FavoritesSelected"/>
    /// </para>
    /// </remarks>
    event Action<Category?>? CategorySelected;
    event Action? FavoritesIsSelected;
    event Action? HistoryIsSelected;
    #endregion

    #region Recipes
    void SetRecipes(IEnumerable<Recipe> recipes);
    event Action<string>? SearchTextUpdated;
    /// <summary>
    /// <see cref="SelectedRecipe"/> is this <see cref="Recipe"/> now.
    /// </summary>
    event Action<Recipe>? RecipeSelected;
    /// <summary>
    /// Current resipe de-selected by any reason, but is not select other recipe:
    /// second click to recipe btn, close recipe info window — any reason, but not re-select.
    /// <see cref="SelectedRecipe"/> is <see langword="null"/> now. Deselected recipe
    /// given.
    /// </summary>
    event Action<Recipe>? RecipeDeselected;
    Recipe? SelectedRecipe { get; }

    /// <summary>
    /// Sets extra info about current recipe to info-panel.
    /// </summary>
    void ShowRecipeInfo(RecipeExtraInfo info);

    event Action<Recipe>? RecipeFavorited;
    event Action<Recipe>? RecipeUnfavorited;

    /// <summary>
    /// Update recipe is favorite.
    /// </summary>
    /// <param name="recipe">Needs for internal check.</param>
    /// <param name="isFavorite"></param>
    void UpdateRecipeIsFavorite(Recipe recipe, bool isFavorite);

    /// <summary>
    /// Set previous recipe (from history) is requested
    /// </summary>
    event Action? SetPreviousRecipeRequested;

    /// <summary>
    /// Set next recipe from history is requested
    /// </summary>
    event Action? SetNextRecipeRequested;

    /// <summary>
    /// Set given recipe to <see cref="SelectedRecipe"/>, raise
    /// <see cref="RecipeSelected"/> event.
    /// </summary>
    /// <param name="recipe">Recipe to set</param>
    /// <param name="categoryToOpen">Category what will be opened</param>
    void SelectRecipe(Recipe recipe, Category categoryToOpen);

    /// <summary>
    /// Give info about previous recipe in the history.
    /// For show icon-button, for example.
    /// </summary>
    /// <param name="prevRecipe"></param>
    void SetPreviousRecipeDisplay(Recipe prevRecipe);
    #endregion

    #region Tools
    event Action<Tool>? ToolSelected;
    event Action? ClearAllIsRequested;
    event Action? RotateClockwiseRequested;
    event Action RotateCounterClockwiseRequested;
    #endregion


    #region Window controlling
    event Action? OnClose;

    void Close();

    void Open();
    #endregion
}

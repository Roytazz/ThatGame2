﻿using GuildWars2.API;
using GuildWars2.API.Model.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.Manager.Recipes
{
    public class ItemRecipeTreeNode
    {
        private Item _item;
        private Recipe _recipe;
        private List<int> _recipeIDs;

        public List<ItemRecipeTreeNode> Children { get; set; }

        public int ItemID { get; set; }

        public ItemRecipeTreeNode(int itemID) {
            _recipeIDs = new List<int>();
            Children = new List<ItemRecipeTreeNode>();
            ItemID = itemID;

            PopulateRecipe();
            PopulateChildren();
        }

        public ItemRecipeTreeNode(Item item) : this(item.ID) { _item = item; }

        public async Task<Item> GetItem()
        {
            if (_item == null)
                _item = await ItemAPI.Items(ItemID);

            return _item;
        }

        private async void PopulateRecipe() {
            _recipeIDs = await ItemAPI.SearchRecipesByOutput(ItemID);
            if (_recipeIDs?.Count > 0) {                                                            //Check for normal recipe
                _recipe = await ItemAPI.Recipes(_recipeIDs[0]);
            }
            else if (!ItemAPI.IsPromotionItem(ItemID)) {                                            //Check for Mystic Forge recipe
                var mysticForgeRecipes = await ItemAPI.SearchMysticForgeRecipesByOutput(ItemID);

                if (mysticForgeRecipes?.Count > 0) {
                    _recipe = mysticForgeRecipes[0];
                    foreach (var recipe in mysticForgeRecipes) {
                        _recipeIDs.Add(recipe.ID);
                    }
                }
            }
            else {
                var item = await GetItem();
                if (item != null && item.Details != null && item.Details.RecipeID != 0) {          //Check for weird recipe in Item.Details
                    _recipeIDs.Add(item.Details.RecipeID);                                              //This forces us to load the Item object.
                    _recipe = await ItemAPI.Recipes(item.Details.RecipeID);
                }
            }
        }

        private void PopulateChildren() {
            if (_recipe == null)
                return;

            foreach (RecipeIngredient ingredient in _recipe?.Ingredients) {
                Children.Add(new ItemRecipeTreeNode(ingredient.ItemID));
            }
        }
    }
}
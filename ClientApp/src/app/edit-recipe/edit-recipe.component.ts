import { Component, OnInit } from '@angular/core';
import {IRecipe} from "../recipe-list/recipe";
import {IIngredient} from "../ingredients/ingredient";
import {RecipeListService} from "../recipe-list/recipe-list.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-create-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['./edit-recipe.component.css']
})
export class EditRecipeComponent implements OnInit {


  // Edit and Create
  pageTitle = "Create New Recipe"
  toggleSave = false
  id: number;

  isEdit: boolean;

  recipe:IRecipe
  constructor(private recipeService: RecipeListService, private route: ActivatedRoute) {
    this.route.data.subscribe(x => this.isEdit = x.edit);
    this.route.params.subscribe(params => {
      this.id = params.id
    })
  }


  addIngredient(){
    this.recipe.ingredients.push({amount: null, food: ""})
  }

  removeIngredient(ingredient){
    this.recipe.ingredients = this.recipe.ingredients.filter(y => y != ingredient)
  }

  saveRecipe(){
    this.toggleSave = !this.toggleSave
    if(this.isEdit){
      console.log(this.recipe)
      this.recipeService.updateRecipe(this.recipe).subscribe()
    }
    else {
      this.recipeService.createRecipe(this.recipe).subscribe()
    }
  }
  ngOnInit() {

    if(this.isEdit){   // If editing instead of creating
      this.recipeService.getRecipe(this.id).subscribe(x => {
        this.recipe = x;
      })
    }
    else{   // Creating instead of editing
      this.recipe = {
        name: "",
        summary: "",
        ingredients: [],
        id: null
      }
    }
  }

}

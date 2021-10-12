import { Component, OnInit } from '@angular/core';
import {IRecipe} from "./recipe";
import {IIngredient} from "../ingredients/ingredient";
import {Router} from "@angular/router";
import {RecipeListService} from "./recipe-list.service";

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
  providers: [RecipeListService]
})
export class RecipeListComponent implements OnInit {

  pageTitle = "Recipe List";
  deleteConfirm: boolean;
  deleteText = "Delete";

  private _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string){
    this._listFilter = value;
    // this.filteredRecipe = this.performFilter(value);
  }
  ingredients: IIngredient[] = []
  // filteredRecipe: IRecipe[] = [];

  recipe: IRecipe
  recipes: IRecipe[]

  constructor(private router: Router, private recipeService: RecipeListService) {
  }

  // performFilter(filterBy: string): IRecipe[] {
  //   filterBy = filterBy.toLocaleLowerCase();
  //   return this.recipes.filter((recipe: IRecipe) =>
  //     recipe.name.toLocaleLowerCase().includes(filterBy));
  // }
  edit(id: number){
    this.router.navigate(["/edit-recipe/"+id]);
  }

  delete(id: number){ // Popup text boxes
    if(this.deleteConfirm){
      this.deleteConfirm = !this.deleteConfirm
      this.recipeService.deleteRecipe(id).subscribe(x => this.recipes = this.recipes.filter(y => y.id != x.id))
      this.deleteText = "Delete"
    }
    else{
      this.deleteConfirm = !this.deleteConfirm
      this.deleteText = "Confirm?"
    }
  }

  create(){
    this.router.navigate(["/create-recipe"])
  }


  ngOnInit(): void {
    console.log(this.recipeService);
    this.recipeService.getRecipes().subscribe( (x: IRecipe[]) => {
        this.recipes = x;
        console.log(this.recipes);
      // this.recipes = this.objectToRecipe(x);
    });
  }
}


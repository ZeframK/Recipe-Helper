import { Component, OnInit } from '@angular/core';
import {IIngredient} from "./ingredient";

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.css']
})
export class IngredientsComponent implements OnInit {
  pageTitle = "Ingredients List";

  private _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string){
    this._listFilter = value;
    this.filteredIngredients = this.performFilter(value);
  }

  filteredIngredients: IIngredient[] = [];

  ingredients: IIngredient[] = []
  constructor() { }

  performFilter(filterBy: string): IIngredient[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.ingredients.filter((ingredient: IIngredient) =>
      ingredient.food.toLocaleLowerCase().includes(filterBy));
  }
  ngOnInit() {
  }

}

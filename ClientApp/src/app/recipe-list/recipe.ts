import {IIngredient} from "../ingredients/ingredient";

export interface IRecipe {
  name:string;
  summary: string;
  ingredients: IIngredient[]
  id: number;
}


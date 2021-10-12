import {Injectable, Inject} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";
import {IRecipe} from "./recipe";

@Injectable({
  providedIn: 'root'
})
export class RecipeListService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseURL: string){}

  getRecipes(): Observable<any[]> {
    // const url = `${this.baseURL}api/recipes`;
    return this.http.get<any[]>('recipe');
  }

  getRecipe(id: number): Observable<any> { // May be problematic if not Observable<any>
    return this.http.get<any>('recipe/'+ id);
  }

  createRecipe(recipe: IRecipe): Observable<any> {
    return this.http.post('recipe', {
      "name": recipe.name,
      "summary": recipe.summary,
      "ingredients": recipe.ingredients
    })
  }

  updateRecipe(recipe: IRecipe): Observable<any> {
    return this.http.put('recipe', {
      "name": recipe.name,
      "summary": recipe.summary,
      "id": recipe.id,
      "ingredients": recipe.ingredients
    })
  }

  deleteRecipe(id: number): Observable<any> {
    return this.http.delete('recipe/' + id )
  }

  // createRecipe():
}

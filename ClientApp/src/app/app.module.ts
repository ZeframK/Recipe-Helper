import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { IngredientsComponent } from './ingredients/ingredients.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { EditRecipeComponent } from './edit-recipe/edit-recipe.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    IngredientsComponent,
    RecipeListComponent,
    EditRecipeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'ingredients', component: IngredientsComponent},
      { path: 'recipe-list', component: RecipeListComponent},
      { path: 'edit-recipe/:id', component: EditRecipeComponent, data: {edit: true}},
      { path: 'create-recipe', component: EditRecipeComponent, data: {edit: false}}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

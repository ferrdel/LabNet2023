import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Categoria1Component } from './categorias/components/categoria1/categoria1.component';

const routes: Routes = [
  {
    path: '',
    component: Categoria1Component
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

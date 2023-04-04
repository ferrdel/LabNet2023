import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Categoria1Component } from './components/categoria1/categoria1.component';
import { HttpClientModule } from '@angular/common/http';


import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    Categoria1Component
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule 
  ]
})
export class CategoriasModule { }

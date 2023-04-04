import { Component, OnInit, TemplateRef } from '@angular/core';
import { CategoriasService } from './services/categorias.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Categoria } from './models/categoria';


@Component({
  selector: 'app-categoria1',
  templateUrl: './categoria1.component.html',
  styleUrls: ['./categoria1.component.scss'],
  providers: [CategoriasService],
})
export class Categoria1Component implements OnInit {

  formCategoria: FormGroup = new FormGroup({
    nombreCategoria: new FormControl(' ', [Validators.required, Validators.minLength(1), Validators.maxLength(15)]),
    descripcion: new FormControl(' ', [Validators.required, Validators.minLength(1), Validators.maxLength(40)])
  });

  public listaCategorias: any;

  public categoria1 = new Categoria();

  idC: any = 0;
  mostrarAdd!: boolean;
  mostrarUpdate!: boolean;

  constructor(private categoriasService: CategoriasService,
    private formb: FormBuilder) {

  }

  ngOnInit(): void {
    this.obtenerCateg();
    this.clickBtnAdd();
  }

  onSubmit() {
    console.log(this.formCategoria.value);
  }

  obtenerCateg() {
    this.categoriasService.listarCategoria().subscribe(res => {
      this.listaCategorias = res;
    });
  }

  guardarCategoria() {
    this.categoria1.CategoryName = this.formCategoria.value.nombreCategoria;
    this.categoria1.Description = this.formCategoria.value.descripcion;

    this.categoriasService.crearCategoria(this.categoria1).subscribe(res => {
      this.formCategoria.reset();
      this.obtenerCateg();
    });
    alert("se guardo la categoria");
  }

  onEditForm(categoria: any,id:number) {
    if (window.confirm('¿Está seguro que desea modificar el registro?')) {

      this.mostrarAdd = false;
      this.mostrarUpdate = true;


      this.idC = id;
      
      this.formCategoria.controls['nombreCategoria'].setValue(categoria.CategoryID)
      this.formCategoria.controls['nombreCategoria'].setValue(categoria.NombreCategoria)
      this.formCategoria.controls['descripcion'].setValue(categoria.Descripcion)
    }
  }

  onEditCategoria() {
    
    this.categoria1.CategoryID = this.idC;
    this.categoria1.CategoryName = this.formCategoria.value.nombreCategoria;
    this.categoria1.Description = this.formCategoria.value.descripcion;

    if (window.confirm('¿Desea modificar la categoria?')) {
      this.categoriasService.modificarCategoria(this.idC, this.categoria1).subscribe(res => {
        this.formCategoria.reset();
        this.obtenerCateg();
      });
      alert("se guardo la categoria");
    }
    this.clickBtnAdd();
  }

  deleteCategoria(id: number) {
    if (window.confirm('¿Está seguro que desea eliminar el registro?')) {
      this.categoriasService.eliminarCategoria(id).subscribe(res => {
        this.obtenerCateg();
      });
      
      alert("se elimino la categoria");
    }

  }

  clickBtnAdd() {
    this.mostrarAdd = true;
    this.mostrarUpdate = false;
  }

}

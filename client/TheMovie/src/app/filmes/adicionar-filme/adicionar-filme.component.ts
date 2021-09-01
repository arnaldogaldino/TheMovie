import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Filme } from 'src/app/models/filme';
import { FilmeService } from 'src/app/services/filme.service';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';

import { Router } from '@angular/router';

@Component({
  selector: 'app-adicionar-filme',
  templateUrl: './adicionar-filme.component.html',
  styleUrls: ['./adicionar-filme.component.scss']
})
export class AdicionarFilmeComponent implements OnInit {
  public filmeForm: any = FormGroup; 
  public filme!: Filme;
  public errors: any[] = [];
  public fileToUpload: any;
  public fileToBase: any;
  public toastContainer!: ToastContainerDirective;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private filmeService: FilmeService,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.toastrService.overlayContainer = this.toastContainer;

    this.filmeForm = this.formBuilder.group({
      id: new FormControl('0', [Validators.required]),
      nome: new FormControl('', [Validators.required]),
      titulo: new FormControl('', [Validators.required]),
      sinopse: new FormControl('', [Validators.required]),
      genero: new FormControl('', [Validators.required]),
      ano: new FormControl('0', [Validators.required]),
      nota: new FormControl('1', [Validators.required]),
      nota_valor: new FormControl('1', [Validators.required]),
      poster: new FormControl('', [Validators.required]),
      favorito: new FormControl('false'),
    });
  }

  adicionarFilme(): void {
    if (this.filmeForm.dirty && this.filmeForm.valid) {
      let filme = Object.assign({}, this.filme, this.filmeForm.value);
      filme.id = 0;
      filme.poster = this.fileToBase;
      filme.favorito = false;
      if (this.filmeForm.value.favorito == 'true') filme.favorito = true;
      
      console.log(filme);

      this.filmeService.registrarFilme(filme)
        .subscribe(
          result => { 
            this.onSaveComplete() 
          },
          fail => { 
            this.onError(fail); 
          }
        );
    }
  }

  handleFileInput(file: any) {
    this.fileToUpload = file.target.files[0];

    var reader = new FileReader();
    reader.onload = (event:any) => {
      this.fileToBase = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

  onError(fail: any): void {
    this.toastrService.error('Falha no processamento', 'Falha');
    this.errors = fail.error.errors;
  }
  
  onSaveComplete(): void {

    this.filmeForm.reset();
    this.errors = [];

    this.toastrService.success('Cadatrado com Sucesso!', 'Oba :D')
      .onHidden
      .pipe().subscribe(() => {
        this.router.navigate(['/listar-filme']);
      });
  }
}
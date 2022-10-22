import { Component, OnInit } from '@angular/core';
import { Filme } from 'src/app/models/filme';
import { FilmeService } from 'src/app/services/filme.service';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';

import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-favoritos-filme',
  templateUrl: './favoritos-filme.component.html',
  styleUrls: ['./favoritos-filme.component.scss']
})
export class FavoritosFilmeComponent implements OnInit {
  public filmes: Filme[] = [];
  public errors: any[] = [];

  constructor(private router: Router,
    private filmeService: FilmeService) { 

  }

  ngOnInit(): void {
    this.filmeService.favoritosFilmes()
    .subscribe(
      result => {
        this.filmes = result;
      },
      fail => {
        console.log(fail);
      }
    );
  }
  
  favoritar(id: number, idx: number): void {
    this.filmes[idx].favorito = true;
    this.filmeService.favoritarFilme(id)
      .subscribe(
        result => {
          console.log(result);
        },
        fail => {
          console.log(fail);
        }
      );
  }
  
  desfavoritar(id: number, idx: number): void {
    this.filmes[idx].favorito = false;
    this.filmeService.desfavoritarFilme(id)
      .subscribe(
        result => {
          console.log(result);
        },
        fail => {
          console.log(fail);
        }
      );
  }
}

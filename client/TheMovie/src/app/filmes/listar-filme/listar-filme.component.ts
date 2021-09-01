import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Filme } from 'src/app/models/filme';
import { FilmeService } from 'src/app/services/filme.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-listar-filme',
  templateUrl: './listar-filme.component.html',
  styleUrls: ['./listar-filme.component.scss']
})
export class ListarFilmeComponent implements OnInit {
  public filmes: Filme[] = [];
  public errors: any[] = [];
  public filmeId: number = 0;
  public search: string = '';
  public sub!: Subscription;

  constructor(private router: Router,
    private routeAc: ActivatedRoute,
    private filmeService: FilmeService) { 

  }

  ngOnInit(): void {
    this.sub = this.routeAc.params.subscribe(
      params => {
        this.search = params['search'];
      });

    this.filmeService.listarFilmes()
    .subscribe(
      result => {
        this.filmes = result;
        if(this.search) {
          this.filmes = this.filmes.filter(s => s.nome.includes(this.search));
        }
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

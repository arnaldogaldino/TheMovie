import { Component, OnInit } from '@angular/core';
import { Filme } from 'src/app/models/filme';
import { FilmeService } from 'src/app/services/filme.service';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';

import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-detalhes-filme',
  templateUrl: './detalhes-filme.component.html',
  styleUrls: ['./detalhes-filme.component.scss']
})

export class DetalhesFilmeComponent implements OnInit {
  public sub!: Subscription;
  public filmeId: number = 0;
  public filme!: Filme;

  constructor(private filmeService: FilmeService,
    private routeAc: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {    
    this.sub = this.routeAc.params.subscribe(
      params => {
        this.filmeId = params['id'];
      });

      this.filmeService.obterFilme(this.filmeId)
      .subscribe(
        filme => {
          this.filme = filme;
        });
  }

}

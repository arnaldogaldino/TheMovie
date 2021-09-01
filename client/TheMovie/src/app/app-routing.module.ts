import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AdicionarFilmeComponent } from './filmes/adicionar-filme/adicionar-filme.component';
import { ListarFilmeComponent } from './filmes/listar-filme/listar-filme.component';
import { FavoritosFilmeComponent } from './filmes/favoritos-filme/favoritos-filme.component';
import { DetalhesFilmeComponent } from './filmes/detalhes-filme/detalhes-filme.component';

const routes: Routes = [
  { path: '', component: ListarFilmeComponent },
  { path: 'adicionar-filme', component: AdicionarFilmeComponent },
  { path: 'listar-filme', component: ListarFilmeComponent },
  { path: 'procurar-filme/:search', component: ListarFilmeComponent },
  { path: 'favoritos-filme', component: FavoritosFilmeComponent },
  { path: 'detalhes-filme/:id', component: DetalhesFilmeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

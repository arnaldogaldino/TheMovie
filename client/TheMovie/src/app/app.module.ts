import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormBuilder, FormGroup, FormControl,  ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AdicionarFilmeComponent } from './filmes/adicionar-filme/adicionar-filme.component';
import { ToastrModule, ToastNoAnimation, ToastNoAnimationModule, ToastContainerModule } from 'ngx-toastr';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FilmeService } from './services/filme.service';
import { ListarFilmeComponent } from './filmes/listar-filme/listar-filme.component';
import { DetalhesFilmeComponent } from './filmes/detalhes-filme/detalhes-filme.component';
import { FavoritosFilmeComponent } from './filmes/favoritos-filme/favoritos-filme.component';
import { MenuComponent } from './shared/menu/menu.component';
import { ProcurarComponent } from './shared/procurar/procurar.component';

@NgModule({
  declarations: [
    AppComponent,
    AdicionarFilmeComponent,
    ListarFilmeComponent,
    DetalhesFilmeComponent,
    FavoritosFilmeComponent,
    MenuComponent,
    ProcurarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({ positionClass: 'inline' }),
    ToastContainerModule,
    HttpClientModule,
    ToastNoAnimationModule.forRoot(),
  ],
  providers: [
    FilmeService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }

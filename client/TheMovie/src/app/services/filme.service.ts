import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { BaseService } from './base.service';

import { from, Observable } from 'rxjs'; 
import { map, catchError, tap } from 'rxjs/operators';

import { Filme } from '../models/filme';

@Injectable({
  providedIn: 'root'
})

export class FilmeService extends BaseService {

  constructor(private http: HttpClient) { 
    super();
  }

  registrarFilme(filme: Filme): Observable<Filme> {

    let response = this.http
        .post(this.UrlService + "filme", filme, super.GetHeaderJson())
        .pipe(
          tap(super.extractData),
          catchError(this.serviceError)
        );
    return response;
  }

  listarFilmes(): Observable<Filme[]> {      
    let response = this.http
        .get<Filme[]>(this.UrlService + "filme", super.GetHeaderJson())
        .pipe(
          tap(super.extractData),
          catchError(this.serviceError)
        );
    return response;
  }

  favoritosFilmes(): Observable<Filme[]> {      
    let response = this.http
        .get<Filme[]>(this.UrlService + "filme/favoritos", super.GetHeaderJson())
        .pipe(
          tap(super.extractData),
          catchError(this.serviceError)
        );
    return response;
  }

  obterFilme(id: number): Observable<Filme> {      
    let response = this.http
      .get<Filme>(this.UrlService + "filme/" + id, super.GetHeaderJson())
      .pipe(
        tap(super.extractData),
        catchError(this.serviceError)
      );
    return response;
  }

  favoritarFilme(id: number): Observable<any> {      
    return this.http
      .get(this.UrlService + "filme/favoritar/" + id, super.GetHeaderJson())
      .pipe(
        tap(super.extractData),
        catchError(this.serviceError)
      );
  }

  desfavoritarFilme(id: number): Observable<any> {      
    return this.http
      .get(this.UrlService + "filme/desfavoritar/" + id, super.GetHeaderJson())
      .pipe(
        tap(super.extractData),
        catchError(this.serviceError)
      );
  }

}

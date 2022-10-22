import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-procurar',
  templateUrl: './procurar.component.html',
  styleUrls: ['./procurar.component.scss']
})
export class ProcurarComponent implements OnInit {
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  procurar(search: string): void {
    this.router.navigate(['/procurar-filme/' + search]);
  }
}

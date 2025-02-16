import { TuiRoot } from "@taiga-ui/core";
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layouts/header/header.component";
import { MovieCardComponent } from "./features/movies/movie-card/movie-card.component";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TuiRoot, HeaderComponent, MovieCardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  baseUrl = "https://localhost:5001/api/"
  title = 'movie-database';

  private http = inject(HttpClient);

  
  ngOnInit(): void {
    this.http.get(this.baseUrl + 'movies').subscribe({
      next: data => console.log(data),
      error: error => console.log(error),
      complete: () => console.log('request completed')
    });
  }
}

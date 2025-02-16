import { TuiRoot } from "@taiga-ui/core";
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layouts/header/header.component";
import { MovieCardComponent } from "./features/movies/movie-card/movie-card.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TuiRoot, HeaderComponent, MovieCardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'movie-database';
}

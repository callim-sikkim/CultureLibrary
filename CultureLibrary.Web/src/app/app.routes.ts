import { Routes } from '@angular/router';
import {BookListComponent} from './components/book-list-component/book-list-component';
import {GameListComponent} from './components/game-list-component/game-list-component';
import {HomeComponent} from './components/home-component/home-component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: "Culture Library - Home"
  },
  {
    path: 'books',
    component: BookListComponent,
    title: 'Book List'
  },
  {
    path: 'games',
    component: GameListComponent,
    title: 'Game List'
  }
];
